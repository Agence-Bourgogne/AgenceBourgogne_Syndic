using System;

namespace SyndicData.Entites.ExerciceComptable;

public record ExerciceComptableSelector(
    string IdExercice,
    string ReferenceImmeuble, 
    string ReferenceExercice,
    DateOnly DateDebutExercice, 
    DateOnly DateFinExercice) : IExerciceComptableExportable
{
    public string DisplayName => $"{ReferenceImmeuble} du {DateDebutExercice:O} au {DateFinExercice:O}";
    public string Id => IdExercice;
}