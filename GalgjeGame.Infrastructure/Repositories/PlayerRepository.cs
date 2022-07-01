using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayersRepository
    {
        private GalgjeContext _context;
        public PlayerRepository(GalgjeContext context)
        {
            _context = context;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<IQueryable<Player>> GetAllPlayersAsync()
        {
            return _context.Players.AsQueryable();
        }

        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
        }

        public async Task<Player> GetPlayerByName(string playerName)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.UserName == playerName);
        }
    }
}
