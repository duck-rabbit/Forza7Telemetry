using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForzaDataTool
{
    public class Lap
    {
        public int LapNo { get; set; }
        public TimeSpan LapTime { get; set; }
        public TimeSpan[] InterTimes { get; set; }
    }
}