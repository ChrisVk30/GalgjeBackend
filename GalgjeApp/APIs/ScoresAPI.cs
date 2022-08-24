using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalgjeApp.APIs
{
    [Route("api/scores")]
    [ApiController]
    public class ScoresAPI
    {
        private IPlayerStatsService _statsService { get; set; }
        public ScoresAPI (IPlayerStatsService playerStatsService)
        {
            _statsService = playerStatsService;
        }

        [Route("top10players")]
        public async Task<IEnumerable<PlayerStats>> GetTopPlayers()
        {
            return await _statsService.GetTop10Players();
        }

        [Route("top10scores")]
        public async Task<IEnumerable<PlayerStats>> GetTopScores()
        {
            return await _statsService.GetTop10Scores();
        }
    }
}
