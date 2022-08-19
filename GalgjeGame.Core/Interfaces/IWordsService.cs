using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Services
{
    public interface IWordsService
    {
        Task<Word> AddNewWordIfNotExistsAsync(string word);
        Task<IEnumerable<Word>> GetAllWordsAsync();
    }
}