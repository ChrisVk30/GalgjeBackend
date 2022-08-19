using GalgjeGame.Core.DTO;
using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalgjeApp.APIs
{
    [Route("api/game")]
    [ApiController]
    public class GameAPI : ControllerBase
    {
        private Player _player { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IGameService GameService { get; set; }
        public GameAPI(IPlayerService playerService, IGameService gameService)
        {
            PlayerService = playerService;
            GameService = gameService;
        }

        [HttpPost]
        [Route("~/api/game/creategame")]
        public async Task<ActionResult<Game>> CreateNewGame(PlayerObj playerObj)
        {
            _player = await PlayerService.FindPlayer(playerObj.Username);
            return await GameService.CreateGameAsync(_player);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Game>> GetGame(long id)
        {
            return await GameService.GetGameByIdAsync(id);
        }

        
    }
}
