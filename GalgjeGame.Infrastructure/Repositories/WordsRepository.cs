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
        private readonly DbContextOptions<GalgjeContext> _options;

        public WordsRepository(DbContextOptions<GalgjeContext> options)
        {
            _options = options;
        }
        public string GetWordToGuess()
        {
            using (var context = new GalgjeContext(_options))
            {
                var returnWord = new SqlParameter()
                {
                    ParameterName = "Value",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                var resultNew = context.Set<Word>().FromSqlRaw("EXEC [dbo].[SP_GetWordToGuess] @Value OUTPUT", returnWord).ToList();
                return resultNew.First().Value;
            }
        }
    }
}
