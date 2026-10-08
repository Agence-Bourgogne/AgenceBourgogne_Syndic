function New-ProductCode([string]$version) {
    $md5 = [System.Security.Cryptography.MD5]::Create()

    try {
        $bytes = [System.Text.Encoding]::UTF8.GetBytes($version)
        $hash = $md5.ComputeHash($bytes)

        return ([Guid]::new($hash)).ToString().ToUpper()
    }
    finally {
        $md5.Dispose()
    }
}

function Convert-ToMsiVersion([string]$version) {
    $parts = $version.Split('.')

    if ($parts.Count -eq 3) {
        return "{0}.{1}.{2:D4}" -f `
            [int]$parts[0], `
            [int]$parts[1], `
            [int]$parts[2]
    }

    throw "Version invalide : $version"
}

function Invoke-CommandChecked {
    param(
        [Parameter(Mandatory = $true)]
        [string]$FilePath,

        [Parameter(Mandatory = $false)]
        [string[]]$ArgumentList = @(),

        [Parameter(Mandatory = $true)]
        [string]$ErrorMessage
    )

    Write-Host ""
    Write-Host ">> $FilePath $($ArgumentList -join ' ')"
    Write-Host ""

    & $FilePath @ArgumentList

    if ($LASTEXITCODE -ne 0) {
        throw $ErrorMessage
    }
}

# ============================================================
# Configuration
# ============================================================

$ErrorActionPreference = "Stop"

$root = (Get-Location).Path

$csproj = Join-Path $root "Syndic\SyndicApplication.csproj"
$solution = Join-Path $root "ProjectsPartners.Syndic.sln"
$vdproj = Join-Path $root "Syndic.Setup\Syndic.Setup.vdproj"

$publishDir = Join-Path $root "publish"

$configuration = "Release"
$runtime = "win-x64"

# ============================================================
# Vérifications
# ============================================================

Write-Host "======================================"
Write-Host "Build Gestion de Copropriétés"
Write-Host "======================================"

if (!(Test-Path $csproj)) {
    throw "Projet .NET introuvable : $csproj"
}

if (!(Test-Path $solution)) {
    throw "Solution introuvable : $solution"
}

if (!(Test-Path $vdproj)) {
    throw "Projet Setup introuvable : $vdproj"
}

# ============================================================
# Récupération de la version
# ============================================================

Write-Host ""
Write-Host "Lecture de la version..."

$props = [xml](Get-Content $csproj)

$versionNode = $props.SelectSingleNode("//Version")

if ($null -eq $versionNode) {
    throw "Balise <Version> introuvable dans $csproj"
}

$version = $versionNode.InnerText.Trim()

if ([string]::IsNullOrWhiteSpace($version)) {
    throw "Version vide dans $csproj"
}

$msiVersion = Convert-ToMsiVersion $version
$productCode = New-ProductCode $version

Write-Host "Version build : $version"
Write-Host "Version MSI   : $msiVersion"
Write-Host "ProductCode   : {$productCode}"

# ============================================================
# Recherche de Visual Studio / MSBuild
# ============================================================

Write-Host ""
Write-Host "Recherche de Visual Studio..."

$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"

if (!(Test-Path $vswhere)) {
    throw "vswhere.exe introuvable : $vswhere"
}

$msbuild = & $vswhere `
    -latest `
    -products * `
    -requires Microsoft.Component.MSBuild `
    -find MSBuild\Current\Bin\MSBuild.exe |
    Select-Object -First 1

if ([string]::IsNullOrWhiteSpace($msbuild)) {
    throw "MSBuild de Visual Studio introuvable."
}

if (!(Test-Path $msbuild)) {
    throw "MSBuild introuvable : $msbuild"
}

Write-Host "MSBuild : $msbuild"

# ============================================================
# Recherche de devenv.com
# ============================================================

$devenv = & $vswhere `
    -latest `
    -products * `
    -requires Microsoft.VisualStudio.Component.CoreEditor `
    -find Common7\IDE\devenv.com |
    Select-Object -First 1

if ([string]::IsNullOrWhiteSpace($devenv)) {
    throw "devenv.com introuvable."
}

if (!(Test-Path $devenv)) {
    throw "devenv.com introuvable : $devenv"
}

Write-Host "Visual Studio : $devenv"

# ============================================================
# Mise à jour du projet MSI
# ============================================================

Write-Host ""
Write-Host "Mise à jour du projet MSI..."

$content = Get-Content $vdproj -Raw -Encoding Ansi

$productLine = '"ProductCode" = "8:{' + $productCode + '}"'
$versionLine = '"ProductVersion" = "8:' + $msiVersion + '"'

$content = $content -replace `
    '"ProductCode" = "8:\{[^}]+\}"', `
    $productLine

$content = $content -replace `
    '"ProductVersion" = "8:[^"]+"', `
    $versionLine

Set-Content $vdproj $content -Encoding Ansi

# Contrôles

$updatedContent = Get-Content $vdproj -Raw -Encoding Ansi

if ($updatedContent -notmatch [regex]::Escape($productCode)) {
    throw "ProductCode non mis à jour dans le vdproj"
}

if ($updatedContent -notmatch [regex]::Escape($msiVersion)) {
    throw "ProductVersion non mise à jour dans le vdproj"
}

Write-Host "ProductCode mis à jour."
Write-Host "ProductVersion mise à jour."

# ============================================================
# Nettoyage
# ============================================================

Write-Host ""
Write-Host "Nettoyage..."

if (Test-Path $publishDir) {
    Remove-Item $publishDir -Recurse -Force
}

# On supprime obj pour éviter de réutiliser un project.assets.json
# généré avec un autre RuntimeIdentifier.
$objDir = Join-Path (Split-Path $csproj -Parent) "obj"

if (Test-Path $objDir) {
    Remove-Item $objDir -Recurse -Force
}

New-Item -ItemType Directory -Path $publishDir -Force | Out-Null

# ============================================================
# RESTORE
# ============================================================

Write-Host ""
Write-Host "======================================"
Write-Host "RESTORE WIN-X64"
Write-Host "======================================"

& dotnet restore $csproj `
    --runtime $runtime `
    --force

if ($LASTEXITCODE -ne 0) {
    throw "dotnet restore failed"
}

# ============================================================
# BUILD
# ============================================================

Write-Host ""
Write-Host "======================================"
Write-Host "BUILD"
Write-Host "======================================"

& $msbuild $csproj `
    /t:Build `
    /p:Configuration=$configuration `
    /p:RuntimeIdentifier=$runtime `
    /p:SelfContained=false `
    /p:RestoreIgnoreFailedSources=false

if ($LASTEXITCODE -ne 0) {
    throw "MSBuild build failed"
}

# ============================================================
# PUBLISH
# ============================================================

Write-Host ""
Write-Host "======================================"
Write-Host "PUBLISH"
Write-Host "======================================"

& $msbuild $csproj `
    /t:Publish `
    /p:Configuration=$configuration `
    /p:RuntimeIdentifier=$runtime `
    /p:SelfContained=false `
    /p:PublishSingleFile=true `
    /p:IncludeNativeLibrariesForSelfExtract=true `
    /p:DebugType=None `
    /p:DebugSymbols=false `
    /p:SatelliteResourceLanguages=fr `
    /p:PublishDir="$publishDir\" `
    /p:Restore=false

if ($LASTEXITCODE -ne 0) {
    throw "MSBuild publish failed"
}

# ============================================================
# BUILD MSI
# ============================================================

Write-Host ""
Write-Host "======================================"
Write-Host "BUILD MSI"
Write-Host "======================================"

Invoke-CommandChecked `
    -FilePath $devenv `
    -ArgumentList @(
        $solution,
        "/Project",
        "Syndic.Setup",
        "/Build",
        "$configuration"
    ) `
    -ErrorMessage "Setup build failed"

# ============================================================
# Vérification du MSI
# ============================================================

$setupMsi = Join-Path $root "Syndic.Setup\$configuration\Syndic.Setup.msi"

if (!(Test-Path $setupMsi)) {
    throw "MSI généré introuvable : $setupMsi"
}

Write-Host ""
Write-Host "MSI généré : $setupMsi"

# ============================================================
# Copie du MSI dans publish
# ============================================================

$msiName = "Gestion de Copropriétés $version x64.msi"
$msiPath = Join-Path $publishDir $msiName

Copy-Item $setupMsi $msiPath -Force

if (!(Test-Path $msiPath)) {
    throw "Impossible de copier le MSI vers : $msiPath"
}

Write-Host "MSI copié : $msiPath"

# ============================================================
# Signature
# ============================================================

Write-Host ""
Write-Host "======================================"
Write-Host "SIGNATURE MSI"
Write-Host "======================================"

$signtool = Get-Command signtool.exe -ErrorAction SilentlyContinue

if ($null -eq $signtool) {
    throw "signtool.exe introuvable dans le PATH."
}

Invoke-CommandChecked `
    -FilePath $signtool.Source `
    -ArgumentList @(
        "sign",
        "/a",
        "/fd",
        "SHA256",
        "/tr",
        "http://timestamp.digicert.com",
        "/td",
        "SHA256",
        $msiPath
    ) `
    -ErrorMessage "MSI signing failed"

# ============================================================
# FIN
# ============================================================

Write-Host ""
Write-Host "======================================"
Write-Host "BUILD TERMINÉ"
Write-Host "======================================"
Write-Host "Version     : $version"
Write-Host "MSI Version : $msiVersion"
Write-Host "ProductCode : {$productCode}"
Write-Host "Runtime     : $runtime"
Write-Host "MSI         : $msiPath"
Write-Host "======================================"