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
    //public class GalgjeRepository_AddUserToOverallScoreboardTests
    //{
    //    private SqliteConnection connection;
    //    private DbContextOptions<GalgjeContext> _options = null;
    //    UserGameScore _newUser;
    //    UserGameScore _existingUser;

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        connection = new SqliteConnection("DataSource=:memory:");
    //        connection.Open();
    //        _options = new DbContextOptionsBuilder<GalgjeContext>()
    //            .UseSqlite(connection)
    //            .Options;

    //        _newUser = new UserGameScore { UserName = "Chris", IncorrectGuesses = 0, TimeElapsedInGuessing = 5 };
    //        _existingUser = new UserGameScore { UserName = "Peter", IncorrectGuesses = 0, TimeElapsedInGuessing = 5 };
    //    }
    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        connection.Dispose();
    //    }
    //    [TestMethod]
    //    public void New_User_Is_Added_To_UserOverallScores_Table_If_Record_Of_Username_Doesnt_Exist_Yet()
    //    {
    //        using (var context = new GalgjeContext(_options))
    //        {
    //            context.Database.EnsureCreated();
    //            var sut = new GalgjeRepository(_options);
    //            context.UserOverallScores.Add(new UserOverallScore { UserName = "Peter", TimesPlayed = 10, WordsGuessed = 0 });
    //            context.SaveChanges();
    //            sut.AddUserToOverallScoreboard(_newUser);
    //            Assert.AreEqual(2, context.UserOverallScores.ToList().Count());
    //        }
    //    }

    //    [TestMethod]
    //    public void Existing_User_Is_Not_Added_To_UserOverallScores_Table_As_Record_Of_Username_Already_Exists()
    //    {
    //        using (var context = new GalgjeContext(_options))
    //        {
    //            context.Database.EnsureCreated();
    //            var sut = new GalgjeRepository(_options);
    //            context.UserOverallScores.Add(new UserOverallScore { UserName = "Peter", TimesPlayed = 10, WordsGuessed = 0 });
    //            context.SaveChanges();
    //            sut.AddUserToOverallScoreboard(_existingUser);
    //            Assert.AreEqual(1, context.UserOverallScores.ToList().Count());
    //        }
    //    }

    //}
}
