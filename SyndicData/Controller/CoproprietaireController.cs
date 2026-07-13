using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using SyndicData.Entites;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using CommonProjectsPartners.Entites;
namespace SyndicData.Controller
{
    public class CoproprietaireController : AbstractBaseController<CoproprietaireEntite>
    {
        static CoproprietaireController controller = new CoproprietaireController();
        public override string getTable(){
            return "coproprietaire";
        }
        public static CoproprietaireController getController()
        {
            return controller;
            //return new CoproprietaireController();
        }
        public CoproprietaireController()
        {
            DefaultOrder = "reference";
        }
       
        public override DataTable GetFindList(string filter)
        {
            String order = DefaultOrder;
            string cmd = String.Format("Select id, reference, concat(nom, ' ', prenom) as nom , concat(nomcomp) as Gerant from {0} ", getSchemaTable());
            if (filter != "")
                cmd += " where " + filter;
            cmd += String.Format(" order by {0}", order);
            return getResultSQL(cmd);
        }
        public DataTable GetFindListStatut(string filter)
        {
            String order = DefaultOrder;
            string cmd = String.Format("Select id, reference, concat(nom, ' ', prenom) as nom , concat(nomcomp) as Gerant, statut from {0} ", getSchemaTable());
            if (filter != "")
                cmd += " where " + filter;
            cmd += String.Format(" order by {0}", order);
            return getResultSQL(cmd);
        }
        
        public DataTable GetListCopro(string filter)
        {
            String order = DefaultOrder;
            string cmd = String.Format("Select id, reference, trim(email) as trimmed_email, concat(nom, ' ', prenom) as nom , concat(nomcomp) as Gerant from {0} ", getSchemaTable());
            cmd += " where " + filter;
            cmd += String.Format("  And statut = {0}", (int)AbstractBaseEntite.StatutEntite.Actif);
            cmd += String.Format(" order by {0}", order);
            return getResultSQL(cmd);
        }
        protected override void setListSelectCommand()
        {
            String order = DefaultOrder;

            string cmd = String.Format("select i.reference as ref_immeuble, c.*, '' as titre, '' as poste from {0} c", getSchemaTable());
            cmd += String.Format(" join {0}.lot_description ld on c.id = ld.coproprietaire_id ", getSchema());
            cmd += String.Format(" join {0}.immeuble i on i.id = ld.immeuble_id ", getSchema());
            cmd += String.Format ( " order by {0} ", order);
            adapter.SelectCommand = new NpgsqlCommand(cmd , Database.GetInstance());
        }
        public DataTable GetListCopro(bool bFiltre = true)
        {
            String order = DefaultOrder;
            //select i.reference as ref_immeuble, c.*, '' as titre, '' as poste from agence.coproprietaire c join agence.lot_description ld on c.id = ld.coproprietaire_id  join agence.immeuble i on i.id = ld.immeuble_id 
            string cmd = String.Format("select i.reference as ref_immeuble, c.*, '' as titre, '' as poste from {0} c", getSchemaTable());
            cmd += String.Format(" join {0}.lot_description ld on c.id = ld.coproprietaire_id ", getSchema());
            cmd += String.Format(" join {0}.immeuble i on i.id = ld.immeuble_id ", getSchema());
            if ( bFiltre)
                cmd += String.Format("  where c.statut = {0}", (int) AbstractBaseEntite.StatutEntite.Actif);

            cmd += String.Format(" order by {0} ", order);
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return table;
        }

        public DataTable getListeCoproForExport(bool bQuote = false)
        {
            string cmd;
            if (bQuote)
                cmd = " select concat('''',i.reference) as immeuble, concat('''',c.reference) as reference, c.nom, c.prenom, ";
            else
                cmd = " select i.reference as immeuble, c.reference as reference, c.nom, c.prenom, ";
            cmd += " regexp_replace(adresse, E'[\\n\\r]+', ' ', 'g'), ";
            cmd += " c.codepostal, c.ville,c.telephone,c.email, ";
            cmd += " nomcomp as agence, ";
            cmd += " regexp_replace(adressecomp, E'[\\n\\r]+', ' ', 'g') as \"Adresse Agence\",";
            cmd += " villecomp as \"Ville Agence\", codecomp as \"CP Agence\",";
            cmd += " t.code as \"Titre\", p.code as \"Poste\" ";
            cmd += String.Format(" from {0} c", getSchemaTable());
            cmd += String.Format(" join {0}.lot_description ld on c.id = ld.coproprietaire_id ", getSchema());
            cmd += String.Format(" join {0}.immeuble i on i.id = ld.immeuble_id ", getSchema());
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) t ON t.iparam_1 = c.codenvoi ";
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE_POSTE')) p ON p.iparam_1 = c.codenvoi ";
            cmd += " where c.statut <> 9";
            cmd += " order by c.reference";
            return getResultSQL(cmd);
        }
        public DataTable CoproprietaireImmeubleDescription(string immeuble_id , bool bByNom = false, string limit = "")
        {
            string cmd = "SELECT p.code, c.nom, c.reference, c.prenom, c.adresse , c.codepostal, concat(c.ville, '\n', c.pays) as ville, c.id AS copro_id, d.immeuble_id, i.reference AS imm_reference, i.nom AS imm_nom, ";
            cmd += " i.rue AS imm_rue, i.ville AS imm_ville, i.codepostal AS imm_codepostal, r.valeur, d.numero_lot";
            cmd += String.Format(" FROM {0}.lot_description d  ", getSchema());
            cmd += String.Format(" INNER JOIN {0}.coproprietaire c ON d.coproprietaire_id = c.id ", getSchema() );
            cmd += String.Format(" INNER JOIN (SELECT  id, immeuble_id, lot_id, reference, valeur, ligne, colonne, type_ventilation FROM {0}.lot_repartition", getSchema());
            cmd += " WHERE (reference = '10')) r ON d.id = r.lot_id ";
            cmd += " INNER JOIN agence.immeuble i ON d.immeuble_id = i.id ";
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi ";
            cmd += " WHERE (d.immeuble_id = @immeuble_id) ";
            //if (numlot != "")
            //{
            //    cmd += " and numero_lot = @numero_lot ";
            //    numero_lot = System.Convert.ToInt32(numlot);
            //}
            if ( bByNom)
                cmd += " ORDER BY c.nom ";
            else
                cmd += " ORDER BY c.reference ";

            cmd += limit;
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                //new NpgsqlParameter("@numero_lot", numero_lot),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public DataTable CoproprietaireImmeubleDescriptionByLot(string immeuble_id, string numlot, bool bByNom = false, string limit = "")
        {
            int numero_lot = -1;
            string cmd = "SELECT p.code, c.nom, c.reference, c.prenom, c.adresse , c.codepostal, concat(c.ville, '\n', c.pays) as ville, c.id AS copro_id, d.immeuble_id, i.reference AS imm_reference, i.nom AS imm_nom, ";
            cmd += " i.rue AS imm_rue, i.ville AS imm_ville, i.codepostal AS imm_codepostal, r.valeur, d.numero_lot";
            cmd += String.Format(" FROM {0}.lot_description d  ", getSchema());
            cmd += String.Format(" INNER JOIN {0}.coproprietaire c ON d.coproprietaire_id = c.id ", getSchema());
            cmd += String.Format(" INNER JOIN (SELECT  id, immeuble_id, lot_id, reference, valeur, ligne, colonne, type_ventilation FROM {0}.lot_repartition", getSchema());
            cmd += " WHERE (reference = '10')) r ON d.id = r.lot_id ";
            cmd += " INNER JOIN agence.immeuble i ON d.immeuble_id = i.id ";
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi ";
            cmd += " WHERE (d.immeuble_id = @immeuble_id) ";
            if (numlot != "")
            {
                numero_lot = System.Convert.ToInt32(numlot);
                cmd += " and numero_lot = @numero_lot ";
            }
            if (bByNom)
                cmd += " ORDER BY c.nom ";
            else
                cmd += " ORDER BY c.reference ";

            cmd += limit;
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
            };
            if (numlot != "" && numero_lot != -1)
            {
                parameters.Add(new NpgsqlParameter("@numero_lot", numero_lot));
            }
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }


        public DataTable CoproprietaireImmeubleDescriptionEtiquettes(string immeuble_id, bool bByNom = false, string limit = "")
        {
            string cmd = "SELECT p.code, c.nom, c.reference, c.prenom, replace(c.adresse, '\r\n',' ') as adresse , c.codepostal, concat(c.ville, '\n', c.pays) as ville, c.id AS copro_id, d.immeuble_id, i.reference AS imm_reference, i.nom AS imm_nom, ";
            cmd += " i.rue AS imm_rue, i.ville AS imm_ville, i.codepostal AS imm_codepostal, r.valeur, d.numero_lot";
            cmd += String.Format(" FROM {0}.lot_description d  ", getSchema());
            cmd += String.Format(" INNER JOIN {0}.coproprietaire c ON d.coproprietaire_id = c.id ", getSchema());
            cmd += String.Format(" INNER JOIN (SELECT  id, immeuble_id, lot_id, reference, valeur, ligne, colonne, type_ventilation FROM {0}.lot_repartition", getSchema());
            cmd += " WHERE (reference = '10')) r ON d.id = r.lot_id ";
            cmd += " INNER JOIN agence.immeuble i ON d.immeuble_id = i.id ";
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi ";
            cmd += " WHERE (d.immeuble_id = @immeuble_id) ";
            //if (numlot != "")
            //{
            //    cmd += " and numero_lot = @numero_lot ";
            //    numero_lot = System.Convert.ToInt32(numlot);
            //}
            if (bByNom)
                cmd += " ORDER BY c.nom ";
            else
                cmd += " ORDER BY c.reference ";

            cmd += limit;
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                //new NpgsqlParameter("@numero_lot", numero_lot),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public DataTable HeaderConvocationWord(string immeuble_id, NpgsqlParameter[] static_parameters = null)
        {
            string schema = getSchema();
            string cmd = " Select ";
            cmd += "'' as Civilite, '' as Coproprietaire, '' as ReferenceCoproprietaire, \n";
            cmd += "'' AdresseCoproprietaire, '' as VilleCoproprietaire, '' as CodePostalCoproprietaire,\n";
            cmd += " i.reference as ReferenceImmeuble, i.nom as NomImmeuble,\n";
            cmd += " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, '' as NumeroLot, ir.valeur as valeur \n";

            if (static_parameters != null)
            {
                foreach (NpgsqlParameter parameter in static_parameters)
                {
                    cmd += String.Format(", @{0} as {0} ", parameter.ParameterName);
                }
            }

            cmd += String.Format(" FROM {0}.lot_description l  \n", schema);
            cmd += String.Format(" INNER JOIN {0}.coproprietaire c ON l.coproprietaire_id = c.id \n", schema);
            cmd += String.Format(" INNER JOIN {0}.immeuble i ON l.immeuble_id = i.id \n", schema);
            cmd += String.Format(" INNER JOIN {0}.immeuble_repartition ir ON (ir.immeuble_id = i.id and ligne=1 and colonne=0)\n", schema);
            cmd += String.Format(" INNER JOIN {0}.lot_repartition r ON r.lot_id = l.id and r.reference= '10'\n", schema);
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi \n";
            cmd += " WHERE (l.immeuble_id = @immeuble_id) ";
            cmd += " ORDER BY c.reference LIMIT 1";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
            };
            if (static_parameters != null)
                parameters.AddRange(static_parameters);

            return getResultSQL(cmd, parameters);
        }

        public DataTable CoproprietaireImmeubleDescriptionWord(string immeuble_id, NpgsqlParameter[] static_parameters = null)
        {
            string schema = getSchema();
            string cmd = " Select ";
            cmd += "p.code as Civilite, concat(c.nom , ' ', prenom) as Coproprietaire, c.reference as ReferenceCoproprietaire, \n";
            cmd += "c.adresse as AdresseCoproprietaire, c.ville as VilleCoproprietaire, c.codepostal as CodePostalCoproprietaire,\n";
            cmd += " i.reference as ReferenceImmeuble, i.nom as NomImmeuble,\n";
            cmd += " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, l.numero_lot as NumeroLot, r.valeur as valeur \n";
//            cmd += " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, l.numero_lot as NumeroLot, r.valeur\n";

            if (static_parameters != null) 
            {
                foreach (NpgsqlParameter parameter in static_parameters)
                {
                    cmd += String.Format(", @{0} as {0} ", parameter.ParameterName);
                }
            }

            cmd += String.Format(" FROM {0}.lot_description l  \n", schema);
            cmd += String.Format(" INNER JOIN {0}.coproprietaire c ON l.coproprietaire_id = c.id \n", schema);
            cmd += String.Format(" INNER JOIN {0}.immeuble i ON l.immeuble_id = i.id \n", schema);
            cmd += String.Format(" INNER JOIN {0}.immeuble_repartition ir ON ir.immeuble_id = i.id and ir.reference='10'\n", schema);
            cmd += String.Format(" INNER JOIN {0}.lot_repartition r ON r.lot_id = l.id and r.reference= '10'\n", schema);
            cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi \n";
            cmd += " WHERE (l.immeuble_id = @immeuble_id) AND l.statut = @statut_actif";
            cmd += " ORDER BY c.nom ";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@statut_actif", (int) GlobalConstantes.StatutData.Actif),
            };
            if (static_parameters != null)
                parameters.AddRange(static_parameters);

            return getResultSQL(cmd, parameters);
        }

        public bool MiseAjourDateRelances(string copro_ids, DateTime daterel, int type)
        {
            string cmd = String.Format("update {0} ", getSchemaTable());
            switch ( type )
            {
                case 0:
                    cmd += " set daterel1 = @daterel , daterel2 = null, daterel3 = null";
                    break;
                case 1:
                    cmd += " set daterel2 = @daterel , daterel3 = null";
                    break;
                default:
                    cmd += " set daterel3 = @daterel ";
                    break;
            }
            cmd += String.Format(" where id in ({0})", copro_ids);

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@daterel", daterel),
            };
            //Console.WriteLine(cmd.Replace("@daterel", daterel.ToString()));
            return ExecuteNonQuery(cmd, parameters);
        }
        public bool resetDatesRelance()
        {
            string cmd = String.Format("update {0} set daterel1 = null, daterel2=null, daterel3 = null where id in ", getSchemaTable() );
            cmd += String.Format(" (select coproprietaire_id from {0}.operation o ", getSchema() );
            cmd += " where o.statut = @statut and type_mouvement = @mouvement ";
            cmd += " group by 1 having sum(credit) - sum(debit) >= 0 ) ";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@mouvement", GlobalConstantes.TypeMouvement.Recette.ToString()),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Valide),
            };

            return ExecuteNonQuery(cmd, parameters);
        }
        public bool resetDatesRelance(String coproRef)
        {
            string cmd = String.Format("update {0} set daterel1 = null, daterel2=null, daterel3 = null where reference = @coproref ", getSchemaTable());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@coproref", coproRef),
            };

            return ExecuteNonQuery(cmd, parameters);
        }
    }
}
