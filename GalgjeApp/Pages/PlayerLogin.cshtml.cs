using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalgjeApp.Pages
{
    public class PlayerLoginModel : PageModel
    {
        [BindProperty]
        public Player Player { get; set; }
        public Game Game { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IGameService GameService { get; set; }
        public PlayerLoginModel(IPlayerService playerService, IGameService gameService)
        {
            PlayerService = playerService;
            GameService = gameService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var playerName = Player.UserName;
            Player = await PlayerService.FindPlayer(playerName);
            Game = await GameService.CreateGameAsync(Player);
            return RedirectToPage("Game", "GamePage", new {id = Game.Id});
        }
    }
}
