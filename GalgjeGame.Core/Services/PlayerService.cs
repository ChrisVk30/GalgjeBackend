using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;

namespace GalgjeGame.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayersRepository _repository;
        public PlayerService(IPlayersRepository playersRepository)
        {
            _repository = playersRepository;
        }
        public async Task<Player> FindPlayer(string username)
        {
            var user = await _repository.GetPlayerByName(username);
            if (user == null)
            {
                Player player = new() { UserName = username };
                await _repository.AddPlayer(player);
                return player;
            }
            return user;
        }
    }
}
