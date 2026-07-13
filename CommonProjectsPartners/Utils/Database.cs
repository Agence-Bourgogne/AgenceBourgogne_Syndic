using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace CommonProjectsPartners.Utils
{
    public class Database
    {
        private static NpgsqlConnection connection = null;
        public static DateTime NullDate = new DateTime(1970, 1, 1);
        public static string getConnexionString(string application)
        {
            return (string) CommonRegistry.getRegistryValue(application, "Database", "ConnectionDb");
            //string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\Database", application);
            //return (string)Registry.GetValue(strKey, "ConnectionDb", null);
        }

        public static void setConnexionString(string application, string value)
        {
            //string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\Database", application);
            //Registry.SetValue(strKey, "ConnectionDb", value);
            CommonRegistry.setRegistryValue(application, "Database", "ConnectionDb", value);
        }

        public static void CommitTransaction(object trx)
        {
            ((NpgsqlTransaction)trx).Commit();
        }
        public static void RollBackTransaction(object trx)
        {
            ((NpgsqlTransaction)trx).Rollback();
        }
        public static NpgsqlTransaction BeginTransaction()
        {
            var cnx = GetInstance();
            return cnx.BeginTransaction();
        }
        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }
        public static NpgsqlConnection GetInstance()
        {
            if (connection == null)
            {
                try
                {
                    connection = new NpgsqlConnection(getConnexionString(CommonRegistry.getCurrentApp()));
                    connection.Open();
                }
                catch (NpgsqlException e)
                {
                    MessageBox.Show("Erreur de connexion : "+ e.Message);
                    connection = null;
                }
            }
            return connection;
        }
        
        public static DateTime GetTimestampServer(NpgsqlConnection cnx = null)
        {
            if ( cnx == null )
                cnx = GetInstance();
            var sqlCmd = new NpgsqlCommand("select localtimestamp", cnx );
            var response = sqlCmd.ExecuteScalar();
            return Convert.ToDateTime(response);
        }
        
        public static void SerializeCSV(DataTable sourceTable, TextWriter writer, bool includeHeaders = true, bool bEncoding = false) 
        {
            if (includeHeaders) {
                var headerValues = new List<string>();
                foreach (DataColumn column in sourceTable.Columns) {
                    headerValues.Add(QuoteValue(column.ColumnName));
                }
                writer.WriteLine(String.Join(";", headerValues.ToArray()));
            }

            string[] items = null;
            foreach (DataRow row in sourceTable.Rows) {
                items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();

                var line = String.Join(";", items);
                //if (bEncoding)
                //{
                //    Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                //    Encoding utf8 = Encoding.UTF8;
                //    byte[] utfBytes = utf8.GetBytes(line);
                //    byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);

                //}
                writer.WriteLine(line);
            }

            writer.Flush();
        }

        private static string QuoteValue(string value) 
        {
            return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
        }
        public static string ToQuotedString(List<string> values)
        {
            var quoted = "";

            foreach ( var value in values)
            {
                quoted += (quoted == "" ? "" : ", ") + $"'{value}'";
            }
            return quoted;
        }
        public static DataTable CSV2DataTable(string fileName, int skipLine = 0, bool firstRowHeader = true)
        {
            var table = new DataTable();
            var lines = ReadLines(fileName);


            // First Record after skip is columns names
            if (firstRowHeader)
            {
                var colHeaders = lines.ElementAt(skipLine).Split(';');
                foreach (var colName in colHeaders)
                {
                    table.Columns.Add(colName.ToString());
                }
            }
            else
            {
                var colHeaders = lines.ElementAt(skipLine + 1).Split(';');
                var i = 0;
                foreach (var colName in colHeaders)
                {
                    table.Columns.Add("col"+i.ToString());
                    i++;
                }
            }

            foreach (var record in lines.Skip (skipLine+1))
            {
                table.Rows.Add(record.Split(';'));
            }
            return table;
        }
        public static IEnumerable<string> ReadLines(string fileName)
        {
            StreamReader reader = null;
            var lines = new List<string>();
            try
            {
                reader = new StreamReader(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            if ( reader != null )
            {
                while (!reader.EndOfStream)
                    lines.Add(reader.ReadLine());
            }
            reader.Close();
            return lines;
        }
    }
}
