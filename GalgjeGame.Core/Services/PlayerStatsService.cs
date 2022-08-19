using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using System.Text;
using static GalgjeGame.Core.Entities.Game;

namespace GalgjeGame.Core.Services
{
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly IPlayersRepository _playerRepository;
        private readonly IGameRepository _gameRepository;
        public PlayerStatsService(IPlayersRepository playerStatsRepository, IGameRepository gameRepository)
        {
            _playerRepository = playerStatsRepository;
            _gameRepository = gameRepository;
        }
        public async Task<IEnumerable<PlayerStats>> GetTop10Players()
        {
            IQueryable<Player> allPlayers = await _playerRepository.GetAllPlayersAsync();
            IQueryable<Game> allGames = await _gameRepository.GetAllGamesAsync();
            var queryTop10OverallScores = (from a in allGames
                                           join b in allPlayers
                                           on a.PlayerId equals b.PlayerId
                                           where a.Status != GameStatus.InProgress
                                           let guessedWords = allGames.Count(x => x.PlayerId == a.PlayerId && x.Status == GameStatus.Won)
                                           let notGuessedWords = allGames.Count(x => x.PlayerId == a.PlayerId && x.Status == GameStatus.Lost)
                                           select new
                                           {
                                               UserName = b.UserName,
                                               Ratio = Math.Round((guessedWords / (double)(guessedWords + notGuessedWords)) * 100, 2),
                                               WordsGuessed = guessedWords
                                           } into scores
                                           orderby scores.Ratio descending, scores.WordsGuessed descending, scores.UserName ascending
                                           select new PlayerStats() { UserName = scores.UserName, Ratio = scores.Ratio, GuessedWords = scores.WordsGuessed }
                             ).Distinct().Take(10).ToList();

            return queryTop10OverallScores.OrderByDescending(s => s.Ratio).ThenByDescending(w => w.GuessedWords).ThenBy(u => u.UserName);
        }
        public async Task<IEnumerable<PlayerStats>> GetTop10Scores()
        {
            IQueryable<Player> allPlayers = await _playerRepository.GetAllPlayersAsync();
            IQueryable<Game> allGames = await _gameRepository.GetAllGamesAsync();
            var queryTop10Scores = (from a in allGames
                                    join b in allPlayers
                                    on a.PlayerId equals b.PlayerId
                                    where a.Status == GameStatus.Won
                                    select new
                                    {
                                        UserName = b.UserName,
                                        Time = a.TimeElapsed,
                                        WordLenght = a.SecretWord.Length
                                    } into scores
                                    orderby scores.Time ascending, scores.WordLenght descending
                                    select new PlayerStats() { UserName = scores.UserName, TimeElapsed = scores.Time, WordLength = scores.WordLenght }
                                ).Take(10).ToList();

            return queryTop10Scores;
        }
    }
}