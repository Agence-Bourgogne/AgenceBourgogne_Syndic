using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;

namespace GeranceData.Controller
{
    public class RegulChargeController : AbstractBaseController<RegulChargeEntite>
    {
        static RegulChargeController controller = new RegulChargeController();
        public override string getTable()
        {
            return "regul_charges";
        }
        public static RegulChargeController getController()
        {
            return controller;
        }
        public DataTable getDataFromRegul(string locataire_id, DateTime dtDeb, DateTime dtFin)
        {
            string cmd = String.Format("select * from {0} where locataire_id =@locataire_id and date_saisie >= @dtdeb and date_saisie <= @dtFin", getSchemaTable());

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("locataire_id", locataire_id),
            };
            return getResultSQL(cmd, parameters);
        }
        
    }
}
