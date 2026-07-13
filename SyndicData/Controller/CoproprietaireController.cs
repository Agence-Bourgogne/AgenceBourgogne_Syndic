using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class CoproprietaireController : AbstractBaseController<CoproprietaireEntite>
{
    private static readonly CoproprietaireController controller = new();
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
        var order = DefaultOrder;
        var cmd =
            $"Select id, reference, concat(nom, ' ', prenom) as nom , concat(nomcomp) as Gerant from {getSchemaTable()} ";
        if (filter != "")
            cmd += " where " + filter;
        cmd += $" order by {order}";
        return getResultSQL(cmd);
    }
    public DataTable GetFindListStatut(string filter)
    {
        var order = DefaultOrder;
        var cmd =
            $"Select id, reference, concat(nom, ' ', prenom) as nom , concat(nomcomp) as Gerant, statut from {getSchemaTable()} ";
        if (filter != "")
            cmd += " where " + filter;
        cmd += $" order by {order}";
        return getResultSQL(cmd);
    }
        
    public DataTable GetListCopro(string filter)
    {
        var order = DefaultOrder;
        var cmd =
            $"Select id, reference, trim(email) as trimmed_email, concat(nom, ' ', prenom) as nom , concat(nomcomp) as Gerant from {getSchemaTable()} ";
        cmd += " where " + filter;
        cmd += $"  And statut = {(int)AbstractBaseEntite.StatutEntite.Actif}";
        cmd += $" order by {order}";
        return getResultSQL(cmd);
    }
    protected override void setListSelectCommand()
    {
        var order = DefaultOrder;

        var cmd = $"select i.reference as ref_immeuble, c.*, '' as titre, '' as poste from {getSchemaTable()} c";
        cmd += $" join {getSchema()}.lot_description ld on c.id = ld.coproprietaire_id ";
        cmd += $" join {getSchema()}.immeuble i on i.id = ld.immeuble_id ";
        cmd += $" order by {order} ";
        adapter.SelectCommand = new NpgsqlCommand(cmd , Database.GetInstance());
    }
    public DataTable GetListCopro(bool bFiltre = true)
    {
        var order = DefaultOrder;
        //select i.reference as ref_immeuble, c.*, '' as titre, '' as poste from agence.coproprietaire c join agence.lot_description ld on c.id = ld.coproprietaire_id  join agence.immeuble i on i.id = ld.immeuble_id 
        var cmd = $"select i.reference as ref_immeuble, c.*, '' as titre, '' as poste from {getSchemaTable()} c";
        cmd += $" join {getSchema()}.lot_description ld on c.id = ld.coproprietaire_id ";
        cmd += $" join {getSchema()}.immeuble i on i.id = ld.immeuble_id ";
        if ( bFiltre)
            cmd += $"  where c.statut = {(int)AbstractBaseEntite.StatutEntite.Actif}";

        cmd += $" order by {order} ";
        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        var table = new DataTable();
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
        cmd += $" from {getSchemaTable()} c";
        cmd += $" join {getSchema()}.lot_description ld on c.id = ld.coproprietaire_id ";
        cmd += $" join {getSchema()}.immeuble i on i.id = ld.immeuble_id ";
        cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) t ON t.iparam_1 = c.codenvoi ";
        cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE_POSTE')) p ON p.iparam_1 = c.codenvoi ";
        cmd += " where c.statut <> 9";
        cmd += " order by c.reference";
        return getResultSQL(cmd);
    }
    public DataTable CoproprietaireImmeubleDescription(string immeuble_id , bool bByNom = false, string limit = "")
    {
        var cmd = "SELECT p.code, c.nom, c.reference, c.prenom, c.adresse , c.codepostal, concat(c.ville, '\n', c.pays) as ville, c.id AS copro_id, d.immeuble_id, i.reference AS imm_reference, i.nom AS imm_nom, ";
        cmd += " i.rue AS imm_rue, i.ville AS imm_ville, i.codepostal AS imm_codepostal, r.valeur, d.numero_lot";
        cmd += $" FROM {getSchema()}.lot_description d  ";
        cmd += $" INNER JOIN {getSchema()}.coproprietaire c ON d.coproprietaire_id = c.id ";
        cmd +=
            $" INNER JOIN (SELECT  id, immeuble_id, lot_id, reference, valeur, ligne, colonne, type_ventilation FROM {getSchema()}.lot_repartition";
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
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id)
            //new NpgsqlParameter("@numero_lot", numero_lot),
        };
        Console.WriteLine(cmd);
        return getResultSQL(cmd, parameters);
    }

    public DataTable CoproprietaireImmeubleDescriptionByLot(string immeuble_id, string numlot, bool bByNom = false, string limit = "")
    {
        var numero_lot = -1;
        var cmd = "SELECT p.code, c.nom, c.reference, c.prenom, c.adresse , c.codepostal, concat(c.ville, '\n', c.pays) as ville, c.id AS copro_id, d.immeuble_id, i.reference AS imm_reference, i.nom AS imm_nom, ";
        cmd += " i.rue AS imm_rue, i.ville AS imm_ville, i.codepostal AS imm_codepostal, r.valeur, d.numero_lot";
        cmd += $" FROM {getSchema()}.lot_description d  ";
        cmd += $" INNER JOIN {getSchema()}.coproprietaire c ON d.coproprietaire_id = c.id ";
        cmd +=
            $" INNER JOIN (SELECT  id, immeuble_id, lot_id, reference, valeur, ligne, colonne, type_ventilation FROM {getSchema()}.lot_repartition";
        cmd += " WHERE (reference = '10')) r ON d.id = r.lot_id ";
        cmd += " INNER JOIN agence.immeuble i ON d.immeuble_id = i.id ";
        cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi ";
        cmd += " WHERE (d.immeuble_id = @immeuble_id) ";
        if (numlot != "")
        {
            numero_lot = Convert.ToInt32(numlot);
            cmd += " and numero_lot = @numero_lot ";
        }
        if (bByNom)
            cmd += " ORDER BY c.nom ";
        else
            cmd += " ORDER BY c.reference ";

        cmd += limit;
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id)
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
        var cmd = "SELECT p.code, c.nom, c.reference, c.prenom, replace(c.adresse, '\r\n',' ') as adresse , c.codepostal, concat(c.ville, '\n', c.pays) as ville, c.id AS copro_id, d.immeuble_id, i.reference AS imm_reference, i.nom AS imm_nom, ";
        cmd += " i.rue AS imm_rue, i.ville AS imm_ville, i.codepostal AS imm_codepostal, r.valeur, d.numero_lot";
        cmd += $" FROM {getSchema()}.lot_description d  ";
        cmd += $" INNER JOIN {getSchema()}.coproprietaire c ON d.coproprietaire_id = c.id ";
        cmd +=
            $" INNER JOIN (SELECT  id, immeuble_id, lot_id, reference, valeur, ligne, colonne, type_ventilation FROM {getSchema()}.lot_repartition";
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
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id)
            //new NpgsqlParameter("@numero_lot", numero_lot),
        };
        Console.WriteLine(cmd);
        return getResultSQL(cmd, parameters);
    }

    public DataTable HeaderConvocationWord(string immeuble_id, NpgsqlParameter[] static_parameters = null)
    {
        var schema = getSchema();
        var cmd = " Select ";
        cmd += "'' as Civilite, '' as Coproprietaire, '' as ReferenceCoproprietaire, \n";
        cmd += "'' AdresseCoproprietaire, '' as VilleCoproprietaire, '' as CodePostalCoproprietaire,\n";
        cmd += " i.reference as ReferenceImmeuble, i.nom as NomImmeuble,\n";
        cmd += " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, '' as NumeroLot, ir.valeur as valeur \n";

        if (static_parameters != null)
        {
            foreach (var parameter in static_parameters)
            {
                cmd += string.Format(", @{0} as {0} ", parameter.ParameterName);
            }
        }

        cmd += $" FROM {schema}.lot_description l  \n";
        cmd += $" INNER JOIN {schema}.coproprietaire c ON l.coproprietaire_id = c.id \n";
        cmd += $" INNER JOIN {schema}.immeuble i ON l.immeuble_id = i.id \n";
        cmd +=
            $" INNER JOIN {schema}.immeuble_repartition ir ON (ir.immeuble_id = i.id and ligne=1 and colonne=0)\n";
        cmd += $" INNER JOIN {schema}.lot_repartition r ON r.lot_id = l.id and r.reference= '10'\n";
        cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi \n";
        cmd += " WHERE (l.immeuble_id = @immeuble_id) ";
        cmd += " ORDER BY c.reference LIMIT 1";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id)
        };
        if (static_parameters != null)
            parameters.AddRange(static_parameters);

        return getResultSQL(cmd, parameters);
    }

    public DataTable CoproprietaireImmeubleDescriptionWord(string immeuble_id, NpgsqlParameter[] static_parameters = null)
    {
        var schema = getSchema();
        var cmd = " Select ";
        cmd += "p.code as Civilite, concat(c.nom , ' ', prenom) as Coproprietaire, c.reference as ReferenceCoproprietaire, \n";
        cmd += "c.adresse as AdresseCoproprietaire, c.ville as VilleCoproprietaire, c.codepostal as CodePostalCoproprietaire,\n";
        cmd += " i.reference as ReferenceImmeuble, i.nom as NomImmeuble,\n";
        cmd += " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, l.numero_lot as NumeroLot, r.valeur as valeur \n";
//            cmd += " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, l.numero_lot as NumeroLot, r.valeur\n";

        if (static_parameters != null) 
        {
            foreach (var parameter in static_parameters)
            {
                cmd += string.Format(", @{0} as {0} ", parameter.ParameterName);
            }
        }

        cmd += $" FROM {schema}.lot_description l  \n";
        cmd += $" INNER JOIN {schema}.coproprietaire c ON l.coproprietaire_id = c.id \n";
        cmd += $" INNER JOIN {schema}.immeuble i ON l.immeuble_id = i.id \n";
        cmd += $" INNER JOIN {schema}.immeuble_repartition ir ON ir.immeuble_id = i.id and ir.reference='10'\n";
        cmd += $" INNER JOIN {schema}.lot_repartition r ON r.lot_id = l.id and r.reference= '10'\n";
        cmd += " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi \n";
        cmd += " WHERE (l.immeuble_id = @immeuble_id) AND l.statut = @statut_actif";
        cmd += " ORDER BY c.nom ";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut_actif", (int) GlobalConstantes.StatutData.Actif)
        };
        if (static_parameters != null)
            parameters.AddRange(static_parameters);

        return getResultSQL(cmd, parameters);
    }

    public bool MiseAjourDateRelances(string copro_ids, DateTime daterel, int type)
    {
        var cmd = $"update {getSchemaTable()} ";
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
        cmd += $" where id in ({copro_ids})";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@daterel", daterel)
        };
        //Console.WriteLine(cmd.Replace("@daterel", daterel.ToString()));
        return ExecuteNonQuery(cmd, parameters);
    }
    public bool resetDatesRelance()
    {
        var cmd = $"update {getSchemaTable()} set daterel1 = null, daterel2=null, daterel3 = null where id in ";
        cmd += $" (select coproprietaire_id from {getSchema()}.operation o ";
        cmd += " where o.statut = @statut and type_mouvement = @mouvement ";
        cmd += " group by 1 having sum(credit) - sum(debit) >= 0 ) ";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@statut", (int) GlobalConstantes.StatutOperation.Valide)
        };

        return ExecuteNonQuery(cmd, parameters);
    }
    public bool resetDatesRelance(string coproRef)
    {
        var cmd =
            $"update {getSchemaTable()} set daterel1 = null, daterel2=null, daterel3 = null where reference = @coproref ";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@coproref", coproRef)
        };

        return ExecuteNonQuery(cmd, parameters);
    }
}