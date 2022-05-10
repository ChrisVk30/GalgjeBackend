using System;
using System.Text.RegularExpressions;
using GalgjeGame.Core;

namespace GalgjeGame
{

    public class VerifyMessenger
    {
        public bool VerifyUserInput(Enum toValidateValue)
        {
            if (toValidateValue.Equals(UserInputValidation.ValidationResultUIV.LetterAlreadyChosenError))
            {
                Console.WriteLine("Letter was already chosen before.");
                Thread.Sleep(2000);
                return false;
            }
            else if (toValidateValue.Equals(UserInputValidation.ValidationResultUIV.OnlyLettersError))
            {
                Console.WriteLine("Please enter letters only.");
                Thread.Sleep(2000);
                return false;
            }
            else if (toValidateValue.Equals(UserInputValidation.ValidationResultUIV.MoreThan1LetterError))
            {
                Console.WriteLine("Please enter only 1 letter.");
                Thread.Sleep(2000);
                return false;
            }
            return true;
        }
        public bool VerifyUserNameInput(Enum toValidateValue)
        {
            if (toValidateValue.Equals(UserInputValidation.UserNameValidation.EmptyNameError))
            {
                Console.WriteLine("No user name entered...");
                Thread.Sleep(2000);
                return false;
            }
            else if (toValidateValue.Equals(UserInputValidation.UserNameValidation.NotOnlyLettersError))
            {
                Console.WriteLine("Please only use letters for user name");
                Thread.Sleep(2000);
                return false;
            }
            return true;
        }
    }
}
