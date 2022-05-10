using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using GalgjeGame.Core;
using GalgjeGame.Infrastructure.Data;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class GalgjeRepository
    {
        private readonly DbContextOptions<GalgjeContext> _options;

        public GalgjeRepository(DbContextOptions<GalgjeContext> options)
        {
            _options = options;
        }
        public void AddUserToOverallScoreboard(UserGameScore user)
        {
            using (var context = new GalgjeContext(_options))
            {
                if (!context.UserOverallScores.Any(u => u.UserName == user.UserName))
                {
                    context.UserOverallScores.Add
                        (new UserOverallScore
                        { UserName = user.UserName, TimesPlayed = 0, WordsGuessed = 0 }
                        );
                    context.SaveChanges();
                }
            }
        }
        public void AddUserToGameScoreboard(UserGameScore user)
        {
            using (var context = new GalgjeContext(_options))
            {
                context.UserGameScores.Add(user);
                context.SaveChanges();
            }
        }
        public void UpdateOverallScoreboard(UserGameScore user)
        {
            using (var context = new GalgjeContext(_options))
            {
                var sut = context.UserOverallScores.Where(u => u.UserName == user.UserName).First();
                sut.TimesPlayed++;
                if (user.IncorrectGuesses < 7)
                    sut.WordsGuessed++;
                context.SaveChanges();
            }
        }
        public string GetWordToGuess()
        {
            using (var context = new GalgjeContext(_options))
            {
                var returnWord = new SqlParameter()
                {
                    ParameterName = "Value",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                var resultNew = context.Set<Word>().FromSqlRaw("EXEC [dbo].[SP_GetWordToGuess] @Value OUTPUT", returnWord).ToList();
                return resultNew.First().Value;
            }
        }
        public void ResetAllScoreboards()
        {
            using (var context = new GalgjeContext(_options))
            {
                context.UserGameScores.RemoveRange(context.UserGameScores);
                context.UserOverallScores.RemoveRange(context.UserOverallScores);
                context.SaveChanges();
            }
        }
        public List<UserOverallScore> GetTop10OverallScores()
        {
            using (var context = new GalgjeContext())
            {
                var queryTop10OverallScores = (from o in context.UserOverallScores
                                               select new UserOverallScore
                                               {
                                                   UserName = o.UserName,
                                                   Ratio = Math.Round(((double)o.WordsGuessed / (double)o.TimesPlayed) * 100, 2),
                                                   WordsGuessed = o.WordsGuessed
                                               } into result
                                               orderby result.Ratio descending, result.WordsGuessed descending, result.UserName ascending
                                               select result
                             ).Take(10).AsNoTracking().ToList();

                return queryTop10OverallScores;
            }
        }
        public List<UserGameScore> GetTop10GameScores()
        {
            using (var context = new GalgjeContext())
            {
                var queryTop10GameScores = (from u in context.UserGameScores
                                            orderby u.IncorrectGuesses ascending, u.TimeElapsedInGuessing ascending, u.UserName ascending
                                            select new UserGameScore
                                            {   UserName = u.UserName, 
                                                IncorrectGuesses = u.IncorrectGuesses,
                                                TimeElapsedInGuessing = u.TimeElapsedInGuessing 
                                            }
                            ).Take(10).AsNoTracking().ToList();

                return queryTop10GameScores;
            }
        }
    }
}
