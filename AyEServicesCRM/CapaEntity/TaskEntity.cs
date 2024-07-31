using System;


namespace CapaEntity
{
    public class TaskEntity
    {
        public int IdTask { get; set; }
        public int IdClient { get; set; }
        public int IdTypeTask { get; set; }
        public int IdEmployee { get; set; }
        public int IdEmployeeCreate { get; set; }
        
        public int IdStatus { get; set; }
        public int IdLocation { get; set; }
        public int IdParentTask { get; set; }
        public int IdContact { get; set; }
        public int IdPriority { get; set; }
        public String Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public int Estimate { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
        public int FiscalYear { get; set; }
        public int IdClientAccount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public int IdGroup { get; set; }



    }
}
