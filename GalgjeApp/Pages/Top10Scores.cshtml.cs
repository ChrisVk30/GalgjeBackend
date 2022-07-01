using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalgjeApp.Pages
{
    public class Top10ScoresModel : PageModel
    {
        public IPlayerStatsService StatsService { get; set; }
        public IEnumerable<PlayerStats> Scores { get; set; }
        public Top10ScoresModel(IPlayerStatsService playerStatsService)
        {
            StatsService = playerStatsService;
        }
        public async void OnGetAsync()
        {
            Scores = await StatsService.GetTop10Scores();
        }
    }
}
