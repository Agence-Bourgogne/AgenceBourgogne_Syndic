using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyndicDocumentsData.Entities;

namespace SyndicDocumentsData.Models
{
    public interface IDal : IDisposable
    {
        string CreateUser (string CodeUser, string password = "");
        string UpdateUser(string guid, string CodeUser, string password = "");
        string DeleteUser(string Guid);
        string DeleteDocument(string Guid);
        string DeleteCopro(string Guid);

        void CreateImmeuble(string RefImmeuble, String Adresse, string Immeuble_id = "");
        void CreateDocument(string text, String Guid, byte[] content, string immeuble_id, string copro_id);
        string AddCopro(string user_id, string immeuble_id, String copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom);

        UserEntitie GetUserFromCode(String code);
        UserEntitie GetUserFromGuid(String Guid);
        DocumentEntitie GetDocument(String Guid);

        List<UserEntitie> GetAllUsers();        
        List<ImmeubleEntitie> GetAllImmeubles();
        List<ChildrenEntitie> GetUserChildrens( string user_guid);
        List<ChildrenEntitie> GetCoproChildrens(string Copro_guid);
        List<ImmeubleEntitie> GetArborescenceImmeuble(String userCode);
        List<DocumentEntitie> GetDocuments(string immeuble_id = "", string copro_id = "");

        bool SaveUser(UserEntitie user);
        MissingEntitie CreateMissingEntrie(string Email);
        MissingEntitie GetMissingFromId(String Id);
    }
}
