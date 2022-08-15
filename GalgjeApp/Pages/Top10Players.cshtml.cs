using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalgjeApp.Pages
{
    public class Top10PlayersModel : PageModel
    {
        public IPlayersRepository PlayerRepository { get; set; }
        public IGameRepository GameRepository { get; set; }
        public IPlayerStatsService StatsService { get; set; }
        public IEnumerable<PlayerStats> Scores { get; set; }
        public Top10PlayersModel(IPlayerStatsService playerStatsService)
        {
            StatsService = playerStatsService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Scores = await StatsService.GetTop10Players();
            return Page();
        }
    }
}
