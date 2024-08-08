using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntity
{
    public class UsersEntity
    {
        public int IdUser { get; set; }
        public int IdEmployee { get; set; }
        public int IdProfile { get; set; }
        public String Username { get; set; }
        public String PasswordToken { get; set; }
        public String State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
