using System;
using System.Linq;
using System.Text.RegularExpressions;
using GalgjeGame;

namespace GalgjeGame.Core
{
    public class Game //: IGame
    {
        string[] AnonymousGuessedWord { get; set; }
        public string CreateHiddenWord(string wordToGuess)
        {
            AnonymousGuessedWord = new string[wordToGuess.Length];
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                AnonymousGuessedWord[i] = "_";
            }
            return " " + string.Join(" ", AnonymousGuessedWord);
        }
        public string CheckIfLetterInToBeGuessedWord(string userGuess, string wordToGuess, UserGameScore user)
        {
            if (wordToGuess.Contains(userGuess))
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i].ToString() == userGuess)
                    {
                        AnonymousGuessedWord[i] = userGuess;
                    }
                }
            }
            else
            {
                user.IncorrectGuesses++;
            }
            return " " + string.Join(" ", AnonymousGuessedWord); 
        }
    }
}