using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Entities
{
    public class PlayerStats
    {
        private string _userName;
        public long PlayerId { get; set; }
        public string UserName
        {
            get { return _userName; }
            set { _userName = char.ToUpper(value[0]) + value.Substring(1).ToLower(); }
        }

        public int GuessedWords { get; set; }
        public double Ratio { get; set; }
    }
}
