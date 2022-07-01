using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GalgjeApp.Pages
{
    public class WordsModel : PageModel
    {
        public IWordsService WordsService { get; set; }
        public WordsModel(IWordsService wordsService)
        {
            WordsService = wordsService;
        }

        HttpClient httpClient = new HttpClient();

        [BindProperty]
        public Word Word { get; set; }
        public List<Word> Words { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Words = await httpClient.GetFromJsonAsync<List<Word>>("https://localhost:7044/api/words");
     
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }
            var userInput = Word.Value;
            await WordsService.AddNewWordIfNotExistsAsync(userInput);
            return RedirectToPage();
        }
    }
}
