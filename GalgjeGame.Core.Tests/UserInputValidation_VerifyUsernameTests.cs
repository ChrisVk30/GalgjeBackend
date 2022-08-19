using GalgjeGame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Tests
{
    //[TestClass]
    //public class UserInputValidation_VerifyUsernameTests
    //{
    //    UserInputValidation _inputValidator;

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        _inputValidator = new UserInputValidation();
    //    }

    //    [TestMethod]
    //    [DataRow("", UserInputValidation.UserNameValidation.EmptyNameError)]
    //    [DataRow("Bert", UserInputValidation.UserNameValidation.Success)]
    //    public void Entering_UserName_Of_Empty_String_Should_Return_EmptyNameError(string value1, UserInputValidation.UserNameValidation value2)
    //    {
    //        var actual = _inputValidator.VerifyUserName(value1);
    //        var expected = value2;
    //    }

    //    [TestMethod]
    //    [DataRow("Bert123", UserInputValidation.UserNameValidation.NotOnlyLettersError)]
    //    [DataRow("Bert", UserInputValidation.UserNameValidation.Success)]
    //    [DataRow("Bert Ernie", UserInputValidation.UserNameValidation.Success)]
    //    public void Entering_UserName_With_Other_Characters_Than_Numbers_And_Whitespaces_Should_Return_NotOnlyLettersError(string value1, UserInputValidation.UserNameValidation value2)
    //    {
    //        var actual = _inputValidator.VerifyUserName(value1);
    //        var expected = value2;
    //    }
    //}
}
