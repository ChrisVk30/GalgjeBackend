using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;

namespace GalgjeGame.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayersRepository _repository;
        //private readonly EncryptService _encryptService;
        public PlayerService(IPlayersRepository playersRepository, EncryptService encryptService)
        {
            _repository = playersRepository;
            //_encryptService = encryptService;
        }
        public async Task<Player> FindPlayer(string username)
        {
            //username = _encryptService.EncryptString(username);
            var user = await _repository.GetPlayerByName(username);
            if (user == null)
            {
                Player player = new() { UserName = username };
                await _repository.AddPlayer(player);
                return player;
            }
            else
            {
                //user.UserName = _encryptService.DecryptString(user.UserName);
                user.UserName = username;
            }
            return user;
        }
    }
}
