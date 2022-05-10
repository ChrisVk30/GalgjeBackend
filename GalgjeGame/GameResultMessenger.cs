using GalgjeGame.Core;
using System.Text;
using System.Linq;

namespace GalgjeGame
{
    public class GameResultMessenger //: IGameResultTracker
    {
        public GameResultMessenger()
        {

        }
        public void GetResultOfGame(string wordToGuess, UserGameScore userGS, PassedTimeCalculator stopwatch)
        {
            Console.WriteLine($"\nThe word was: {wordToGuess}");
            if (userGS.IncorrectGuesses < 7)
            {
                StringBuilder sb = new StringBuilder();
                string winMessage = $"You win! :)\n";
                string variableWinMessage;
                if (userGS.IncorrectGuesses == 1)
                    variableWinMessage = $"You guessed the word with 1 incorrect guess in {stopwatch.SecondsPassed} seconds!";
                else
                    variableWinMessage = $"You guessed the word with {userGS.IncorrectGuesses} incorrect guesses in {stopwatch.SecondsPassed} seconds!";
                sb.Append(winMessage);
                sb.Append(variableWinMessage);
                Console.WriteLine(sb);
            }
            else
                Console.WriteLine("You lose! :(");
        }
        public void ShowHangmanStatus(UserGameScore user)
        {
            Console.Clear();
            Console.WriteLine(HangmanArt.hangmanPhases[user.IncorrectGuesses]);
        }
        public string GetAlreadyChosenLetters(UserGameScore user)
        {
            return string.Join(" ", (user.guessedLetters).OrderBy(g => g));
        }
    }
}
