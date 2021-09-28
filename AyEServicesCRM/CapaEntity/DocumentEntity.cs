using System;

namespace CapaEntity
{
    public class DocumentEntity
    {
        public int IdDocument { get; set; }
        public int IdFile { get; set; }
        public int IdClient { get; set; }
        public int IdEmployees { get; set; }
        public int IdTask { get; set; }
        public int IdFolder { get; set; }
        public int IdStatusDocument { get; set; }
        public int IdUser { get; set; }
        public String NameDocument { get; set; }
        public String Descripcion { get; set; }
        public DateTime CreatioDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public String State { get; set; }
    }
}
