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
            string cmd = String.Format("Select id, reference, document_type, date_document, libelle from {0} ", getSchemaTable());

            cmd += " where reference = @reference and document_type = @document_type ";

            cmd += String.Format(" order by date_document desc");

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("reference", reference),
                new NpgsqlParameter("document_type", document_type),
            };

            return getResultSQL(cmd, parameters);
        }
        public byte[] getImage(string id)
        {
            byte[] document = null;
            string cmd = String.Format("select document_image from {0} where id = @id", getSchemaTable());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("id", id),
            };

            DataTable table = getResultSQL(cmd, parameters);
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
