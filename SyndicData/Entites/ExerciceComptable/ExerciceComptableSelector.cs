using SyndicData.Controller;
using System;
using System.Collections.Generic;

namespace SyndicData.Entites.ExerciceComptable;

public class ExerciceComptableSelector : IExerciceComptableExportable
{
    private readonly string _idExercice;
    private readonly ExerciceComptableController _controller;

    public ExerciceComptableSelector(
        string idExercice,
        string referenceImmeuble, 
        string adresseImmeuble,
        string referenceExercice,
        DateOnly dateDebutExercice, 
        DateOnly dateFinExercice,
        ExerciceComptableController controller)
    {
        _idExercice = idExercice;
        _controller = controller;
        DateDebut = dateDebutExercice;
        DateFin = dateFinExercice;
        Reference = referenceExercice;
        NomImmeuble = referenceImmeuble;
        AdresseImmeuble = adresseImmeuble;
    }

    public string FactoryDisplayNameOfExercice() => $"{NomImmeuble} du {DateDebut:O} au {DateFin:O}";

    public string Reference { get; }
    public DateOnly DateDebut { get; }
    public DateOnly DateFin { get; }
    public string NomImmeuble { get; }
    public string AdresseImmeuble { get; }
    public IEnumerable<CompteComptable> FetchComptesComptables() => _controller.FetchComptesComptablesFor(_idExercice);
}