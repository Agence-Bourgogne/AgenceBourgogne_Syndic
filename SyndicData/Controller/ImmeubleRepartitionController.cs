using System;
using System.Collections.Generic;
using Npgsql;
using SyndicData.Entites;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class ImmeubleRepartitionController : AbstractBaseController<ImmeubleRepartitionEntite>
    {
        static ImmeubleRepartitionController controller = new ImmeubleRepartitionController();
        public string specific_schema = "";
        public override string getTable()
        {
            return "immeuble_repartition";
        }

        public static ImmeubleRepartitionController getController()
        {
            //return new ImmeubleRepartitionController();
            return controller;
        }

        static public string keyRepart(int ligne, int colonne)
        {
            return $"{ligne}{colonne}";
        }
        public DataTable getRepartitionImmeuble(string immeuble_id/*, string immeuble_reference*/)
        {
            adapter.SelectCommand = new NpgsqlCommand(
                $"select * from {getSchemaTable()} where immeuble_id=@immeuble_id and statut=@statut order by ligne, colonne", Database.GetInstance());
            var table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble_id);
            adapter.SelectCommand.Parameters.AddWithValue("@statut", (int) GlobalConstantes.StatutData.Actif);

            try
            {
                var immeuble_repart = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public ImmeubleRepartitionEntite getRepartitionImmeubleEntite(string immeuble_id)
        {
            var repart = getRepartitionImmeuble(immeuble_id);
            return new ImmeubleRepartitionEntite(repart.Rows[0]);
        }

        // TODO A Revoir
        public int getTypeVentilation(int ligne)
        {
            return ligne < 8 ? 0 : 1;
        }

        public bool HaveRepartitionIndividuelle(string immeuble_id)
        {
            var valeur = 0;
            var cmd = $"select coalesce(count(*),0)::integer as valeur  from {getSchemaTable()} ";
            cmd += " where immeuble_id = @immeuble_id and ligne = 8 ";

            var table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id) });
            if (table != null)
            {
                valeur = (int)table.Rows[0]["valeur"] ;
            }
            return valeur > 0;
        } 
        public bool SaveRepartitionImmeuble(ImmeubleEntite immeuble_entite, DataGridView grid)
        {
            var rc = false;
            specific_schema = immeuble_entite.reference;
            TimestampServer = Database.GetTimestampServer();
            var cnx = Database.GetInstance();
            var trx = cnx.BeginTransaction();

            try
            {
                var bIndiv = HaveRepartitionIndividuelle(immeuble_entite.id);
                foreach (DataGridViewRow rowGrid in grid.Rows)
                {
                    foreach (DataGridViewTextBoxCell cell in rowGrid.Cells)
                    {
                        if (cell.ColumnIndex == 0)
                            continue;
                        var entite_repart = (ImmeubleRepartitionEntite)cell.Tag;
                        var value = 0;
                        if (cell.Value.ToString() != "" && cell.Value.ToString() != "*")
                            value = Convert.ToInt32(cell.Value);
                        if (entite_repart == null)
                        {
                            if (value != 0)
                            {
                                entite_repart = new ImmeubleRepartitionEntite();
                                entite_repart.immeuble_id = immeuble_entite.id;
                                entite_repart.nom = "";
                                entite_repart.reference = keyRepart(cell.RowIndex + 1, cell.ColumnIndex - 1);
                                entite_repart.ligne = cell.RowIndex + 1;
                                entite_repart.colonne = cell.ColumnIndex - 1;
                                entite_repart.type_ventilation = getTypeVentilation(cell.RowIndex + 1);
                            }
                        }
                        if (entite_repart != null)
                        {
                            if (entite_repart.valeur != value)
                            {
                                entite_repart.valeur = value;
                                if (!doInsertOrUpdate(entite_repart))
                                    throw new Exception("Repartition Millieme");
                            }
                        }
                    }
                }
                if ( !bIndiv )
                    for (var i = 0; i < 8; i++)
                    {
                        var entite_repart = new ImmeubleRepartitionEntite();
                        entite_repart.immeuble_id = immeuble_entite.id;
                        entite_repart.nom = "";
                        entite_repart.reference = keyRepart(8, i);
                        entite_repart.ligne = 8;
                        entite_repart.colonne = i;
                        entite_repart.type_ventilation = getTypeVentilation(8);
                        if (!doInsertOrUpdate(entite_repart))
                            throw new Exception("Repartition Individuelle");
                    }
                rc = true;
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                rc = false;
                MessageBox.Show(ex.Message);                    
            }
            return rc;
        }
        public bool ExistRepartitionReference(string immeuble_id, string reference )
        {
            var bExist = false;
            var cmd =
                $"select immeuble_id, reference from {getSchemaTable()} where immeuble_id=@immeuble_id and reference = @reference";

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@reference", reference)
            };

            var table = getResultSQL(cmd, parameters);
            if (table.Rows.Count > 0)
                bExist = true;
            return bExist;
        }
        public ImmeubleRepartitionEntite getRepartFromImmeubleBase(string immeuble_id, string base_ref)
        {
            adapter.SelectCommand = new NpgsqlCommand(
                $"select * from {getSchemaTable()} where immeuble_id=@immeuble_id and reference = @reference", Database.GetInstance());
            var table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble_id);
            adapter.SelectCommand.Parameters.AddWithValue("@reference", base_ref);

            try
            {
                var immeuble_repart = new DataTable();
                adapter.Fill(table);

                if ( table.Rows.Count > 0 )
                    return new ImmeubleRepartitionEntite(table.Rows[0]);

                return null;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
