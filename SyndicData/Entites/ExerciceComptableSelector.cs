using System;

namespace SyndicData.Entites;

public record ExerciceComptableSelector(
    string IdExercice,
    string ReferenceImmeuble, 
    string ReferenceExercice,
    DateOnly DateDebutExercice, 
    DateOnly DateFinExercice);