using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> AddGameAsync(Game game);
        Task<Game> GetGameByIdAsync(long id);
        Task<Game> UpdateGameAsync(Game game);
        Task<IQueryable<Game>> GetAllGamesAsync();
    }
}