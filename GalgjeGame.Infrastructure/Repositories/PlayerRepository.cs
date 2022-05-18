using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayersRepository
    {
        private readonly DbContextOptions<GalgjeContext> _options;
        public PlayerRepository(DbContextOptions<GalgjeContext> options)
        {
            _options = options;
        }
        public async Task<Player> AddPlayer(Player player)
        {
            using (var context = new GalgjeContext(_options))
            {
                context.Players.Add(player);
                context.SaveChanges();
                return player;
            }
        }

        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            using (var context = new GalgjeContext(_options))
            {
                return await context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
            }
        }

        public async Task<Player> GetPlayerByName(string playerName)
        {
            using (var context = new GalgjeContext(_options))
            {
                return await context.Players.FirstOrDefaultAsync(p => p.UserName == playerName);
            }
        }
    }
}
