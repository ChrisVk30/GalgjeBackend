using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Entities
{
    public class TopPlayerStats
    {
        public string UserName { get; set; }
        public int GuessedWords { get; set; }
        public double Ratio { get; set; }
    }
}