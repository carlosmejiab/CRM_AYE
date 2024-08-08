using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class ServicesEntity
    {
        public int IdService { get; set; }
        public int IdTyoeClient { get; set; }
        public String IdStatusService { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public String Description { get; set; }
    }
}
