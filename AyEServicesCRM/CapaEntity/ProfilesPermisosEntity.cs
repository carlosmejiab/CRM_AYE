using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntity
{
    public class ProfilesPermisosEntity
    {
        public int IdPermisos { get; set; }
        public int IdProfile { get; set; }
        public String Modulo { get; set; }
        public String Permiso { get; set; }
        public String State { get; set; }
    }
}
