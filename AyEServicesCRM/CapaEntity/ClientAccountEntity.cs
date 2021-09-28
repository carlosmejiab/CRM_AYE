using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class ClientAccountEntity
    {
        public int IdClientAccount { get; set; }
        public int IdClient { get; set; }
        public int IdBank { get; set; }
        public String AccountNumber { get; set; }
        public String State { get; set; }
        public int IdUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
