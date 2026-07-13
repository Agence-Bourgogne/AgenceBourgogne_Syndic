using System;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Common;

namespace SyndicData.Entites;

public class RepartIndividuelleEntite : AbstractBaseEntite
{
    public string saisie_id;
    public int type_saisie;
    public string operation_id;
    public string immeuble_id;
    public string lot_id;
    public string reference;
    public DateTime date_reference;
    public decimal global;
    public decimal ancien;
    public decimal nouveau;
    public decimal index;
    public decimal montant;
    public decimal statut;
    public int ref_cpt = 1;

    public RepartIndividuelleEntite()
    {
        id = "";
        setValues(null);
    }
    public RepartIndividuelleEntite(DataRow row)
    {
        id = "";
        setValues(row);
    }
    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("saisie_id", true, members));
        updatables.Add(new UpdateField("type_saisie", true, members));
        updatables.Add(new UpdateField("operation_id", true, members));
        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("lot_id", true, members));
        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("date_reference", true, members));
        updatables.Add(new UpdateField("global", true, members));
        updatables.Add(new UpdateField("ancien", true, members));
        updatables.Add(new UpdateField("nouveau", true, members));
        updatables.Add(new UpdateField("index", true, members));
        updatables.Add(new UpdateField("montant", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        updatables.Add(new UpdateField("ref_cpt", true, members));
        base.setValues(row);
    }
    public static RepartIndividuelleEntite setData(OperationEntite operation, SaisieFactureEntite saisie, DataRow oldRow)
    {
        var repart = new RepartIndividuelleEntite(oldRow)
        {
            saisie_id = saisie.id,
            type_saisie = (int) GlobalConstantes.TypeSaisie.Facture,
            immeuble_id = saisie.immeuble_id,
            reference = saisie.base_repart,
            operation_id = operation.id,
            date_reference = operation.date_reference,
            lot_id = operation.lot_id
        };


        return repart;
    }
    /*
    public static RepartIndividuelleEntite setData(OperationEntite operation, SaisieAppelFondEntite saisie, DataRow oldRow)
    {
        RepartIndividuelleEntite repart = new RepartIndividuelleEntite(oldRow);

        repart.saisie_id = saisie.id;
        repart.type_saisie = (int)GlobalConstantes.TypeSaisie.AppelDeFond;
        repart.immeuble_id = saisie.immeuble_id;
        repart.reference = saisie.base_repart;

        repart.operation_id = operation.id;
        repart.date_reference = operation.date_reference;
        repart.lot_id = operation.lot_id;

        return repart;
    }
     */
    public static RepartIndividuelleEntite setData(OperationEntite operation, RepartIndividuelleEntite oldRepart, GlobalConstantes.TypeSaisie type)
    {
        var repart = oldRepart ?? new RepartIndividuelleEntite();

        repart.saisie_id = operation.saisie_id;
        repart.type_saisie = (int)type; //GlobalConstantes.TypeSaisie.AppelDeFond;
        repart.immeuble_id = operation.immeuble_id;
        repart.reference = operation.base_repart;

        repart.operation_id = operation.id;
        repart.date_reference = operation.date_reference;
        repart.lot_id = operation.lot_id;

        return repart;
    }
        
}