using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core
{
    public class HangmanArt
    {
        public static string[] hangmanPhases = { @"
          +---+
              |
              |
              |
              |
              |
        =========", @"
          +---+
          |   |
              |
              |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
              |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
          |   |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|   |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|\  |
              |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|\  |
         /    |
              |
        =========", @"
          +---+
          |   |
          O   |
         /|\  |
         / \  |
              |
        =========" };
    }
}
