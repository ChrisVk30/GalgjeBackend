using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Entities
{
    public class TopScoreStats
    {
        public string UserName { get; set; }
        public TimeSpan? TimeElapsed { get; set; }
        public int WordLength { get; set; }
    }
}