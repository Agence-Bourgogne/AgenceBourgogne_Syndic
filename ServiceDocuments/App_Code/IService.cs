using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using SyndicDocumentsData.Entities;
// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService" à la fois dans le code et le fichier de configuration.
[ServiceContract]
public interface IService
{

    [OperationContract]
    string CreateUser(string Code, String Password );

    [OperationContract]
    void UploadPartFile(string Guid, byte[] filePart);

    [OperationContract]
    String CloseFile(string text, string Guid, string immeuble_id, string copro_id);

    [OperationContract]
    UserEntitie GetUserFromCode(String code);

    [OperationContract]
    UserEntitie GetUserFromGuid(String Guid);

    [OperationContract]
    List<UserEntitie> GetAllUsers();

    [OperationContract]
    List<ChildrenEntitie> GetUserCoproprietaires(string guid);

    [OperationContract]
    string AddCopro(string user_id, string immeuble_id, String copro_id, string reference_imm, string adresse_imm, string reference_copro, string nom);

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
    string UpdateUser(string guid, string Code, String Password);

}

