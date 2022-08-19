using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalgjeApp.APIs
{

	[Route("api/words")]
	[ApiController]
	public class WordsAPI : ControllerBase
	{
		private IWordsService _wordsService;
		public WordsAPI(IWordsService wordsService)
		{
            _wordsService = wordsService;
		}

		[HttpGet]
		public async Task<IEnumerable<Word>> GetAll()
		{
			return await _wordsService.GetAllWordsAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Word>> AddWord(Word word) 
		{ 
			return await _wordsService.AddNewWordIfNotExistsAsync(word.Value);
		}

    }
}
