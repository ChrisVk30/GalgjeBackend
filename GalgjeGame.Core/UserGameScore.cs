using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalgjeGame;

namespace GalgjeGame.Core
{
    public class UserGameScore
    {
        private string _userName;
        public long ID { get; set; }
        public string UserName 
        {
            get { return _userName; }
            set { _userName = char.ToUpper(value[0]) + value.Substring(1).ToLower(); } 
        }
        public int TimeElapsedInGuessing { get; set; }
        public int IncorrectGuesses { get; set; }
        public List<string> guessedLetters { get; } = new List<string>();
        public UserOverallScore userOverallScore { get; set; }
    }
}
