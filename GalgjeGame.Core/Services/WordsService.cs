using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;

namespace GalgjeGame.Core.Services
{
    public class WordsService : IWordsService
    {
        private readonly IWordsRepository WordsRepository;
        public WordsService(IWordsRepository wordsRepository)
        {
            WordsRepository = wordsRepository;
        }
        public async Task<Word> AddNewWordIfNotExistsAsync(string input)
        {
            var word = new Word { Value = input };
            var response = await WordsRepository.GetWordByNameAsync(word);
            if (response == null)
            {
                response = await WordsRepository.AddNewWordAsync(word);
            }
            return response;
        }
    }
}
