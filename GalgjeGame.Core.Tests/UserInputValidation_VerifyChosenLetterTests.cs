using GalgjeGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Tests
{
    //[TestClass]
    //public class UserInputValidation_VerifyChosenLetterTests
    //{ 

    //    UserInputValidation _inputValidator;
    //    UserGameScore _user;

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        _inputValidator = new UserInputValidation();
    //        _user = new UserGameScore();
    //        _inputValidator.VerifyChosenLetter("e", _user);
    //    }
        
    //    [TestMethod]
    //    [DataRow("e", UserInputValidation.ValidationResultUIV.LetterAlreadyChosenError)]
    //    [DataRow("f", UserInputValidation.ValidationResultUIV.Success)]
    //    public void Entering_Letter_That_Was_Already_Chosen_Before_Should_Return_LetterAlreadyChosenError(string value1, UserInputValidation.ValidationResultUIV value2)
    //    {
    //        var actual = _inputValidator.VerifyChosenLetter(value1, _user);
    //        var expected = value2;

    //        Assert.AreEqual(expected, actual);
    //    }

    //    [TestMethod]
    //    [DataRow(".", UserInputValidation.ValidationResultUIV.OnlyLettersError)]
    //    [DataRow("1", UserInputValidation.ValidationResultUIV.OnlyLettersError)]
    //    [DataRow("f", UserInputValidation.ValidationResultUIV.Success)]
    //    public void Entering_A_Character_Other_Than_A_Letter_Should_Return_OnlyLettersError(string value1, UserInputValidation.ValidationResultUIV value2)
    //    {
    //        var actual = _inputValidator.VerifyChosenLetter(value1, _user);
    //        var expected = value2;

    //        Assert.AreEqual(expected, actual);
    //    }

    //    [TestMethod]
    //    [DataRow("abc", UserInputValidation.ValidationResultUIV.MoreThan1LetterError)]
    //    [DataRow("f", UserInputValidation.ValidationResultUIV.Success)]
    //    public void Entering_More_Than_1_Character_Should_Return_MoreThan1LetterError(string value1, UserInputValidation.ValidationResultUIV value2)
    //    {
    //        var actual = _inputValidator.VerifyChosenLetter(value1, _user);
    //        var expected = value2;

    //        Assert.AreEqual(expected, actual);
    //    }

    //    [TestMethod]
    //    [DataRow("e", 1)]
    //    [DataRow("f", 2)]
    //    public void Entering_A_Letter_That_Wasnt_Chosen_Before_Should_Add_Letter_To_GuessedLetters(string value1, int value2)
    //    {
    //        _inputValidator.VerifyChosenLetter(value1, _user);
    //        var actual = _user.guessedLetters.Count();
    //        var expected = value2;

    //        Assert.AreEqual(expected, actual);
    //    }
    //}
}
