using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;

namespace GeranceData.Controller
{
    public class DocumentController : AbstractBaseController<DocumentEntite>
    {
        static DocumentController controller = new DocumentController();
        public override string getTable()
        {
            return "documents";
        }
        public static DocumentController getController()
        {
            return controller;
        }

        public DataTable getDocumentsListe(string reference, string document_type)
        {
            var cmd = $"Select id, reference, document_type, date_document, libelle from {getSchemaTable()} ";

            cmd += " where reference = @reference and document_type = @document_type ";

            cmd += String.Format(" order by date_document desc");

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("reference", reference),
                new NpgsqlParameter("document_type", document_type),
            };

            return getResultSQL(cmd, parameters);
        }
        public byte[] getImage(string id)
        {
            byte[] document = null;
            var cmd = $"select document_image from {getSchemaTable()} where id = @id";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("id", id),
            };

            var table = getResultSQL(cmd, parameters);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    document = (byte[]) table.Rows[0]["document_image"];
                }
            }
            return document;
        }
    }
}
