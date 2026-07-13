namespace SyndicData.Common;

public static class GlobalConstantes
{
    public enum StatutOperation { Brouillon, Valide, Comptabilise, vide3, vide4, vide5, vide6, vide7, Cloture, Supprime }
    public enum StatutData { Inactif, Actif, Valide, vide3, vide4, vide5, vide6, vide7, vide8, Supprime }
    public enum TypeOperation { Facture, Tresorerie, AppelDeFond, SoldeBilan }
    public enum TypeRepartition { Millieme, Individuelle }
    public enum TypeSaisie { Facture, AppelDeFond, Reglement }
    public enum TypeMouvement { Recette, Depense }
    public enum StatutBudget { Brouillard, A_Voter, Approuve, vide3, vide4, vide5, vide6, vide7, vide8, Supprime }
    public enum StatutExercice { Ouvert, Clos, vide2, vide3, vide4, vide5, vide6, vide7, vide8, Supprime }
}