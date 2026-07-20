using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Npgsql;

namespace CommonProjectsPartners.Utils;

public static class Database
{
    private static NpgsqlConnection connection;
    public static DateTime NullDate = new(1970, 1, 1);

    public static string getConnexionString(string application)
    {
        return (string)CommonRegistry.getRegistryValue(application, "Database", "ConnectionDb");
    }

    public static void setConnexionString(string application, string value)
    {
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
            try
            {
                connection = new NpgsqlConnection(getConnexionString(CommonRegistry.getCurrentApp()));
                connection.Open();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(@"Erreur de connexion : " + e.Message);
                connection = null;
            }

        return connection;
    }

    public static DateTime GetTimestampServer(NpgsqlConnection cnx = null)
    {
        if (cnx == null)
            cnx = GetInstance();
        var sqlCmd = new NpgsqlCommand("select localtimestamp", cnx);
        var response = sqlCmd.ExecuteScalar();
        return Convert.ToDateTime(response);
    }

    public static void SerializeCSV(DataTable sourceTable, TextWriter writer, bool includeHeaders = true)
    {
        if (includeHeaders)
        {
            var headerValues = new List<string>();
            foreach (DataColumn column in sourceTable.Columns) headerValues.Add(QuoteValue(column.ColumnName));
            writer.WriteLine(string.Join(";", headerValues.ToArray()));
        }

        foreach (DataRow row in sourceTable.Rows)
        {
            var items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();

            var line = string.Join(";", items);
            writer.WriteLine(line);
        }

        writer.Flush();
    }

    private static string QuoteValue(string value)
    {
        return string.Concat("\"", value.Replace("\"", "\"\""), "\"");
    }
}