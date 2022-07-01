using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Interfaces
{
    public interface IPlayersRepository
    {
        Task<Player> AddPlayer(Player player);
        Task<IQueryable<Player>> GetAllPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int playerId);
        Task<Player> GetPlayerByName(string playerName);
            
    }
}