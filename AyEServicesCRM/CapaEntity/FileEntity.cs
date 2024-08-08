using System;

namespace CapaEntity
{
    public class FileEntity
    {
        public int IdFile { get; set; }
        public String NameFile { get; set; }
        public String RouteFile { get; set; }
        public String StatusFile { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
