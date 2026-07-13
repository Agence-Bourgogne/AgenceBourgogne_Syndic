using System;
using System.Collections.Generic;
using System.Linq;
using SyndicDocumentsData.Entities;

namespace SyndicDocumentsData.Models
{
    public class Dal : IDal
    {
        string apPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
       
        private BddContext bdd;
        public Dal()
        {
            bdd = new BddContext();

        }

        public string UpdateUser(string Guid, string CodeUser, String password = "")
        {
            var msg = "";
            if (password == "")
                password = "ChangeIt";
            var user = GetUserFromGuid(Guid);
            if (user != null)
            {
                try
                {
                    user.Code = CodeUser;
                    user.Password = password;
                    user.audit_updated = DateTime.Now;
//                    bdd.Users.Add(new UserEntitie { Code = CodeUser, Password = password });
                    bdd.SaveChanges();
                    msg = "0";
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            else
                msg = "Code utilisateur in  existant";
            //            if ( bdd.User)
            return msg;
        }
        public string CreateUser(string CodeUser, String password = "")
        {
            var msg = "";
            if (password == "")
                password = "ChangeIt";
            var user = GetUserFromCode(CodeUser);
            if ( user == null)
            {
                try 
	            {	        
		            bdd.Users.Add(new UserEntitie {Code=CodeUser, Password = password});
                    bdd.SaveChanges();
                    msg = "0";
	            }
	            catch (Exception ex)
	            {
                    msg = ex.Message;		
	            }            
            }
            else
                msg = "Code utilisateur existant";
//            if ( bdd.User)
            return msg;
        }

        public string DeleteUser(String Guid)
        {
            var msg = "";
            var user = GetUserFromGuid(Guid);
            if (user != null)
            {
                try
                {
                    var childrens = GetUserChildrens(user.Guid);
                    if ( childrens.Count > 0 )
                        bdd.Childrens.RemoveRange(childrens);

                    bdd.Users.Remove(user);
                    bdd.SaveChanges();
                    msg = "0";
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            else
                msg = "Uilisateur inexistant";
            return msg;
        }

        public String DeleteCopro(String Guid)
        {
            var msg = "";
            var copro = GetCoproFromGuid(Guid);
            if ( copro != null )
            {
                var docs = GetDocumentsFromCopro(Guid);
                if ( docs.Count > 0)
                    bdd.Documents.RemoveRange(docs);
                var childrens = GetCoproChildrens(Guid);
                if (childrens.Count > 0)
                    bdd.Childrens.RemoveRange(childrens);
                bdd.Coproprietaires.Remove(copro);
                bdd.SaveChanges();
                msg = "0";
            }
            return msg;
        }

        public List<DocumentEntitie> GetDocuments(string immeuble_id = "", string copro_id = "")
        {
            if (string.IsNullOrEmpty(immeuble_id) && string.IsNullOrEmpty(copro_id))
            {
                return bdd.Documents.ToList();
            }
            else if (!string.IsNullOrEmpty(immeuble_id) && string.IsNullOrEmpty(copro_id))
            {
                return bdd.Documents.Where(x => x.immeuble_id == immeuble_id).ToList();
            }
            else if (!string.IsNullOrEmpty(immeuble_id) && !string.IsNullOrEmpty(copro_id))
            {
                return bdd.Documents.Where(x => x.immeuble_id == immeuble_id && x.copro_id == copro_id).ToList(); ;
            }
            else
                return new List<DocumentEntitie>();
        }

        public void CreateDocument(string text, String Guid, byte[] content, string immeuble_id, string copro_id)
        {
            var list = (from d in bdd.Documents where (d.text == text && d.immeuble_id == immeuble_id && d.copro_id == copro_id) select d);
            if (list.Count() > 0)
            {
                var doc = list.First();
                if (doc != null )
                {
                    doc.content = content;
                    doc.audit_updated = DateTime.Now;
                }
            }
            else
                bdd.Documents.Add(new DocumentEntitie(text, Guid, content, immeuble_id, copro_id));
            bdd.SaveChanges();
        }
        public List<UserEntitie> GetAllUsers()
        {
            return bdd.Users.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
        public UserEntitie GetUserFromCode(String code)
        {
            var user = (from u in bdd.Users where (u.Code.ToLower() == code.ToLower()) select u);
            if ( user.Count() > 0)
                return user.First();
            return null;
        }
        public UserEntitie GetUserFromGuid(String Guid)
        {
            var user = ( from u in bdd.Users where ( u.Guid == Guid) select u);
            if (user.Count() > 0)
                return user.First();
            return null;
        }
        public List<ChildrenEntitie> GetCoproChildrens(String Copro_guid)
        {
            var childrens = (from c in bdd.Childrens where (c.Copro_id == Copro_guid) select c).ToList();
            return childrens;
        }
        public List<ChildrenEntitie> GetUserChildrens(String user_guid)
        {
            var childrens = (from c in bdd.Childrens where (c.User_id == user_guid) select c).ToList();
            return childrens;
        }
        public string AddCopro(string user_id, string immeuble_id, String copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom )
        {
            var res = "0";
            var cop = (from c in bdd.Childrens where (c.User_id == user_id && c.Copro_id == copro_id) select c).Count();
            if ( cop == 0 )
            {
                bdd.Childrens.Add(new ChildrenEntitie() { User_id = user_id, Immeuble_id = immeuble_id, Copro_id = copro_id });
                var immeuble = (from i in bdd.Immeubles where (i.Immeuble_id == immeuble_id) select i).Count();
                if (immeuble == 0)
                    bdd.Immeubles.Add(new ImmeubleEntitie() { Immeuble_id = immeuble_id, Reference = reference_imm, Addresse = adresse_imm});
                var copro = (from c in bdd.Coproprietaires where c.Copropriete_id == copro_id select c).Count();
                if (copro == 0)
                    bdd.Coproprietaires.Add(new CoproprietaireEntitie() { Copropriete_id = copro_id, Reference = reference_copro, Nom = nom, Immeuble_id = immeuble_id });
                try
                {
                    bdd.SaveChanges();
                }
                catch (Exception ex)
                {
                    res = ex.Message;
                }
            }
            else
                res = "Copropriété déja affectée a cet utilisateur";
            return res;
        }

        public CoproprietaireEntitie GetCoproFromGuid(string guid)
        {
            var copro = (from c in bdd.Coproprietaires where c.Copropriete_id == guid select c);
            if (copro.Count() > 0)
                return copro.First();
            return null;
        }

        public List<DocumentEntitie> GetDocumentsFromCopro(string copro_id)
        {
            var docs = new List<DocumentEntitie>();
            var sqlDocs = (from d in bdd.Documents where d.copro_id == copro_id select d);
            if (sqlDocs.Count() > 0)
                docs.AddRange(sqlDocs.ToList());
            return docs;
        }
        public DocumentEntitie GetDocumentFromGuid(String Guid)
        {
            var doc = (from d in bdd.Documents where (d.Guid == Guid) select d);
            if (doc.Count() > 0)
                return doc.First();
            return null;
        }

        public string DeleteDocument(String Guid)
        {
            var msg = "";
            var rootDir = System.IO.Directory.GetParent(apPath).Parent;
            var rootPath = rootDir.FullName;
            var doc = GetDocumentFromGuid(Guid);
            if (doc != null)
            {
                var docName = doc.text;
                try
                {
                    var filename = System.IO.Path.Combine(rootPath, "SyndicDocuments", "pdf", doc.Guid + ".pdf");
                   
                    if (System.IO.File.Exists(filename))
                    {
                        System.IO.File.Delete(filename);
                    }
                    else
                    {
                        msg = "Fichier pdf " + filename + " non présent\n";
                    }
                    bdd.Documents.Remove(doc);
                    bdd.SaveChanges();
                    msg += "Données du documents " + docName + " supprimé";
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            else
                msg = "Documents " + Guid + " inexistant";
            return msg;
        }
    }
}