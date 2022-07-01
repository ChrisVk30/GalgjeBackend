using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Interfaces
{
    public interface IGameService
    {
        Task<Game> CreateGameAsync(Player player);
        Task<Game> UpdateGameAsync(long gameId, char letter);
        Task<Game> GetGameByIdAsync(long gameId);
    }
}