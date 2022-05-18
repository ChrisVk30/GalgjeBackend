using GalgjeGame.Core;
using GalgjeGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Views
{
    public class PlayerView
    {
        private UserInputValidation inputValidator;
        public PlayerView()
        {
            this.inputValidator = new UserInputValidation();
        }
        public string RequestUserName()
        {
            Console.WriteLine("What will be your username?");
            return Console.ReadLine();
        }

        public char RequestLetter(Game game)
        {
            Console.WriteLine($"\n{game.Player.UserName}, please choose a new letter to guess the word: ");
            char chosenLetter = Console.ReadKey().KeyChar;
            inputValidator.VerifyChosenLetter(chosenLetter, game);
            return chosenLetter;
        }
    }
}
