function New-ProductCode([string]$version) {
    $md5 = [System.Security.Cryptography.MD5]::Create()
    $bytes = [Text.Encoding]::UTF8.GetBytes($version)
    $hash = $md5.ComputeHash($bytes)

    return ([Guid]::new($hash)).ToString().ToUpper()
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

$root = Get-Location

$csproj = "$root\Syndic\SyndicApplication.csproj"
$props = [xml](Get-Content $csproj)

# Récupération version
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

Write-Host "Version build : $version ($msiVersion)"
Write-Host "ProductCode   : {$productCode}"

# Mise à jour du projet MSI
$vdproj = "$root\Syndic.Setup\Syndic.Setup.vdproj"

if (!(Test-Path $vdproj)) {
    throw "Projet Setup introuvable : $vdproj"
}

$content = Get-Content $vdproj -Raw -Encoding Ansi

$productLine = '"ProductCode" = "8:{' + $productCode + '}"'
$versionLine = '"ProductVersion" = "8:' + $msiVersion + '"'

$content = $content -replace '"ProductCode" = "8:\{[^}]+\}"', $productLine
$content = $content -replace '"ProductVersion" = "8:[^"]+"', $versionLine

Set-Content $vdproj $content -Encoding Ansi

# Contrôle
if (!(Select-String $vdproj -Pattern $productCode)) {
    throw "ProductCode non mis à jour dans le vdproj"
}

Write-Host "Build .NET..."

dotnet build ".\Syndic\SyndicApplication.csproj" -c Release

if ($LASTEXITCODE -ne 0) {
    throw "dotnet build failed"
}

Write-Host "Publish..."

dotnet publish ".\Syndic\SyndicApplication.csproj" `
    -c Release `
    -r win-x64 `
    --self-contained false `
    -p:PublishSingleFile=true `
    -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:DebugType=None `
    -p:DebugSymbols=false `
    -p:SatelliteResourceLanguages=fr `
    -o ".\publish"

if ($LASTEXITCODE -ne 0) {
    throw "dotnet publish failed"
}

Write-Host "Build MSI..."

devenv.com ".\ProjectsPartners.Syndic.sln" /Project "Syndic.Setup" /Build "Release"

if ($LASTEXITCODE -ne 0) {
    throw "Setup build failed"
}

$msiName = "Gestion de Copropriétés $version x64.msi"
$msiPath = ".\publish\$msiName"

Copy-Item ".\Syndic.Setup\Release\Syndic.Setup.msi" $msiPath -Force

Write-Host "Signature MSI..."

signtool sign `
    /a `
    /fd SHA256 `
    /tr http://timestamp.digicert.com `
    /td SHA256 `
    $msiPath

if ($LASTEXITCODE -ne 0) {
    throw "MSI signing failed"
}

Write-Host ""
Write-Host "======================================"
Write-Host "Build terminé"
Write-Host "MSI : $msiPath"
Write-Host "Version : $version"
Write-Host "ProductCode : {$productCode}"
Write-Host "======================================"