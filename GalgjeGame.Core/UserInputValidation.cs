using GalgjeGame;
using GalgjeGame.Core.Entities;
using System.Text.RegularExpressions;

namespace GalgjeGame.Core
{
    public class UserInputValidation //: IInputValidator
    {
        public void VerifyChosenLetter(char letter, Game game)
        {
            if (game.ChosenLetters.Contains(letter))
            {
                throw new ArgumentException("Letter was already chosen before");
            }
            else if (!Char.IsLetter(letter))
            {
                throw new InvalidDataException("You can only choose letters!");
            }
            else if (Char.IsWhiteSpace(letter))
            {
                throw new InvalidDataException("Cannot insert empty request!");
            }
        }
        public void VerifyUserName(string username)
        {
            if (username == "")
                throw new ArgumentNullException("Name cannot be empty!");
            else if (!Regex.IsMatch(username, @"^[A-Za-z ]+$"))
                throw new InvalidDataException("Name cal only contain letters!");
        }
    }
}
