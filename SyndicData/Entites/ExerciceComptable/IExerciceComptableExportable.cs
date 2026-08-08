using System;

namespace SyndicData.Entites.ExerciceComptable;

public interface IExerciceComptableExportable
{
    string FactoryDisplayNameOfExercice();

    string Reference { get; }
    DateOnly DateDebut { get; }
    DateOnly DateFin { get; }
    string NomImmeuble { get; }
    string AdresseImmeuble { get; }

    GrandLivreData FetchAllData();
}