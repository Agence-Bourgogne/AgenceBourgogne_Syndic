using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using Gerance.Formulaires.Common;
using GeranceData.Entites;
using GeranceData.Controller;
namespace Gerance.Formulaires.Natures
{
    public partial class NatureFicheForm : BaseFicheForm
    {
        NatureEntite nature;
        public NatureFicheForm()
        {
            InitializeComponent();
        }
        public NatureFicheForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                nature = (NatureEntite)entite;
            else
                nature = new NatureEntite();

            currentReference = nature.reference;

            tbReference.Text = nature.reference;
            tbNom.Text = nature.nom;
            tbPart.Text = nature.charge_locative.ToString(); ;
            tbDeclaration.Text = nature.declaration;
            tbRefComptable.Text = nature.reference_comptabilite;
            base.setFicheValues(nature);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return NatureController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return NatureController.getController().getEntite(where);
        }
        protected override bool saveValue()
        {
            nature.reference = tbReference.Text;
            nature.nom = tbNom.Text;
            nature.charge_locative = Convertir.ToInt(tbPart.Text);
            nature.declaration = tbDeclaration.Text;
            nature.reference_comptabilite = tbRefComptable.Text;
            nature.statut = 1;
            return NatureController.getController().InsertOrUpdate(nature);
        }
        protected void ShowFindFromReference()
        {
            if (DialogResult.OK == ShowFindForm(new NatureFindForm(), tbReference))
            {
                nature = NatureController.getController().getEntiteFromField("reference", tbReference.Text);
                setFicheValues(nature);
            }
            else
                setFicheValues(nature);
        }

    }
}
