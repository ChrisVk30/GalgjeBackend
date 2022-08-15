using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalgjeApp.Pages
{
    public class GameModel : PageModel
    {
        private IGameRepository GameRepository { get; set; }
        private IGameService GameService { get; set; }
        [BindProperty]
        public Guess Guess { get; set; }
        public Game Game { get; set; }
        public string ImagePath { get { return @$"/Images/hangman_phase{Game.IncorrectGuesses}.jpg"; } }
        public GameModel(IGameRepository gameRepository, IGameService gameService)
        {
            GameRepository = gameRepository;
            GameService = gameService;
        }
        public async Task<IActionResult> OnGet(long Id)
        {
            Game = await GameService.GetGameByIdAsync(Id);
            return Page();
        }
        public async Task<IActionResult> OnGetGamePageAsync(long Id)
        {
            Game = await GameService.GetGameByIdAsync(Id);
            return Page();
        }
        public async Task<IActionResult> OnPost(long Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var letter = Guess.Letter;
            Game = await GameService.UpdateGameAsync(Id, letter);
            return Page();
        }
    }
}
