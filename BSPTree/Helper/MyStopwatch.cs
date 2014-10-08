using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPTreeGUI.Helper
{
    public class MyStopwatch : System.Diagnostics.Stopwatch
    {

        public long ElapsedNanoSeconds
        {
            get
            {
                return getNanoSecondsPerTick() * this.ElapsedTicks;
            }
        }

        public MyStopwatch()
            : base()
        {
        }

        public long getNanoSecondsPerTick()
        {
            long nanosecPerTick = (1000L * 1000L * 1000L) / MyStopwatch.Frequency;
            return nanosecPerTick;
        }
    }
}
