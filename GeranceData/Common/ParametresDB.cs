using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;
using GeranceData.Entites;

namespace GeranceData.Common
{
    public class ParametresDB
    {
        static DataTable tableParametres = null;

        private static void Load()
        {
            if ( tableParametres == null )
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
        public static bool setParam1(string groupe, string code, string value)
        {
            String where = " where groupe = @groupe and code = @code";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("groupe", groupe),
                new NpgsqlParameter ("code", code),
            };
            ParametreEntite param = ParametreController.controller.getEntite(where, parameters);
            try
            {
                if (param == null)
                {
                    param = new ParametreEntite();
                    param.groupe = groupe;
                    param.code = code;
                }
                param.param_1 = value;
                ParametreController.controller.InsertOrUpdate(param);
                tableParametres = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }           

            return true;
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
        public static void FillComboFromParams(ComboBox cb, string groupe, string display = "code", string value = "iparam_1")
        {
            cb.DataSource = getComboData(groupe);
            cb.ValueMember = value;
            cb.DisplayMember = display;
        }

    }
}
