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
        public IPlayerService PlayerService { get; set; }
        public IGameService GameService { get; set; }
        public GameAPI(IPlayerService playerService, IGameService gameService)
        {
            PlayerService = playerService;
            GameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateNewGame(PlayerObj playerObj)
        {
            var player = await PlayerService.FindPlayer(playerObj.Username);
            return await GameService.CreateGameAsync(player);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Game>> GetGame(long id)
        {
            return await GameService.GetGameByIdAsync(id);
        }

        
    }
}
