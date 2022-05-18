using GalgjeGame.Core.Entities;
using GalgjeGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GalgjeGame.Core.Entities.Game;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class PlayerStatsRepository
    {
        private readonly DbContextOptions<GalgjeContext> _options;

        public PlayerStatsRepository(DbContextOptions<GalgjeContext> options)
        {
            _options = options;
        }
        public async Task<IEnumerable<PlayerStats>> GetTop10ScoresBasedOnRatio()
        {
            using (var context = new GalgjeContext(_options))
            {
                var queryTop10OverallScores =   (from a in context.Games
                                               join b in context.Players
                                               on a.PlayerId equals b.Id
                                               let guessedWords = context.Games.Count(x => x.PlayerId == a.Id && x.Status == GameStatus.Won)
                                               let notGuessedWords = context.Games.Count(x => x.PlayerId == a.Id && x.Status == GameStatus.Lost)
                                               select new
                                               {
                                                   UserName = b.UserName,
                                                   Ratio = Math.Round((guessedWords / (double)(guessedWords + notGuessedWords)) * 100, 2),
                                                   WordsGuessed = guessedWords
                                               } into scores
                                               orderby scores.Ratio descending, scores.WordsGuessed descending, scores.UserName ascending
                                               select new PlayerStats() { UserName = scores.UserName, Ratio = scores.Ratio, GuessedWords = scores.WordsGuessed }
                             ).Distinct().Take(10).AsNoTracking().ToList();

                return queryTop10OverallScores;
            }
        }

        public async Task<IEnumerable<PlayerStats>> GetTop10ScoresBasedOnGuessedWords()
        {
            using (var context = new GalgjeContext(_options))
            {
                var queryTop10Scores =          (from a in context.Games
                                                join b in context.Players
                                                on a.PlayerId equals b.Id
                                                let guessedWords = context.Games.Count(x => x.PlayerId == a.Id && x.Status == GameStatus.Won)
                                                select new
                                                {
                                                    UserName = b.UserName,
                                                    WordsGuessed = guessedWords
                                                } into scores
                                                orderby scores.WordsGuessed descending, scores.UserName ascending
                                                select new PlayerStats() { UserName = scores.UserName, GuessedWords = scores.WordsGuessed }
                             ).Distinct().Take(10).AsNoTracking().ToList();

                return queryTop10Scores;
            }
        }
    }
}
