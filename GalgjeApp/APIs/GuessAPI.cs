using GalgjeGame.Core.DTO;
using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalgjeApp.APIs
{
    [Route("api/game/{id}/guess")]
    [ApiController]
    public class GuessAPI
    { 
        private IGameService _gameService { get; set; }
        public GuessAPI(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> GuessLetter(Guess guess, long id)
        {
            return await _gameService.UpdateGameAsync(id, guess.Letter);
        }
    }
}
