using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Controller;
using System.Data;
using GeranceData.Controller;
using GeranceData.Entites;
using SyndicData.Controller;
using SyndicData.Entites;
using System.Threading;
namespace Gerance.Formulaires.Syndic
{
    class SyndicDatabase
    {
        static NpgsqlConnection connection;
        static string connexionString;
        public static Dictionary<String, LotDescriptionEntite> SyndicProprio = new Dictionary<String, LotDescriptionEntite>();
//        static bool bLoaded = false;
        public static NpgsqlConnection GetInstance()
        {
            if (connection == null)
            {
                connexionString = Database.getConnexionString(Gerance.GeranceApplication.SYNDIC_APPLICATION);
                try
                {
                    connection = new NpgsqlConnection(connexionString);
                    connection.Open();
                }
                catch (NpgsqlException)
                {
                    connection = null;
                }
            }
            return connection;
        }
        public static void StartLoadSyndicCopro()
        {
            SyndicProprio.Clear();
            var iCnxSyndic =  CommonRegistry.getRegistryValue(Gerance.GeranceApplication.SYNDIC_APPLICATION, "Database", "ConnexionSyndic", 0);
            if ((int) iCnxSyndic == 1)
            {
                BackgroundWorker worker = new BackgroundWorker();
                Thread threadSyndic = new Thread(SyndicDatabase.LoadSyndicCopro);
                threadSyndic.Start();
            }
        }
        static void LoadSyndicCopro()
        {

            if (!ConnexionValide())
                return;

            DataTable table = BienController.getController().getListeBienLocatif();

            LotDescriptionController.cnx = CoproprietaireController.cnx = GetInstance();
            
            foreach (DataRow row in table.Rows)
            {
                BienEntite bien = new BienEntite(row);
                LotDescriptionEntite lot = LotDescriptionController.getController().getLotFromRefImmeubleNumLot(bien.reference, bien.numero_lot);
                if (lot != null)
                {
                    //Console.WriteLine("{0} : {1:000} {2,-30} => {3,-30} : {4, -30} {5} {6} {7}", bien.reference, bien.numero_lot, bien.Proprietaire.NomPrenom+ " ("+bien.Proprietaire.reference +")", bien.Locataire.NomPrenom, lot.Coproprietaire.NomPrenom, bien.Locataire.id, bien.Locataire.reference, lot.Coproprietaire.reference);
                    SyndicProprio.Add(bien.Locataire.id, lot);
                }
            }
//            bLoaded = true;
        }
        public static bool ConnexionValide()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
            NpgsqlConnection cnx = GetInstance();
            DateTime dt = Database.GetTimestampServer(cnx);
            return (cnx != null);
        }
        public static LotDescriptionEntite getSyndicCoproLot(string locataire_id)
        {
            LotDescriptionEntite lot = null;
            SyndicProprio.TryGetValue(locataire_id, out lot);
            return lot;
        }
        public static String getListLocatairesId()
        {
            List<String> ids = SyndicProprio.Keys.ToList();
            string strIds = Database.ToQuotedString(ids);
            return strIds;
        }
    }
}
