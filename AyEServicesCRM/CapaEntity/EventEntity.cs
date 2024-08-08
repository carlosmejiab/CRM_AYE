using System;

namespace CapaEntity
{
    public class EventEntity
    {
        public int IdEvent { get; set; }
        public int IdStatusEvent { get; set; }
        public int IdActivityType { get; set; }
        public int IdLocation { get; set; }
        public int IdPriority { get; set; }
        public int IdTask { get; set; }
        public int IdClient { get; set; }      
        public String Name { get; set; }
        public DateTime StarDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public String Descripcion { get; set; }
        public String State { get; set; }
        public int IdFrequency { get; set; }
        public int IdEmployeeCreate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}
