using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core
{
    public class PassedTimeCalculator
    {
        Stopwatch _stopwatch;
        public PassedTimeCalculator()
        {
            _stopwatch = new Stopwatch();
        }
        public void StartTimer()
        {
            _stopwatch.Start();
        }
        public int StopTimer()
        {
            _stopwatch.Stop();
            return _stopwatch.Elapsed.Seconds;
        }
        public void ResetTimer()
        {
            _stopwatch.Reset();
        }
    }
}
