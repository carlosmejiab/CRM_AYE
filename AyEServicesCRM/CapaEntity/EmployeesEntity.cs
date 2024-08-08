using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntity
{
    public class EmployeesEntity
    {
        public int IdEmployee { get; set; }
        public int IdLocation { get; set; }
        public int IdPosition { get; set; }
        public int IdExtension { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Email { get; set; }
        public String MobilePhone { get; set; }
        public byte[] Photo { get; set; }
        public String State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
