using System.Text;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace GalgjeGame.Core.Entities
{
    public class Game
    {
        public long Id { get; set; }
        public string SecretWord { get; set; }
        public string RightLetters { get; set; } = "";
        public string WrongLetters { get; set; } = "";
        public DateTime? TimeStarted { get; set; }
        public DateTime? TimeFinished { get; set; }
        public TimeSpan? TimeElapsed { get; set; }
        public string ChosenLetters
        {
            get
            {
                string concatString = RightLetters + WrongLetters;
                char[] cArray = concatString.ToCharArray();
                Array.Sort(cArray);
                return String.Join(" ", cArray);
            }
        }
        public long PlayerId { get; set; }
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
        public GameStatus Status { get; set; } = GameStatus.InProgress;
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
        public void GuessLetter(char letter)
        {
            if (SecretWord.Contains(letter) && !RightLetters.Contains(letter))
            {
                RightLetters += letter;
            }
            else if (!WrongLetters.Contains(letter) && !RightLetters.Contains(letter))
            {
                WrongLetters += letter;
            }
        }
        public void UpdateGameStatus()
        {
            if (SecretWord == GuessedWord)
            {
                Status = GameStatus.Won;
                TimeFinished = DateTime.Now;
                TimeElapsed = TimeFinished - TimeStarted;
            }
            else if (IncorrectGuesses == 7)
            {
                Status = GameStatus.Lost;
                TimeFinished = DateTime.Now;
                TimeElapsed = TimeFinished - TimeStarted;
            }
        }
        public enum GameStatus
        {
            InProgress, Won, Lost
        }

    }
}