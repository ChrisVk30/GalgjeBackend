using GalgjeGame;
using System.Text.RegularExpressions;

namespace GalgjeGame.Core
{
    public class UserInputValidation //: IInputValidator
    {
        public ValidationResultUIV VerifyChosenLetter(string userInput, UserGameScore user)
        {
            string userGuess = userInput.Trim().ToLower();

            if (user.guessedLetters.Contains(userGuess))
            {
                return ValidationResultUIV.LetterAlreadyChosenError;
            }
            else if (!Regex.IsMatch(userGuess, @"^[a-z]+$"))
            {
                return ValidationResultUIV.OnlyLettersError;
            }
            else if (userGuess.Length > 1)
            {
                return ValidationResultUIV.MoreThan1LetterError;
            }
            user.guessedLetters.Add(userGuess);
            return ValidationResultUIV.Success;
        }
        public UserNameValidation VerifyUserName(string username)
        {
            if (username == "")
                return UserNameValidation.EmptyNameError;
            else if (!Regex.IsMatch(username, @"^[A-Za-z ]+$"))
                return UserNameValidation.NotOnlyLettersError;
            return UserNameValidation.Success;
        }
        public enum ValidationResultUIV { Success, LetterAlreadyChosenError, OnlyLettersError, MoreThan1LetterError }
        public enum UserNameValidation { Success, EmptyNameError, NotOnlyLettersError }
    }
}
