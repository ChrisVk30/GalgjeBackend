using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Entities
{
    public class Game
    {
        public long Id { get; set; }
        public string SecretWord { get; set; }
        public string RightLetters { get; set; } = "";
        public string WrongLetters { get; set; }
        public int TimeElapsed { get; set; }
        public string ChosenLetters
        {
            get
            {
                string concatString = RightLetters + WrongLetters;
                char[] cArray = concatString.ToCharArray();
                Array.Sort(cArray);
                return String.Join(" ",cArray);
            }
        }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int IncorrectGuesses
        {
            get
            {
                if (WrongLetters == null)
                    return 0;
                else
                    return WrongLetters.Count();
            }
        } 
        public GameStatus Status { get; set; }
        public string GuessedWord
        {
            get
            {
                StringBuilder sb = new();
                for (int i = 0; i < SecretWord.Length; i++)
                {
                    if (RightLetters.Contains(SecretWord[i]) && RightLetters != null)
                    {
                        sb.Append(SecretWord[i]);
                    }
                    else
                    {
                        sb.Append(" _ ");
                    }
                }
                return sb.ToString();
            }
        }

        public void GuessLetter(char letter) {
            if (SecretWord.Contains(letter))
            {
                RightLetters += letter;
            }
            else {
                WrongLetters += letter;
            }
        }      

        public void CheckGameStatus()
        {
            if (SecretWord == GuessedWord)
                Status = GameStatus.Won;
            else if (IncorrectGuesses == 7)
                Status = GameStatus.Lost;
        }
        public enum GameStatus
        {
            InProgress, Won, Lost
        }
    }
}
