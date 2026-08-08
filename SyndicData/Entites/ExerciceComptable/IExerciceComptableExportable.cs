using System;
using System.Collections.Generic;

namespace SyndicData.Entites.ExerciceComptable;

public interface IExerciceComptableExportable
{
    string FactoryDisplayNameOfExercice();

    string Reference { get; }
    DateOnly DateDebut { get; }
    DateOnly DateFin { get; }
    string NomImmeuble { get; }
    string AdresseImmeuble { get; }
    IEnumerable<CompteComptable> FetchComptesComptables();
}