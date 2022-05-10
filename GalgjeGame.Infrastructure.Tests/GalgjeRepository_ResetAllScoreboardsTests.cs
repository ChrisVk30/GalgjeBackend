using GalgjeGame.Core;
using GalgjeGame.Infrastructure.Data;
using GalgjeGame.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GalgjeGame.Infrastructure.Tests
{
    [TestClass]
    public class GalgjeRepository_ResetAllScoreboardsTests
    {
        private SqliteConnection connection;
        private DbContextOptions<GalgjeContext> _options = null;

        [TestInitialize]
        public void TestInitialize()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            _options = new DbContextOptionsBuilder<GalgjeContext>()
                .UseSqlite(connection)
                .Options;
        }
        [TestCleanup]
        public void TestCleanup()
        {
            connection.Dispose();
        }

        [TestMethod]
        public void After_Reset_Overall_Scoreboard_Should_Be_Containing_0_Rows_Of_Data()
        {
            using (var context = new GalgjeContext(_options))
            { 
                context.Database.EnsureCreated(); 
                var sut = new GalgjeRepository(_options); 
                context.UserOverallScores.Add(new UserOverallScore { UserName = "Peter", TimesPlayed = 10, WordsGuessed = 0 }); 
                context.UserOverallScores.Add(new UserOverallScore { UserName = "Henk", TimesPlayed = 15, WordsGuessed = 1 }); 
                context.SaveChanges(); 
                sut.ResetAllScoreboards(); 
                Assert.AreEqual(0, context.UserOverallScores.ToList().Count()); 
            }
        }

        [TestMethod]
        public void After_Reset_Game_Scoreboard_Should_Be_Containing_0_Rows_Of_Data()
        {
            using (var context = new GalgjeContext(_options))
            {
                context.Database.EnsureCreated();
                var sut = new GalgjeRepository(_options);
                context.UserOverallScores.Add(new UserOverallScore { UserName = "Peter", TimesPlayed = 3, WordsGuessed = 2 });
                context.UserOverallScores.Add(new UserOverallScore { UserName = "Henk", TimesPlayed = 1, WordsGuessed = 1 });
                context.UserGameScores.Add(new UserGameScore { UserName = "Peter", IncorrectGuesses = 4, TimeElapsedInGuessing = 14 });
                context.UserGameScores.Add(new UserGameScore { UserName = "Peter", IncorrectGuesses = 4, TimeElapsedInGuessing = 11 });
                context.UserGameScores.Add(new UserGameScore { UserName = "Henk", IncorrectGuesses = 1, TimeElapsedInGuessing = 32 });
                context.SaveChanges();
                sut.ResetAllScoreboards();
                Assert.AreEqual(0, context.UserGameScores.ToList().Count());
            }
        }
    }
}
