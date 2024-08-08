using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class ContactEntity
    {
        public int IdContact { get; set; }
        public int IdCity { get; set; }
        public int IdTitles { get; set; }
        public int IdEmployees { get; set; }
        public int IdUsers { get; set; }
        public int IdClient { get; set; }
        public String WordAreas { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
