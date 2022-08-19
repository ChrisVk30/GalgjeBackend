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
    //public class GalgjeRepository_AddUserToGameScoreboardTests
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
    //        _existingUser = new UserGameScore { UserName = "Chris", IncorrectGuesses = 2, TimeElapsedInGuessing = 12 };
    //    }
    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        connection.Dispose();
    //    }
    //    [TestMethod]
    //    public void New_User_Is_Added_To_UserOverallScores_Table_No_Matter_If_A_Record_Of_User_Already_Exists()
    //    {
    //        using (var context = new GalgjeContext(_options))
    //        {
    //            context.Database.EnsureCreated();
    //            var sut = new GalgjeRepository(_options);
    //            context.SaveChanges();
    //            sut.AddUserToOverallScoreboard(_existingUser);
    //            sut.AddUserToGameScoreboard(_existingUser);
    //            sut.AddUserToGameScoreboard(_newUser);
    //            Assert.AreEqual(2, context.UserGameScores.ToList().Count());
    //            Assert.AreEqual(true, context.UserGameScores.Any(u => u.IncorrectGuesses == 0));
    //        }
    //    }
    //}
}
