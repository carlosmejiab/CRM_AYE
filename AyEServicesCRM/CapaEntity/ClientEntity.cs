using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class ClientEntity
    {
        public int IdClient { get; set; }
        public int IdServices { get; set; }
        public int IdCity { get; set; }
        public int IdLocation { get; set; }
        public int IdUser { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Adress { get; set; }
        public String Comments { get; set; }
        public String State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
