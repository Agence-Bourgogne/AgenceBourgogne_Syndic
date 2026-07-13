using System.Collections.Generic;

namespace SyndicDocumentsData.Entities
{
    public class RootEntitie
    {
        public int id;
        public string text;
        public List<object> children = new List<object>();
        public string icon = "folder";
        public RootEntitie(int id, string text)
        {
            this.id = id;
            this.text = text;
        }

    }
}