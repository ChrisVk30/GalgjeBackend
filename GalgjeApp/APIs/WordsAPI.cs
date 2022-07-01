using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalgjeApp.APIs
{

	[Route("api/words")]
	[ApiController]
	public class WordsAPI : ControllerBase
	{
		private IWordsRepository _repository;
		public WordsAPI(IWordsRepository televisionRepository)
		{
			_repository = televisionRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Word>> GetAll()
		{
			return await _repository.GetAllAsync();
		}
	}
}
