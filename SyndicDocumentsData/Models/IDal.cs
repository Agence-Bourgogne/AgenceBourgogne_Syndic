using System;
using System.Collections.Generic;
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

        void CreateDocument(string text, String Guid, byte[] content, string immeuble_id, string copro_id);
        string AddCopro(string user_id, string immeuble_id, String copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom);

        UserEntitie GetUserFromCode(String code);
        UserEntitie GetUserFromGuid(String Guid);

        List<UserEntitie> GetAllUsers();
        List<ChildrenEntitie> GetUserChildrens( string user_guid);
        List<ChildrenEntitie> GetCoproChildrens(string Copro_guid);
        List<DocumentEntitie> GetDocuments(string immeuble_id = "", string copro_id = "");
    }
}
