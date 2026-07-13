using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using Console = System.Console;
using SyndicData.Entites;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class ImmeubleController : AbstractBaseController<ImmeubleEntite>
    {
        static ImmeubleController controller = new ImmeubleController();
        public override string getTable()
        {
            return "immeuble";
        }

        protected override bool doBeforeInsert(ImmeubleEntite entite)
        {
            return true;
        }
        public static ImmeubleController getController()
        {
//            return new ImmeubleController();
            return controller;
        }
        public ImmeubleController()
        {
            DefaultOrder = "reference";
        }
        public DataTable GetListeFromMonthCloture(string iMonths)
        {
            String cmd = String.Format("select * from {0} where extract(month from datecloture) in ({1}) And statut<>9 order by reference ", getSchemaTable(), iMonths);

            DataTable table = getResultSQL(cmd);
            return table;
        }
        public DataTable GetDescriptionCoproprietairesImmeubleAF(string immeuble_id, string numlot = "", bool isFiscal = false, string saisie_id = "")
        {
            string schema = getSchema();
            string cmd = "select";
            int numero_lot = 0;
            cmd += " i.reference, i.nom, i.rue, i.codepostal, i.ville, c.reference ref_copro, ";

            cmd += " c.nom as nom_copro, c.prenom as prenom, p.code codenvoi, c.adresse as adresse_copro, c.codepostal as cp_copro, concat(c.ville, ' ', c.pays ) as ville_copro, ";
            cmd += " c.nomcomp, c.adressecomp, c.villecomp, p2.code as codenvcomp, codecomp, ";
            cmd += " l.numero_lot,  c.id as copro_id, l.id as lot_id, i.id as immeuble_id";
            cmd += String.Format(" from {0} i ", getSchemaTable());
            cmd += String.Format(" join {0}.lot_description l on l.immeuble_id = i.id ", schema);
            cmd += String.Format(" join {0}.coproprietaire c on l.coproprietaire_id = c.id ", schema);
            cmd += String.Format(" left join ( select groupe, code , iparam_1 from parametres ) p on p.groupe = 'CIVILITE' and c.codenvoi = iparam_1");
            cmd += String.Format(" left join ( select groupe, code , iparam_1 from parametres ) p2 on p2.groupe='CODEENVOICOMPTE' and c.codenvcomp = p2.iparam_1");
            cmd += " where immeuble_id = @immeuble_id";
            if (numlot != "")
            {
                cmd += " and numero_lot = @numero_lot";
                numero_lot = System.Convert.ToInt32(numlot);
            }
            if ( saisie_id != "" )
            {
                cmd += String.Format(" and c.id in (select coproprietaire_id from {0}.operation where saisie_id = @saisie_id) ", schema);
            }
            if (isFiscal)
                cmd += " and c.declaration = true";
            cmd += " order by c.reference ";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@saisie_id", saisie_id),
                new NpgsqlParameter("@numero_lot", numero_lot),
            };


            DataTable table = getResultSQL(cmd, parameters);
            return table;

        }
        public DataTable GetDescriptionCoproprietairesImmeubleReleveIndividuel(string immeuble_id, string numlot = "", bool isFiscal = false)
        {
            string schema = getSchema();
            string cmd = "select";
            int numero_lot = 0;
            cmd += " i.reference, i.nom, i.rue, i.codepostal, i.ville, c.reference ref_copro, ";
            cmd += " c.nom as nom_copro, c.prenom as prenom, coalesce(p.code, '') as codenvoi, c.adresse as adresse_copro, c.codepostal as cp_copro, concat(c.ville, ' ', c.pays) as ville_copro, ";
            cmd += " l.numero_lot, c.id as copro_id, l.id as lot_id, i.id as immeuble_id, round(l.avance::numeric,2) as avance, l.statut";
            cmd += String.Format(" from {0} i ", getSchemaTable());
//            cmd += String.Format(" join {0}.lot_description l on l.immeuble_id = i.id and l.statut=1 ", schema);
            cmd += String.Format(" join {0}.lot_description l on l.immeuble_id = i.id ", schema);
  
            cmd += String.Format(" join {0}.coproprietaire c on l.coproprietaire_id = c.id ", schema);
            cmd += String.Format(" left join ( select groupe, code , iparam_1 from parametres ) p on p.groupe = 'CIVILITE' and c.codenvoi = iparam_1");
            cmd += " where immeuble_id = @immeuble_id";
            if (numlot != "")
            {
                cmd += " and numero_lot = @numero_lot";
                numero_lot = System.Convert.ToInt32(numlot);
            }
            if (isFiscal)
                cmd += " and c.declaration = true";
            cmd += " order by c.reference ";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@numero_lot", numero_lot),
            };

            //Console.WriteLine(cmd);
            DataTable table = getResultSQL(cmd, parameters);
            return table;
        }


        public DataTable GetDescriptionCoproprietairesImmeuble( string immeuble_id , string numlot = "", bool isFiscal = false )
        {
            string schema = getSchema();
            string  cmd  = "select";
            int numero_lot = 0;
            cmd +=  " i.reference, i.nom, i.rue, i.codepostal, i.ville, c.reference ref_copro, ";
            cmd += " c.nom as nom_copro, c.prenom as prenom, coalesce(p.code, '') as codenvoi, c.adresse as adresse_copro, c.codepostal as cp_copro, concat(c.ville, '\n', c.pays) as ville_copro, ";
            //cmd += " case when coalesce(c.nomcomp, '') != '' then c.nomcomp else c.nom end as nom_copro, ";
            //cmd += " case when coalesce(c.nomcomp, '') != '' then '' else c.prenom end as prenom, ";
            //cmd += " case when coalesce(c.nomcomp, '') != '' then p2.code else p.code end as codenvoi, ";
            //cmd += " case when coalesce(c.nomcomp, '') != '' then c.adressecomp else c.adresse end as adresse_copro, ";
            //cmd += " case when coalesce(c.nomcomp, '') != '' then c.codecomp else c.codepostal end as cp_copro, ";
            //cmd += " case when coalesce(c.nomcomp, '') != '' then c.villecomp else c.ville end as ville_copro, ";

            cmd += " l.numero_lot, c.id as copro_id, l.id as lot_id, i.id as immeuble_id, round(l.avance::numeric,2) as avance";
            cmd += String .Format ( " from {0} i ", getSchemaTable());
//            cmd += String.Format ( " join {0}.lot_description l on l.immeuble_id = i.id ", schema);
            cmd += String.Format(" join {0}.lot_description l on l.immeuble_id = i.id and l.statut=1 ", schema);
            cmd += String.Format(" join {0}.coproprietaire c on l.coproprietaire_id = c.id ", schema);
            cmd += String.Format(" left join ( select groupe, code , iparam_1 from parametres ) p on p.groupe = 'CIVILITE' and c.codenvoi = iparam_1");
            //cmd += String.Format(" left join ( select groupe, code , iparam_1 from parametres ) p2 on p2.groupe='CODEENVOICOMPTE' and c.codenvcomp = p2.iparam_1");
            cmd += " where immeuble_id = @immeuble_id";
            if (numlot != "")
            {
                cmd += " and numero_lot = @numero_lot";
                numero_lot = System.Convert.ToInt32(numlot);
            }
            if (isFiscal)
                cmd += " and c.declaration = true";
            cmd += " order by c.reference ";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@numero_lot", numero_lot),
            };

            Console.WriteLine(cmd);
            DataTable table = getResultSQL(cmd, parameters);
            return table;
        }

        public ImmeubleEntite getImmeubleFromCopro(string copro_id)
        {
            ImmeubleEntite immeuble = null;

            string cmd = String.Format(" select i.* from {0} i", getSchemaTable());
            cmd += String.Format(" join {0}.lot_description ld on ld.immeuble_id = i.id ", getSchema() );
            cmd += " where ld.coproprietaire_id = @copro_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@copro_id", copro_id),
            };


            DataTable table = getResultSQL(cmd, parameters);

            if ( table != null)
                if (table.Rows.Count > 0)
                {
                    immeuble = new ImmeubleEntite(table.Rows[0]);
                }

            return immeuble;
        }
    }
}
