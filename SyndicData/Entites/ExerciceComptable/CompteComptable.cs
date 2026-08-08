using System;
using System.Collections.Generic;

namespace SyndicData.Entites.ExerciceComptable;

#nullable enable

public abstract record CompteComptable(
    uint IdentifiantComptable, 
    string Nom, 
    IEnumerable<OperationSurCompte> Operations,
    Solde Solde,
    bool CompteCoproprietaire);

public record CompteCoproprietaire : CompteComptable
{
    public CompteCoproprietaire(
        ushort reference,
        string nom,
        string prenom,
        IEnumerable<OperationSurCompte> operations,
        decimal soldeAnterieur,
        Solde soldeBilan) : base(reference, nom + " " + prenom, operations, soldeBilan, true)
    {
        SoldeAnterieur = soldeAnterieur;
    }

    public decimal SoldeAnterieur { get; init; }
}

public record CompteCopropriete : CompteComptable
{
    public CompteCopropriete(
        uint identifiantComptable, 
        string nom, 
        IEnumerable<OperationSurCompte> operations,
        Solde soldeCopropriete) : base(identifiantComptable, nom, operations, soldeCopropriete, false)
    {
    }
}

public record OperationSurCompte(DateOnly Date, string Libelle, string? Tiers, decimal Montant);

public record Solde(DateOnly Date, decimal Montant);