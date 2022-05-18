using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;

namespace GalgjeGame.Core.Services
{
    public class PlayerService
    {
        private readonly IPlayersRepository repository;
        private readonly UserInputValidation inputValidator;
        public PlayerService(IPlayersRepository playersRepository)
        {
            this.repository = repository;
            this.inputValidator = new UserInputValidation();
        }
        public Player CreatePlayer(string username, Game game)
        {
            Player player = new();
            inputValidator.VerifyUserName(username);
            player.UserName = username;
            game.Player = player;
            return player;
        }
    }
}
