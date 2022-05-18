using GalgjeGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Views
{
    public class PlayerStatsView
    {
        PlayerStats stats;
        public PlayerStatsView()
        {
            stats = new PlayerStats();
        }
        void ShowEndOfGameMenu()
        {
            bool loopThroughMenu = true;

            while (loopThroughMenu)
            {
                Console.WriteLine("\nPress 1 to see the top 10 overall stats per player");
                Console.WriteLine("Press 2 to see the top 10 topscores");
                Console.WriteLine("Press 3 to reset all scoreboards");
                Console.WriteLine("Press 'Q' to exit out of the game");
                Console.WriteLine("Press any other key to play another round");
                var userinput = Console.ReadLine().Trim().ToUpper();
                switch (userinput)
                {
                    case "1":
                        var Top10OverallScores = galgjeRepository.GetTop10OverallScores();
                        scoreLogger.PrintOverallScores(Top10OverallScores);
                        ReturnToMenu();
                        break;
                    case "2":
                        var Top10GameScores = galgjeRepository.GetTop10GameScores();
                        scoreLogger.PrintTop10Scores(Top10GameScores);
                        ReturnToMenu();
                        break;
                    case "3":
                        Console.Clear();
                        galgjeRepository.ResetAllScoreboards();
                        Console.WriteLine("Scoreboard has been cleared of all results...");
                        ReturnToMenu();
                        break;
                    case "Q":
                        loopThroughMenu = keepGoing = false;
                        break;
                    default:
                        loopThroughMenu = false;
                        break;
                }
            }
        }
    }
}
