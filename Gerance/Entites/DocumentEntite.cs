using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using System.Data;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using System.IO;

namespace GeranceData.Entites
{
    public class DocumentEntite : AbstractBaseEntite
    {
        public string document_type;
        public string reference;
        public DateTime date_document;
        public string libelle;
        public byte[] document_image;
        public Image Image
        {
            get
            {
                if ( document_image == null)
                {
                    document_image = DocumentController.getController().getImage(id);
                }
                MemoryStream ms = new MemoryStream(document_image);
                return Image.FromStream(ms);
//                return img;
            }
            set
            {
                MemoryStream ms = new MemoryStream();
                value.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                document_image = ms.ToArray();
            }
        }
        public int statut;

        public DocumentEntite()
        {
            setValues(null);
            id = "";
        }
        public DocumentEntite(DataRow data)
        {
            setValues(data);
        }

        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("document_type", true, members));
            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("date_document", true, members));
            updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("document_image", true, members));
            updatables.Add(new UpdateField("statut", true, members));
            
            base.setValues(row);
        }

    }
}
