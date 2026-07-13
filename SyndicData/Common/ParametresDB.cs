using System;
using System.Linq;
//using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
namespace SyndicData.Common
{
    public class ParametresDB
    {
        static DataTable tableParametres = null;

        private static void Load()
        {
//            if ( tableParametres == null )
            {
                tableParametres = new DataTable();
                String cmd = "select * from parametres order by groupe, code";
                try 
	            {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
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
            DataRow row = get(groupe, code);
            if (row != null)
                return row["param_1"].ToString();
            return default_value;
        }
        public static DataTable getComboData(String groupe, string code = "") 
        {
            DataTable table = new DataTable();
            String cmd = "";
            if (code != "")
                cmd = "select * from parametres where groupe = @groupe and code=@code order by groupe, iparam_1";
            else
                cmd = "select * from parametres where groupe = @groupe order by groupe, iparam_1";
            try
            {
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                NpgsqlCommand sqlCmd = new NpgsqlCommand(cmd, Database.GetInstance());
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
        public static void bindGridComboColumn(DataGridViewColumnCollection cols, String group, string columnName)
        {
            if ( cols[columnName + "_cb"] == null )
            {
                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.DataSource = getComboData(group);
                cmb.DisplayMember = "code";
                cmb.ValueMember = "iparam_1";
                //cmb.Name = columnName;
                cmb.DataPropertyName = columnName;
                cmb.Name = columnName + "_cb";
                cmb.HeaderText = columnName;
                int idx = cols[columnName].Index;
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
            bool bCompteur = false;
            string bases = getParam1("BASES", "COMPTEURS");
            if (bases != null)
            {
                String[] base_compteur = bases.Replace(" ", "").Split(',');
                if (base_compteur.Contains(baseToCheck))
                    bCompteur = true;
            }
            return bCompteur;
        }
        //protected static void getBasesCompteurs()
        //{
        //    string bases = ParametresDB.getParam1("BASES", "COMPTEURS");
        //    if (bases != null)
        //    {
        //        base_compteur = bases.Replace(" ", "").Split(',');
        //    }
        //}

    }
}
