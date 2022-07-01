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
        //private UserInputValidation _inputValidator;
        //public PlayerView()
        //{
        //    _inputValidator = new UserInputValidation();
        //}
        public string PlayerName
        { 
            get 
            { 
                Console.WriteLine("What will be your username?: "); 
                return Console.ReadLine();
            } 
        } 
    }
}

