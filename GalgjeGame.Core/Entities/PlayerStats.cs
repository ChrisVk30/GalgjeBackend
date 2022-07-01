using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Entities
{
    public class PlayerStats
    {
        public long PlayerId { get; set; }
        public string UserName
        { get; set; }
        public int GuessedWords { get; set; }
        public double Ratio { get; set; }
        public TimeSpan? TimeElapsed { get; set; }
        public string ConvertedTime { get { return TimeElapsed.ToString().Substring(0,8); } }
        public int WordLenght { get; set; }
    }
}
