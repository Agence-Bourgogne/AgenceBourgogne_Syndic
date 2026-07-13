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
        public bool SaveUser(UserEntitie user)
        {
            bdd.SaveChanges();
            return true;
        }
        public string UpdateUser(string Guid, string CodeUser, String password = "")
        {
            String msg = "";
            if (password == "")
                password = "ChangeIt";
            UserEntitie user = GetUserFromGuid(Guid);
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
            String msg = "";
            if (password == "")
                password = "ChangeIt";
            UserEntitie user = GetUserFromCode(CodeUser);
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
            String msg = "";
            UserEntitie user = GetUserFromGuid(Guid);
            if (user != null)
            {
                try
                {
                    List<ChildrenEntitie> childrens = GetUserChildrens(user.Guid);
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
            String msg = "";
            CoproprietaireEntitie copro = GetCoproFromGuid(Guid);
            if ( copro != null )
            {
                List<DocumentEntitie> docs = GetDocumentsFromCopro(Guid);
                if ( docs.Count > 0)
                    bdd.Documents.RemoveRange(docs);
                List<ChildrenEntitie> childrens = GetCoproChildrens(Guid);
                if (childrens.Count > 0)
                    bdd.Childrens.RemoveRange(childrens);
                bdd.Coproprietaires.Remove(copro);
                bdd.SaveChanges();
                msg = "0";
            }
            return msg;
        }
        public void CreateImmeuble(string ReferenceImmeuble, String Adresse, string Immeuble_id="")
        {
            if (String.IsNullOrWhiteSpace(Immeuble_id))
                Immeuble_id = Guid.NewGuid().ToString();
            ImmeubleEntitie obj = bdd.Immeubles.Add ( new ImmeubleEntitie { Reference = ReferenceImmeuble, Immeuble_id = Immeuble_id, Addresse = Adresse });
            try
            {
                bdd.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        public DocumentEntitie GetDocument(String Guid)
        {
            var doc = (from d in bdd.Documents where (d.Guid == Guid) select d).First();
            return doc;
        }
        public void CreateDocument(string text, String Guid, byte[] content, string immeuble_id, string copro_id)
        {
            var list = (from d in bdd.Documents where (d.text == text && d.immeuble_id == immeuble_id && d.copro_id == copro_id) select d);
            if (list.Count() > 0)
            {
                DocumentEntitie doc = list.First();
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
        public List<ImmeubleEntitie> GetAllImmeubles()
        {
            return bdd.Immeubles.ToList();
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
            string res = "0";
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

        public ImmeubleEntitie GetImmeubleFromGuid(string guid)
        {
            var immeuble = (from i in bdd.Immeubles where i.Immeuble_id == guid select i);
            if (immeuble.Count() > 0)
                return immeuble.First();
            return null;
        }

        public CoproprietaireEntitie GetCoproFromGuid(string guid)
        {
            var copro = (from c in bdd.Coproprietaires where c.Copropriete_id == guid select c);
            if (copro.Count() > 0)
                return copro.First();
            return null;
        }
        public List<ImmeubleEntitie> GetArborescenceImmeuble(String userCode)
        {
            List<ImmeubleEntitie> list = new List<ImmeubleEntitie>();
            var usr = (from u in bdd.Users where u.Code == userCode select u);
            if ( usr.Count() > 0)
            {
                UserEntitie user = usr.First();
                List<ChildrenEntitie> childrens = GetUserChildrens(user.Guid).OrderBy(x => x.Immeuble_id ).ToList();
                string immeuble_id = "";
                ImmeubleEntitie current = null;
                List<DocumentEntitie> docs = null;

                foreach (ChildrenEntitie child in childrens)
                {
                    if (immeuble_id != child.Immeuble_id)
                    {
                        current = GetImmeubleFromGuid(child.Immeuble_id);
                        immeuble_id = child.Immeuble_id;
                        docs = GetDocumentsFromImmeuble(child.Immeuble_id);
                        current.children.AddRange(docs.FindAll(x => x.copro_id == ""));
                        list.Add(current);
                    }
                    if (!String.IsNullOrEmpty(child.Copro_id))
                    {
                        CoproprietaireEntitie copro = GetCoproFromGuid(child.Copro_id);
                        copro.children.AddRange(docs.FindAll(x => x.copro_id == child.Copro_id).ToList());
                        current.children.Add(copro);
                    }
                }
            }
            return list;
        }
        public List<DocumentEntitie> GetDocumentsFromImmeuble(string immeuble_id)
        {
            List<DocumentEntitie> docs = new List<DocumentEntitie>();
            var sqlDocs = (from d in bdd.Documents where d.immeuble_id == immeuble_id select d);
            if (sqlDocs.Count() > 0)
            {
                List<DocumentEntitie> list = new List<DocumentEntitie>();
                foreach(DocumentEntitie doc in sqlDocs.ToList())
                {
                    doc.content = new byte[0];
                    list.Add(doc);
                }

                docs.AddRange(list);//sqlDocs.ToList());
            }
               
            return docs;
        }
        public List<DocumentEntitie> GetDocumentsFromCopro(string copro_id)
        {
            List<DocumentEntitie> docs = new List<DocumentEntitie>();
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
        public MissingEntitie CreateMissingEntrie(string Email)
        {
            MissingEntitie entitie = new MissingEntitie(Email);
            bdd.MissingEntities.Add(entitie);
            bdd.SaveChanges();
            return entitie;
        }
        public MissingEntitie GetMissingFromId(String Id)
        {
            var missing = (from m in bdd.MissingEntities where m.Guid == Id select m);
            if (missing.Count() > 0)
                return missing.First();
            return null;
        }
        public string DeleteDocument(String Guid)
        {
            String msg = "";
            System.IO.DirectoryInfo rootDir = System.IO.Directory.GetParent(apPath).Parent;
            string rootPath = rootDir.FullName;
            DocumentEntitie doc = GetDocumentFromGuid(Guid);
            if (doc != null)
            {
                string docName = doc.text;
                try
                {
                    string filename = System.IO.Path.Combine(rootPath, "SyndicDocuments", "pdf", doc.Guid + ".pdf");
                   
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