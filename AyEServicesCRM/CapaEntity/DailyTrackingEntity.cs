using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntity
{
    public class DailyTrackingEntity
    {
        public int IdDailyTracking { get; set; }
        public int IdTracking { get; set; }
        public int IdTask { get; set; }
        public int IdEmployee { get; set; }
        public DateTime TrackingDate { get; set; }
        public int TimeWork { get; set; }

    }
}
