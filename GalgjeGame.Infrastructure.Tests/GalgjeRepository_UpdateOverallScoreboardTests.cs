using GalgjeGame.Core;
using GalgjeGame.Infrastructure.Data;
using GalgjeGame.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GalgjeGame.Infrastructure.Tests
{
    //[TestClass]
    //public class GalgjeRepository_UpdateOverallScoreboardTests
    //{
    //    private SqliteConnection connection;
    //    private DbContextOptions<GalgjeContext> _options = null;
    //    UserGameScore _winningUser;
    //    UserGameScore _losingUser;

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        connection = new SqliteConnection("DataSource=:memory:");
    //        connection.Open();
    //        _options = new DbContextOptionsBuilder<GalgjeContext>()
    //            .UseSqlite(connection)
    //            .Options;

    //        _winningUser = new UserGameScore { UserName = "Chris", IncorrectGuesses = 0, TimeElapsedInGuessing = 5 };
    //        _losingUser = new UserGameScore { UserName = "Chris", IncorrectGuesses = 7, TimeElapsedInGuessing = 5 };
    //    }
    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        connection.Dispose();
    //    }
    //    [TestMethod]
    //    public void Times_Played_Should_Be_Set_To_One_When_User_Played_For_First_Time()
    //    {
    //        using (var context = new GalgjeContext(_options))
    //        {
    //            context.Database.EnsureCreated();
    //            var sut = new GalgjeRepository(_options);
    //            sut.AddUserToOverallScoreboard(_winningUser);
    //            sut.UpdateOverallScoreboard(_winningUser);
    //            Assert.AreEqual(1, (context.UserOverallScores.Where(x => x.UserName == _winningUser.UserName).Select(x => x.TimesPlayed).FirstOrDefault()));
    //        }
    //    }

    //    [TestMethod]
    //    public void Times_Played_Should_Be_Upped_By_One_When_User_Already_Played_Before()
    //    {
    //        using (var context = new GalgjeContext(_options))
    //        {
    //            context.Database.EnsureCreated();
    //            var sut = new GalgjeRepository(_options);
    //            context.UserOverallScores.Add(new UserOverallScore { UserName = "Chris", TimesPlayed = 10, WordsGuessed = 10 });
    //            context.SaveChanges();
    //            sut.UpdateOverallScoreboard(_winningUser);
    //            Assert.AreEqual(11, (context.UserOverallScores.Where(x => x.UserName == _winningUser.UserName).Select(x => x.TimesPlayed).FirstOrDefault()));
    //        }
    //    }
    //    [TestMethod]
    //    [DataRow(7, 10, 11)]
    //    [DataRow(2, 11, 11)]
    //    public void WordsGuessedShouldBeUppedByOneWhenUserGuessesWordWithLessThan7IncorrectGuesses(int incorrectGuesses, int WordsGuessed, int TimesPlayed)
    //    {
    //        using (var context = new GalgjeContext(_options))
    //        {
    //            context.Database.EnsureCreated();
    //            var sut = new GalgjeRepository(_options);
    //            context.UserOverallScores.Add(new UserOverallScore { UserName = "Chris", TimesPlayed = 10, WordsGuessed = 10 });
    //            UserGameScore user = new UserGameScore { UserName = "Chris", IncorrectGuesses = incorrectGuesses, TimeElapsedInGuessing = 5 };
    //            context.SaveChanges();
    //            sut.UpdateOverallScoreboard(user);
    //            Assert.AreEqual(WordsGuessed, (context.UserOverallScores.Where(x => x.UserName == _winningUser.UserName).Select(x => x.WordsGuessed).FirstOrDefault()));
    //            Assert.AreEqual(TimesPlayed, (context.UserOverallScores.Where(x => x.UserName == _winningUser.UserName).Select(x => x.TimesPlayed).FirstOrDefault()));
    //        }
    //    }
    //}
}
