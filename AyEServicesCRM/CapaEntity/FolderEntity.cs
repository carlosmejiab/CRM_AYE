using System;

namespace CapaEntity
{
    public class FolderEntity
    {
        public int IdFolder { get; set; }
        public int IdClient { get; set; }
        public String FolderParent { get; set; }
        public String Name { get; set; }
        public String Ruta { get; set; }      
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
