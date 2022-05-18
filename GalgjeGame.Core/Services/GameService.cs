using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Core.Services
{
    public class GameService
    {
        private readonly IWordsRepository repository;
        public GameService(IWordsRepository wordsRepository) {
            this.repository = wordsRepository;   
        }
        public Game CreateGame() {
            Game result = new ();
            result.SecretWord = repository.GetWordToGuess();
            return result;
        }
    }
}
