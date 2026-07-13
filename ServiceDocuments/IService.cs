using System.Collections.Generic;
using System.ServiceModel;
using SyndicDocumentsData.Entities;

namespace ServiceDocuments
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string CreateUser(string Code, string Password );

        [OperationContract]
        void UploadPartFile(string Guid, byte[] filePart);

        [OperationContract]
        string CloseFile(string text, string Guid, string immeuble_id, string copro_id);

        [OperationContract]
        UserEntitie GetUserFromCode(string code);

        [OperationContract]
        UserEntitie GetUserFromGuid(string Guid);

        [OperationContract]
        List<UserEntitie> GetAllUsers();

        [OperationContract]
        List<ChildrenEntitie> GetUserCoproprietaires(string guid);

        [OperationContract]
        List<ChildrenEntitie> GetCoproChildrens(string copro_id);

        [OperationContract]
        string AddCopro(string user_id, string immeuble_id, string copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom);

        [OperationContract]
        string DeleteUser(string guid);

        [OperationContract]
        string DeleteCopro(string guid);

        [OperationContract]
        List<DocumentEntitie> GetListDocuments(string immeuble_id = "", string copro_id = "");

        [OperationContract]
        string DeleteDocument(string guid);

        [OperationContract]
        bool Connected();

        [OperationContract]
        string UpdateUser(string guid, string Code, string Password);

    }
}

