using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;


namespace GalgjeGame.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IWordsRepository wordRepository;
        private readonly IGameRepository gameRepository;
        public GameService(IWordsRepository wordsRepository, IGameRepository gameRepository)
        {
            this.wordRepository = wordsRepository;
            this.gameRepository = gameRepository;
        }

        public async Task<Game> GetGameByIdAsync(long gameId)
        {
            return await gameRepository.GetGameByIdAsync(gameId);
        }

        public async Task<Game> CreateGameAsync(Player player)
        {
            Game game = new() { PlayerId = player.PlayerId };
            game.SecretWord = wordRepository.GetWordToGuess();
            game.TimeStarted = DateTime.Now;
            return await gameRepository.AddGameAsync(game);
        }
        public async Task<Game> UpdateGameAsync(long gameId, char letter)
        {
            Game game = await gameRepository.GetGameByIdAsync(gameId);
            game.GuessLetter(letter);
            game.UpdateGameStatus();
            return await gameRepository.UpdateGameAsync(game);
        }
    }
}
