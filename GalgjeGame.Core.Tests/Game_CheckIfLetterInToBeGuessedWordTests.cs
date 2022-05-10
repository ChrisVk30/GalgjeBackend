using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Tests
{
    [TestClass]
    public class Game_CheckIfLetterInToBeGuessedWordTests
    {
        Game _game;
        UserGameScore _user;
        string[] AnonymousGuessedWord { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            _game = new Game();
            _user = new UserGameScore();
        }

        [TestMethod]
        [DataRow("water","a"," _ a _ _ _")]
        [DataRow("water", "z", " _ _ _ _ _")]
        [DataRow("knoflook", "k", " k _ _ _ _ _ _ k")]
        public void Entering_A_Letter_That_Exists_In_The_WordToGuess_Should_Update_Underscores_In_HiddenWord(string value1, string value2, string value3)
        {
            _game.CreateHiddenWord(value1);
            var actual = _game.CheckIfLetterInToBeGuessedWord(value2, value1, _user);
            var expected = value3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("water", "a", 0)]
        [DataRow("water", "z", 1)]
        [DataRow("knoflook", "k", 0)]
        public void Entering_A_Letter_That_Doesnt_Exist_In_The_WordToGuess_Should_Update_Incorrect_Guesses_On_User(string value1, string value2, int value3)
        {
            _game.CreateHiddenWord(value1);
            _game.CheckIfLetterInToBeGuessedWord(value2, value1, _user);
            var actual = _user.IncorrectGuesses;
            var expected = value3;

            Assert.AreEqual(expected, actual);
        }
    }
}
