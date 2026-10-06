using System;
using System.Collections.Generic;
using System.Linq;

namespace SyndicData.Entites.ExerciceComptable;

#nullable enable

public abstract record CompteComptable(
    string IdentifiantCompte, 
    string Nom, 
    IEnumerable<OperationSurCompte> Operations);

public record CompteCoproprietaire : CompteComptable
{
    public CompteCoproprietaire(
        string reference,
        string nom,
        string prenom,
        IEnumerable<OperationSurCompte> operations,
        decimal soldeAnterieur) : base(
        string.IsNullOrWhiteSpace(reference) ? "REFERENCE ABSENTE" : reference, 
        string.IsNullOrWhiteSpace(prenom) ? nom : nom + " " + prenom, 
        operations)
    {
        SoldeAnterieur = soldeAnterieur;
    }

    public decimal SoldeAnterieur { get; }
}

public record CompteCopropriete : CompteComptable
{
    public CompteCopropriete(
        uint? identifiantComptable, 
        string nom, 
        IEnumerable<OperationSurCompte> operations,
        Solde soldeCopropriete) : base(
        identifiantComptable?.ToString() ?? "N° COMPTE NON RENSEIGNE", 
        nom, 
        operations.Append(new OperationSurCompte(soldeCopropriete.Date, "SOLDE COPROPRIETE", 
            null, 
            soldeCopropriete.Montant)))
    {
    }
}

public record OperationSurCompte(DateOnly Date, string Libelle, string? Tiers, decimal Montant);

public record Solde(DateOnly Date, decimal Montant);