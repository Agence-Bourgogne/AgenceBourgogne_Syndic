using System;
using System.Collections.Generic;
using Npgsql;
using SyndicData.Entites;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Controller;
using SyndicData.Common;
namespace SyndicData.Controller
{
    public class LotDescriptionController : AbstractBaseController<LotDescriptionEntite>
    {
        static LotDescriptionController controller = new LotDescriptionController();
        public override string getTable()
        {
            return "lot_description";
        }
        public static LotDescriptionController getController()
        {
            return controller;
            //            return new LotDescriptionController();
        }
        public DataTable getDataGridListeLotDescription(ImmeubleEntite immeuble, bool bAddMontant = true, bool bAddValeur = true, bool bAddindex = false)
        {
            string cmd = String.Format("select @fields from {0} l  @join1 where l.immeuble_id = @immeuble_id order by numero_lot", getSchemaTable());
            string fields = "";

            if (bAddindex)
            {
                fields += "null as ancien, ";
                fields += "null as nouveau, ";
            }

            if (bAddValeur)
                fields += "null as index, ";

            if (bAddMontant)
                fields += "null as montant, ";

            fields += "l.id, numero_lot, l.coproprietaire_id, c.reference as coproprietaire, c.nom, c.prenom, ";
            fields += " numero_batiment, numero_escalier, numero_etage, avance, l.statut";
            string join1 = String.Format(" left join {0}.coproprietaire  C on (c.id = l.coproprietaire_id)", getSchema());

            cmd = cmd.Replace("@fields", fields);
            cmd = cmd.Replace("@join1", join1);
            Console.WriteLine(cmd);

            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble.id);
            try
            {
                adapter.Fill(table);
                return table;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public DataTable getDataGridListeLotDescriptionCpt(ImmeubleEntite immeuble, bool bAddMontant = true, bool bAddValeur = true, bool bAddindex = false)
        {
            string cmd = String.Format("select @fields from {0} l @join1 where l.immeuble_id = @immeuble_id order by numero_lot", getSchemaTable());
            string fields = "";

            fields += "null as ref_cpt, ";

            if (bAddindex)
            {
                fields += "null as ancien, ";
                fields += "null as nouveau, ";
            }

            if (bAddValeur)
                fields += "null as index, ";

            if (bAddMontant)
                fields += "null as montant, ";

            fields += "l.id, numero_lot, l.coproprietaire_id, c.reference as coproprietaire, c.nom, c.prenom, ";
            fields += " numero_batiment, numero_escalier, numero_etage, avance, l.statut";
            string join1 = String.Format(" left join {0}.coproprietaire  C on (c.id = l.coproprietaire_id)", getSchema());

            cmd = cmd.Replace("@fields", fields);
            cmd = cmd.Replace("@join1", join1);
            Console.WriteLine(cmd);

            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble.id);
            try
            {
                adapter.Fill(table);
                return table;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public DataTable createLotRepartition(ImmeubleEntite immeuble, int nblot)
        {
            TimestampServer = Database.GetTimestampServer();

            string cmd = String.Format("select coalesce(max(numero_lot),0) as valeur from {0} where immeuble_id = @immeuble_id", getSchemaTable());
            int numero_lot = 0;

            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble.id) });
            if (table.Rows.Count > 0)
                if (table.Rows[0] != null)
                    numero_lot = (int)table.Rows[0]["valeur"];

            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();
            LotRepartitionController ctl = LotRepartitionController.getController();
            ctl.setTimestampServer(TimestampServer);
            try
            {
                for (int i = 0; i < nblot; i++)
                {
                    LotDescriptionEntite lot_entite = new LotDescriptionEntite();
                    lot_entite.numero_lot = ++numero_lot;
                    lot_entite.immeuble_id = immeuble.id;
                    lot_entite.coproprietaire_id = "";
                    lot_entite.date_changement = TimestampServer;
                    lot_entite.numero_batiment = "";
                    lot_entite.numero_escalier = "";
                    lot_entite.numero_etage = "";
                    lot_entite.avance = 0;
                    lot_entite.statut = (int)GlobalConstantes.StatutData.Actif;

                    if (!doInsertOrUpdate(lot_entite))
                        throw new Exception("Lot Description");

                    // TODO A Revoir ces Repart Indiv
                    // createLotRepartition Individuelle

                    // TODO creer la colonne statut en DB
                    for (int b = 0; b < 8; b++)
                    {
                        LotRepartitionEntite rep_entite = new LotRepartitionEntite();
                        rep_entite.colonne = b;
                        rep_entite.ligne = 8;
                        rep_entite.reference = String.Format("{0}{1}", 8, b);
                        rep_entite.immeuble_id = immeuble.id;
                        rep_entite.lot_id = lot_entite.id;
                        rep_entite.type_ventilation = 1;
                        //rep_entite.statut = (int)GlobalConstantes.StatutData.Actif;
                        if (!ctl.doInsertOrUpdate(rep_entite))
                            throw new Exception("Lot Repartition");
                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
            return getDataGridListeLotDescription(immeuble, false, false, false);
        }
        public DataTable getImmeublesCoproprietaire(string coproprietaire_id)
        {
            string cmd = String.Format("select id, reference, nom from {0}.immeuble i ", getSchema());
            cmd += String.Format(" where i.id in (select immeuble_id from {0}.lot_description where coproprietaire_id = @coproprietaire_id ) ", getSchema());
            return getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@coproprietaire_id", coproprietaire_id) });
        }
        public List<ImmeubleEntite> getListImmeublesCoproprietaire(string coproprietaire_id)
        {
            List<ImmeubleEntite> listeImmeubles = new List<ImmeubleEntite>();
            string cmd = String.Format("select id, reference, nom from {0}.immeuble i ", getSchema());
            cmd += String.Format(" where i.id in (select immeuble_id from {0}.lot_description where coproprietaire_id = @coproprietaire_id ) ", getSchema());
            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@coproprietaire_id", coproprietaire_id) });
            if (table != null)
                foreach (DataRow row in table.Rows)
                    listeImmeubles.Add(new ImmeubleEntite(row));
            return listeImmeubles;
        }
        public DataTable getListeCoproprietaires(ImmeubleEntite immeuble)
        {
            if (immeuble == null)
                return null;
            string cmd = String.Format("select id, reference, concat(nom, ' ', prenom) as nom from {0}.coproprietaire c ", getSchema());
            cmd += String.Format(" where c.id in (select coproprietaire_id from {0}.lot_description ) ", getSchema());
            return getResultSQL(cmd);
        }
        public DataTable getListeLotCoproprietaires(ImmeubleEntite immeuble, CoproprietaireEntite copro = null)
        {
            if (immeuble == null) // || copro == null)
                return null;
            string cmd = "select l.id, l.numero_lot as reference, concat(c.nom, ' ', c.prenom ) as nom ";
            cmd += String.Format(" from {0}.lot_description l", getSchema());
            cmd += String.Format(" join  {0}.coproprietaire c on c.id = l.coproprietaire_id ", getSchema());
            //            cmd += String.Format(" ";
            cmd += " where l.immeuble_id = @immeuble_id ";
            cmd += " and l.statut = 1";
            cmd += " order by 2";
            if (copro != null)
                cmd += String.Format(" and and c.id = '{0}'", copro.id);
            return getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble.id) });
        }

        public DataTable getComboListeLotCoproprietaires(ImmeubleEntite immeuble, CoproprietaireEntite copro = null)
        {
            if (immeuble == null) // || copro == null)
                return null;
            string cmd = "select l.id, l.numero_lot as reference, concat(l.numero_lot, ' - ', c.nom, ' ', c.prenom ) as nom ";
            cmd += String.Format(" from {0}.lot_description l", getSchema());
            cmd += String.Format(" join  {0}.coproprietaire c on c.id = l.coproprietaire_id ", getSchema());
            //            cmd += String.Format(" ";
            cmd += " where l.immeuble_id = @immeuble_id and c.statut = @statut_actif";
            if (copro != null)
                cmd += String.Format(" and and c.id = '{0}'", copro.id);

            cmd += " order by 2";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@immeuble_id", immeuble.id) ,
                new NpgsqlParameter("@statut_actif", (int) GlobalConstantes.StatutData.Actif),
            };

            return getResultSQL(cmd, parameters);//new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble.id) });
        }

        public List<CoproprietaireEntite> getComboListeCoproprietaires(ImmeubleEntite immeuble, CoproprietaireEntite copro = null)
        {
            if (immeuble == null) // || copro == null)
                return null;
            string cmd = "select l.id, l.numero_lot as reference, concat(l.numero_lot, ' - ', c.nom, ' ', c.prenom ) as nom ";
            cmd += String.Format(" from {0}.lot_description l", getSchema());
            cmd += String.Format(" join  {0}.coproprietaire c on c.id = l.coproprietaire_id ", getSchema());
            //            cmd += String.Format(" ";
            cmd += " where l.immeuble_id = @immeuble_id and c.statut = @statut_actif";
            if (copro != null)
                cmd += String.Format(" and and c.id = '{0}'", copro.id);

            cmd += " order by 2";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@immeuble_id", immeuble.id) ,
                new NpgsqlParameter("@statut_actif", (int) GlobalConstantes.StatutData.Actif),
            };
            List<CoproprietaireEntite> liste = new List<CoproprietaireEntite>();
            DataTable table = getResultSQL(cmd, parameters);
            if (table != null)
                foreach (DataRow row in table.Rows)
                    liste.Add(new CoproprietaireEntite(row));
            return liste;
        }

        public DataTable getListeLot(string immeuble_id)
        {
            string cmd = String.Format("select * from {0} where immeuble_id = @immeuble_id", getSchemaTable());
            return getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id) });
        }
        public DataTable getListeLotFiscaux(string immeuble_id)
        {
            string cmd = String.Format("select * from {0} l join {1}.coproprietaire c on c.id = l.coproprietaire_id where l.immeuble_id = @immeuble_id and c.declaration=true", getSchemaTable(), getSchema());
            return getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id) });
        }
        public List<LotDescriptionEntite> getListeLotDescription(string immeuble_id)
        {
            string cmd = String.Format("select * from {0} where immeuble_id = @immeuble_id", getSchemaTable());
            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id) });
            List<LotDescriptionEntite> liste = new List<LotDescriptionEntite>();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    liste.Add(new LotDescriptionEntite(row));

            return liste;
        }
        public List<LotDescriptionEntite> getListeLotDescriptionFiscaux(string immeuble_id)
        {
            string cmd = String.Format("select * from {0} l join {1}.coproprietaire c on c.id = l.coproprietaire_id where immeuble_id = @immeuble_id and c.declaration=true", getSchemaTable(), getSchema());
            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id) });
            List<LotDescriptionEntite> liste = new List<LotDescriptionEntite>();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    liste.Add(new LotDescriptionEntite(row));

            return liste;
        }

        public DataTable getCoproprietairesImmeuble(string immeuble_id)
        {
            string cmd = String.Format("select * from {0} ", CoproprietaireController.getController().getSchemaTable());
            cmd += String.Format(" where id in ( select distinct(coproprietaire_id) from {0} where immeuble_id = @immeuble_id )", getSchemaTable());
            return getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id) });
        }
        public LotDescriptionEntite getLotFromReference(string immeuble_id, string numLot)
        {
            LotDescriptionEntite lot = null;
            int numlot = Convertir.ToInt(numLot);

            string cmd = String.Format("select * from {0} where immeuble_id = @immeuble_id and numero_lot = @numero_lot ", getSchemaTable());

            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble_id), new NpgsqlParameter("@numero_lot", numlot) });

            if (table != null)
                if (table.Rows.Count > 0)
                    lot = new LotDescriptionEntite(table.Rows[0]);
            return lot;
        }
        // TODO Quid des copro avec plusieurs lots
        public LotDescriptionEntite getLotFromCopro(string coproprietaire_id)
        {
            LotDescriptionEntite lot = null;

            string cmd = String.Format("select * from {0} where coproprietaire_id = @coproprietaire_id ", getSchemaTable());

            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@coproprietaire_id", coproprietaire_id) });

            if (table != null)
                if (table.Rows.Count > 0)
                    lot = new LotDescriptionEntite(table.Rows[0]);
            return lot;
        }
        public LotDescriptionEntite getLotFromCopro(string immeuble_id, string coproprietaire_id)
        {
            LotDescriptionEntite lot = null;

            string cmd = String.Format("select * from {0} where immeuble_id = @immeuble_id and coproprietaire_id = @coproprietaire_id ", getSchemaTable());

            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@coproprietaire_id", coproprietaire_id) 
            });

            if (table != null)
                if (table.Rows.Count > 0)
                    lot = new LotDescriptionEntite(table.Rows[0]);
            return lot;
        }
        public decimal getAvanceImmeuble(string immeuble_id)
        {
            decimal avance = 0;
            string cmd = String.Format(" select sum(avance) as avance from {0} where immeuble_id = @immeuble_id", getSchemaTable());
            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@immeuble_id", immeuble_id),
            });
            if (table != null)
                if (table.Rows.Count > 0)
                    avance = Convertir.ToDecimal(table.Rows[0]["avance"]);
            return avance;
        }

        public LotDescriptionEntite getLotFromRefImmeubleNumLot(string ref_imm, int numero_lot)
        {
            LotDescriptionEntite lot = null;

            string cmd = String.Format("select * from {0} ", getSchemaTable());
            cmd += String.Format(" join {0}.immeuble i on i.id = immeuble_id ", getSchema());
            cmd += " where i.reference = @ref_imm and numero_lot = @numero_lot";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@ref_imm", ref_imm),
                new NpgsqlParameter("@numero_lot", numero_lot),
            };
            DataTable table = getResultSQL(cmd, parameters);

            if (table != null)
                if (table.Rows.Count > 0)
                    lot = new LotDescriptionEntite(table.Rows[0]);
            return lot;
        }

    }
}
