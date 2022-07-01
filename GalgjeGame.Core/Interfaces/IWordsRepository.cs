using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Interfaces
{
    public interface IWordsRepository
    {
        string GetWordToGuess();
        Task<IEnumerable<Word>> GetAllAsync();
        Task<Word> GetWordByNameAsync(Word word);
        Task<Word> AddNewWordAsync(Word word);
    }
}
