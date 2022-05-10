using System.Text;
using GalgjeGame;
using GalgjeGame.Core;
using Microsoft.EntityFrameworkCore;

namespace GalgjeGame
{
    public class ScoreLogger
    {
        public void PrintOverallScores(List<UserOverallScore> top10OverallScores)
        {
            Console.Clear();
            string headerline = $"--------------------------------------------------------------------------";
            string header = $"\n|{"Username",-30}|{"% Words Guessed",-20}|{"Guessed Correct",-20}|";
            string subheaderline = $"\n--------------------------------------------------------------------------";
            StringBuilder sb = new StringBuilder();
            sb.Append(headerline);
            sb.Append(header);
            sb.Append(subheaderline);
            Console.WriteLine(sb);

            foreach(var user in top10OverallScores)
            {
                Console.WriteLine($"|{user.UserName, -30}|{user.Ratio,-20}|{user.WordsGuessed,-20}|");
            }
            Console.WriteLine(headerline);
        }
        public void PrintTop10Scores(List<UserGameScore> top10GameScores)
        {
            Console.Clear();
            string headerline = $"--------------------------------------------------------------------------";
            string header = $"\n|{"Username",-30}|{"Incorrect Guesses",-20}|{"Time Elapsed (s)",-20}|";
            string subheaderline = $"\n--------------------------------------------------------------------------";
            StringBuilder sb = new StringBuilder();
            sb.Append(headerline);
            sb.Append(header);
            sb.Append(subheaderline);
            Console.WriteLine(sb); 

            foreach (var user in top10GameScores)
            {
                Console.WriteLine($"|{user.UserName,-30}|{user.IncorrectGuesses,-20}|{user.TimeElapsedInGuessing,-20}|");
            }
            Console.WriteLine(headerline); 
        }
    }
}