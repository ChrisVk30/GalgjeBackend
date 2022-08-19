using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;

namespace GalgjeGame.Core.Services
{
    public class WordsService : IWordsService
    {
        public IWordsRepository WordsRepository;
        public WordsService(IWordsRepository wordsRepository)
        {
            WordsRepository = wordsRepository;
        }

        public async Task<Word> AddNewWordIfNotExistsAsync(string word)
        {
            Word Word = new Word { Value = word };
            var input = await WordsRepository.GetWordByNameAsync(Word);
            if (input == null)
            {
                input = await WordsRepository.AddNewWordAsync(Word);
            }
            return input;
        }

        public async Task<IEnumerable<Word>> GetAllWordsAsync()
        {
            return await WordsRepository.GetAllAsync();
        }
    }
}
