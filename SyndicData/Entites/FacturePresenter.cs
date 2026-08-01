using System;

namespace SyndicData.Entites;

public record FacturePresenter
{
    public string NomLiasse { get; init; }
    public string NomImmeuble { get; init; }
    public string ReferenceImmeuble { get; init; }
    public string NomFournisseur { get; init; }
    public DateOnly DateFacture { get; init; }
    public decimal MontantFacture { get; init; }
}