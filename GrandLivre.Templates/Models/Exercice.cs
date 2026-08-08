using SyndicData.Entites.ExerciceComptable;

namespace GrandLivre.Templates.Models;

public record Exercice(Copropriete Copropriete, DateOnly Debut, DateOnly Fin, string Reference, IEnumerable<CompteComptable> Comptes);