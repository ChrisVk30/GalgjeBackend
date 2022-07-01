using GalgjeGame.Core;
using GalgjeGame.Core.Entities;
using static GalgjeGame.Core.Entities.Game;

namespace GalgjeGame.Views
{
    public class GameView
    {
        //private PassedTimeCalculator _stopwatch;
        //private UserInputValidation _inputValidator;
        //public GameView()
        //{
        //    _inputValidator = new UserInputValidation();
        //    _stopwatch = new PassedTimeCalculator();
        //}

        public string AlreadyChosenLetters { 
            set => Console.WriteLine($"Already chosen letters: {value}");
        }
        public string GuessedWord { 
            set => Console.WriteLine(value); 
        }
        public int HangmanPhase { 
            set => Console.WriteLine(hangmanPhases[value]); 
        }
        public GameStatus Status { 
            set 
            {
                if (value == GameStatus.Won)
                    Console.WriteLine("You guessed the word! You win!");
                else if (value == GameStatus.Lost)
                    Console.WriteLine("You didn't guess the word... You lose!");
            } 
        }

        public bool PlayAgain()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            char userInput = Console.ReadLine()[0];
            return userInput == 'y';
        }

        public char RequestLetter(Game game)
        {
            Console.WriteLine($"\nPlease choose a new letter to guess the word: ");
            char chosenLetter = Console.ReadLine()[0];
            //_inputValidator.VerifyChosenLetter(chosenLetter, game);
            return chosenLetter;
        }

        public static string[] hangmanPhases = { @"
          +---+
              |
              |
              |
              |
              |
        =========", @"
          +---+
          |   |
              |
              |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
              |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
          |   |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|   |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|\  |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|\  |
         /    |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|\  |
         / \  |
              |
        =========" };
    }
}
