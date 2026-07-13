using System;
using System.Collections.Generic;
using SyndicDocumentsData.Entities;
using SyndicDocumentsData.Models;
// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service" dans le code, le fichier svc et le fichier de configuration.
public class PartsFile
{
    public String Key = "";
    public byte[] Content;
    public PartsFile(string Key)
    {
        this.Key = Key;
    }
}
public class Service : IService
{
    static List<PartsFile> parts = new List<PartsFile>();

    public string CreateUser(string Code, String Password = "")
    {
        var msg = "";
        IDal dal = new Dal();
        msg = dal.CreateUser(Code, Password);
        return msg;
    }
    public string DeleteUser(string Guid)
    {
        var msg = "";
        IDal dal = new Dal();
        msg = dal.DeleteUser(Guid);
        return msg;
    }
    public string DeleteCopro(string Guid)
    {
        var msg = "";
        IDal dal = new Dal();
        msg = dal.DeleteCopro(Guid);
        return msg;
    }
    public void UploadPartFile(string Guid, byte[] filePart)
    {
        //Console.WriteLine("Uploaded file {0} with {1} bytes", fileName, totalBytesRead);
        PartsFile part = null;
        var offset = 0;
        if (parts.Exists(x => x.Key == Guid))
        {
            part = parts.Find(x => x.Key == Guid);
            offset = part.Content.Length;
            Array.Resize(ref part.Content, part.Content.Length + filePart.Length);
        }
        else
        {
            part = new PartsFile(Guid);
            part.Content = new byte[filePart.Length];
            parts.Add(part);
        }
        Buffer.BlockCopy(filePart, 0, part.Content, offset, filePart.Length);
    }
    public String CloseFile(string text, String Guid, string immeuble_id, string copro_id)
    {
        var resText = "";
        if (parts.Exists(x => x.Key == Guid))
        {
            try
            {
                var part = parts.Find(x => x.Key == Guid);
                IDal dal = new Dal();
                dal.CreateDocument(text, Guid, part.Content, immeuble_id, copro_id);
                resText = "Document Enregistré";
            }
            catch (Exception ex)
            {
                resText = ex.Message;
            }
        }
        else
            resText = "Guid Invalide";
        return resText;
    }
    public UserEntitie GetUserFromCode(String code)
    {
        IDal dal = new Dal();
        return dal.GetUserFromCode(code);
    }

    public UserEntitie GetUserFromGuid(String Guid)
    {
        IDal dal = new Dal();
        return dal.GetUserFromGuid(Guid);
    }
    public List<UserEntitie> GetAllUsers()
    {
        IDal dal = new Dal();
        return dal.GetAllUsers();
    }
    public List<ChildrenEntitie> GetUserCoproprietaires(string guid)
    {
        var childrens = new List<ChildrenEntitie>();
        IDal dal = new Dal();
        var user = dal.GetUserFromGuid(guid);
        if (user != null)
        {
            childrens = dal.GetUserChildrens(user.Guid);
        }
        return childrens;
    }

    public List<ChildrenEntitie> GetCoproChildrens(string copro_id)
    {
        var childrens = new List<ChildrenEntitie>();
        IDal dal = new Dal();
        childrens = dal.GetCoproChildrens(copro_id);
        return childrens;
    }

    public string AddCopro(string user_id, string immeuble_id, String copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom)
    {
        IDal dal = new Dal();
        return dal.AddCopro(user_id, immeuble_id, copro_id, reference_imm, adresse_imm, reference_copro, nom);
    }
    public bool Connected()
    {
        return true;
    }
    public string UpdateUser(string Guid, string Code, String Password = "")
    {
        var msg = "";
        IDal dal = new Dal();
        msg = dal.UpdateUser(Guid, Code, Password);
        return msg;
    }
    public List<DocumentEntitie> GetListDocuments(string immeuble_id = "", string copro_id ="")
    {
        IDal dal = new Dal();
        return dal.GetDocuments(immeuble_id, copro_id);
    }
    public string DeleteDocument(string Guid)
    {
        var msg = "";
        IDal dal = new Dal();
        msg = dal.DeleteDocument(Guid);
        return msg;
    }
    
}
