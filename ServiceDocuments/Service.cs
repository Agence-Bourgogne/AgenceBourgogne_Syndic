using System;
using System.Collections.Generic;
using System.Web.Hosting;
using SyndicDocumentsData.Entities;
using SyndicDocumentsData.Models;

namespace ServiceDocuments
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service" dans le code, le fichier svc et le fichier de configuration.
    public class PartsFile
    {
        public readonly string Key = "";
        public byte[] Content;
        public PartsFile(string Key)
        {
            this.Key = Key;
        }
    }
    public class Service : IService
    {
        private static readonly List<PartsFile> parts = new List<PartsFile>();

        public string CreateUser(string Code, string Password = "")
        {
            var msg = "";
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            msg = dal.CreateUser(Code, Password);
            return msg;
        }
        public string DeleteUser(string Guid)
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            var msg = dal.DeleteUser(Guid);
            return msg;
        }
        public string DeleteCopro(string Guid)
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            var msg = dal.DeleteCopro(Guid);
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
                part = new PartsFile(Guid)
                {
                    Content = new byte[filePart.Length]
                };
                parts.Add(part);
            }
            Buffer.BlockCopy(filePart, 0, part.Content, offset, filePart.Length);
        }
        public string CloseFile(string text, string Guid, string immeuble_id, string copro_id)
        {
            var resText = "";
            if (parts.Exists(x => x.Key == Guid))
            {
                try
                {
                    var part = parts.Find(x => x.Key == Guid);
                    IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
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
        public UserEntitie GetUserFromCode(string code)
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            return dal.GetUserFromCode(code);
        }

        public UserEntitie GetUserFromGuid(string Guid)
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            return dal.GetUserFromGuid(Guid);
        }
        public List<UserEntitie> GetAllUsers()
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            return dal.GetAllUsers();
        }
        public List<ChildrenEntitie> GetUserCoproprietaires(string guid)
        {
            var childrens = new List<ChildrenEntitie>();
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
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
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            childrens = dal.GetCoproChildrens(copro_id);
            return childrens;
        }

        public string AddCopro(string user_id, string immeuble_id, string copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom)
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            return dal.AddCopro(user_id, immeuble_id, copro_id, reference_imm, adresse_imm, reference_copro, nom);
        }
        public bool Connected()
        {
            return true;
        }
        public string UpdateUser(string Guid, string Code, string Password = "")
        {
            var msg = "";
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            msg = dal.UpdateUser(Guid, Code, Password);
            return msg;
        }
        public List<DocumentEntitie> GetListDocuments(string immeuble_id = "", string copro_id ="")
        {
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            return dal.GetDocuments(immeuble_id, copro_id);
        }
        public string DeleteDocument(string Guid)
        {
            var msg = "";
            IDal dal = new Dal(HostingEnvironment.ApplicationPhysicalPath);
            msg = dal.DeleteDocument(Guid);
            return msg;
        }
    
    }
}