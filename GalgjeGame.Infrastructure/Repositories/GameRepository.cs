using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private GalgjeContext _context;

        public GameRepository(GalgjeContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> GetGameByIdAsync(long id)
        {
            return await _context.Games.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<Game>> GetAllGamesAsync()
        {
            return _context.Games.AsQueryable();
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}
