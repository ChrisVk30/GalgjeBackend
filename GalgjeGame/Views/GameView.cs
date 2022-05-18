using GalgjeGame.Core;
using GalgjeGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Views
{
    public class GameView
    {
        private PassedTimeCalculator stopwatch;
        private PlayerView playerView;
        public GameView()
        {
            this.stopwatch = new PassedTimeCalculator();
            this.playerView = new PlayerView();
        }   

        public void PlayGame(Game game)
        {
            bool playAgain = true;

            while(playAgain)
            { 
            stopwatch.StartTimer();
            do
            {
                Console.Clear();
                Console.WriteLine(hangmanPhases[game.IncorrectGuesses]);
                Console.WriteLine(game.GuessedWord);
                Console.WriteLine($"Already chosen letters: {game.ChosenLetters}");

                char letter = playerView.RequestLetter(game);
                game.GuessLetter(letter);
                game.CheckGameStatus();
            }
            while (game.Status == Game.GameStatus.InProgress);
            game.TimeElapsed = stopwatch.StopTimer();
            }
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
