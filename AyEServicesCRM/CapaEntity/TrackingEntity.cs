using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class TrackingEntity
    {
        public int IdTracking { get; set; }
        public int IdTask { get; set; }
        public int IdEmployee { get; set; }
        public int IdStatusTracking { get; set; }
        public String Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public int DurationTime { get; set; }
        public int TimeWork { get; set; }
        public DateTime TrackingStart { get; set; }
        public DateTime TrackingDue { get; set; }
        public String State { get; set; }
        public int DailyTimeWorked { get; set; }
    }
}
