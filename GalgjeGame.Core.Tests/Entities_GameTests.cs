using GalgjeGame.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalgjeGame.Core.Tests
{
    [TestClass]
    public class Entities_GameTests
    {
        private Game _game;

        [TestInitialize]
        public void TestInitialize()
        {
            _game = new Game();
            _game.SecretWord = "pan";
        }

        [TestMethod]
        [DataRow('p')]
        [DataRow('a')]
        [DataRow('n')]
        public void GuessLetter_LetterInSecretWord_AddsLetterToRightLetters(char value1)
        {
            _game.GuessLetter(value1);
            Assert.IsTrue(_game.RightLetters.Contains(value1));
            Assert.IsTrue(!_game.WrongLetters.Contains(value1));
        }

        [TestMethod]
        [DataRow('b')]
        [DataRow('d')]
        [DataRow('f')]
        public void GuessLetter_LetterNotInSecretWord_AddsLetterToWrongLetters(char value1)
        {
            _game.GuessLetter(value1);
            Assert.IsTrue(_game.WrongLetters.Contains(value1));
            Assert.IsTrue(!_game.RightLetters.Contains(value1));
        }

        [TestMethod]
        public void CheckGameStatus_SecretWordEqualsGuessedWord_GameStatusEqualsWon()
        {
            _game.GuessLetter('p');
            _game.GuessLetter('a');
            _game.GuessLetter('n');
            _game.UpdateGameStatus();
            Assert.IsTrue(_game.Status.Equals(Game.GameStatus.Won));
            Assert.IsTrue(!_game.Status.Equals(Game.GameStatus.InProgress));

        }

        [TestMethod]
        public void CheckGameStatus_IncorrectGuessesEquals7_GameStatusEqualsLost()
        {
            _game.WrongLetters = "abcdefg";
            _game.UpdateGameStatus();
            Assert.IsTrue(_game.Status.Equals(Game.GameStatus.Lost));
            Assert.IsTrue(!_game.Status.Equals(Game.GameStatus.InProgress));
        }
        
    }
}
