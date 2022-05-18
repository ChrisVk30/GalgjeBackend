using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using GalgjeGame.Core;
using GalgjeGame.Infrastructure.Data;
using GalgjeGame.Core.Entities;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class GameRepository
    {
        private readonly DbContextOptions<GalgjeContext> _options;

        public GameRepository(DbContextOptions<GalgjeContext> options)
        {
            _options = options;
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            using (var context = new GalgjeContext(_options))
            {
                await context.Games.AddAsync(game);
                await context.SaveChangesAsync();
                return game;
            }
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            using (var context = new GalgjeContext(_options))
            {
                return await context.Games.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            using (var context = new GalgjeContext(_options))
            {
                context.Games.Update(game);
                await context.SaveChangesAsync();
                return game;
            }
        }
    }
}
