using System;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class LiasseController : AbstractBaseController<LiasseEntite>
    {
        static LiasseController controller = new LiasseController();
        public override string getTable()
        {
            return "liasse";
        }
        public static LiasseController getController()
        {
            //return new LiasseController();
            return controller;
        }
        public DataTable getLiasseActives(GlobalConstantes.TypeOperation type_ecriture, bool bAddNew = true)
        {
            var cmd = $"select * from {getSchemaTable()} ";
            cmd += " where type_ecriture = @type_ecriture and statut = @statut";
                                        //getSchemaTable());
                                        //, (int)type, (int)GlobalConstantes.StatutOperation.Actif);
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());

            adapter.SelectCommand.Parameters.AddWithValue("@type_ecriture", type_ecriture.ToString());
            adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Brouillon);

            var table = new DataTable();
            try
            {
                adapter.Fill(table);
                if ( bAddNew)
                {
                    var row = table.NewRow();
                    row["id"] = LiasseEntite.NOUVELLE_ID;
                    row["reference"] = LiasseEntite.NOUVELLE_DESI;
                    switch (type_ecriture)
                    {
                        case GlobalConstantes.TypeOperation.Facture:
                            row["montant"] = ParametresDB.getParam1("MONTANT_DEFAULT", "ECRITURE");
                            break;
                        case GlobalConstantes.TypeOperation.AppelDeFond:
                            row["montant"] = ParametresDB.getParam1("MONTANT_DEFAULT", "APPEL_FOND");
                            break;
                        case GlobalConstantes.TypeOperation.Tresorerie:
                            row["montant"] = ParametresDB.getParam1("MONTANT_DEFAULT", "TRESORERIE");
                            break;
                    }
                    row["type_ecriture"] = type_ecriture;
                    table.Rows.InsertAt(row, 0);
                }
                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        public DataTable GetLiassesValidees(GlobalConstantes.TypeOperation type_ecriture, string limit = "")
        {
            var cmd = $"select * from {getSchemaTable()} ";
            cmd += " where type_ecriture = @type_ecriture and statut = @statut";
            cmd += " order by audit_created desc ";
            if (limit != "")
                cmd += limit;
            //getSchemaTable());
            //, (int)type, (int)GlobalConstantes.StatutOperation.Actif);
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());

            adapter.SelectCommand.Parameters.AddWithValue("@type_ecriture", type_ecriture.ToString());
            adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Valide);

            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
