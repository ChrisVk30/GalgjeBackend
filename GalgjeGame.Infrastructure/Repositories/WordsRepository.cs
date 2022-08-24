using GalgjeGame.Core.Entities;
using GalgjeGame.Core.Interfaces;
using GalgjeGame.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GalgjeGame.Infrastructure.Repositories
{
    public class WordsRepository : IWordsRepository
    {
        private readonly GalgjeContext _context;
        public WordsRepository(GalgjeContext context)
        {
            _context = context;
        }
        public string GetWordToGuess()
        {
                var returnWord = new SqlParameter()
                {
                    ParameterName = "Value",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var resultNew = _context.Set<Word>().FromSqlRaw("EXEC [dbo].[SPC_GetWordToGuess] @Value OUTPUT", returnWord).ToList();
                return resultNew.First().Value;
        }

        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _context.WordsToBeGuessed.ToListAsync();
        }

        public async Task<Word> GetWordByNameAsync(Word word)
        {
            return await _context.WordsToBeGuessed.FirstOrDefaultAsync(w => w.Value == word.Value);
        }
        public async Task<Word> AddNewWordAsync(Word word)
        {
            _context.WordsToBeGuessed.Add(word);
            await _context.SaveChangesAsync();
            return word;
        }
    }
}
