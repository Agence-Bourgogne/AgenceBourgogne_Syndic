using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using Npgsql;


namespace SyndicData.Common;

public static class ParametresDB
{
    private static DataTable tableParametres;

    private static void Load()
    {
        {
            tableParametres = new DataTable();
            const string cmd = "select * from parametres order by groupe, code";
            try 
            {
                var adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
                adapter.Fill(tableParametres);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }           
        }
    }
    public static DataRow get(string groupe, string code)
    {
        Load();
        foreach (DataRow currRow in tableParametres.Rows)
        {
            if ( currRow["groupe"].ToString() == groupe)
                if (currRow["code"].ToString() == code)
                {
                    return currRow;
                }
        }
        return null;
    }
    public static string getParam1(string groupe, string code, string default_value = "")
    {
        var row = get(groupe, code);
        if (row != null)
            return row["param_1"].ToString();
        return default_value;
    }
    public static DataTable getComboData(string groupe, string code = "") 
    {
        var table = new DataTable();
        var cmd = "";
        if (code != "")
            cmd = "select * from parametres where groupe = @groupe and code=@code order by groupe, iparam_1";
        else
            cmd = "select * from parametres where groupe = @groupe order by groupe, iparam_1";
        try
        {
            var adapter = new NpgsqlDataAdapter();
            var sqlCmd = new NpgsqlCommand(cmd, Database.GetInstance());
            adapter.SelectCommand = sqlCmd;
            sqlCmd.Parameters.AddWithValue("@groupe", groupe);
            sqlCmd.Parameters.AddWithValue("@code", code);
            adapter.Fill(table);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }           
        return table;
    }
    public static void bindGridComboColumn(DataGridViewColumnCollection cols, string group, string columnName)
    {
        if ( cols[columnName + "_cb"] == null )
        {
            var cmb = new DataGridViewComboBoxColumn();
            cmb.DataSource = getComboData(group);
            cmb.DisplayMember = "code";
            cmb.ValueMember = "iparam_1";
            cmb.DataPropertyName = columnName;
            cmb.Name = columnName + "_cb";
            cmb.HeaderText = columnName;
            var idx = cols[columnName].Index;
            cols.Insert(idx, cmb);
            cols[columnName].Visible = false;
        }
    }
    public static void FillComboFromParams(ComboBox cb, string groupe, string display = "code", string value = "iparam_1")
    {
        cb.DataSource = getComboData(groupe);
        cb.ValueMember = value;
        cb.DisplayMember = display;
    }

    public static bool IsBaseCompteur(string baseToCheck)
    {
        var bCompteur = false;
        var bases = getParam1("BASES", "COMPTEURS");
        if (bases != null)
        {
            var base_compteur = bases.Replace(" ", "").Split(',');
            if (base_compteur.Contains(baseToCheck))
                bCompteur = true;
        }
        return bCompteur;
    }
}