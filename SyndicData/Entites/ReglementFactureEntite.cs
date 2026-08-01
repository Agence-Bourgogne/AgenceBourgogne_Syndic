using System;

namespace SyndicData.Entites;

public class ReglementFactureEntite
{
    public string FactureId { get; }
    public DateOnly DateReglement { get; }
    public string Libelle { get; }
}