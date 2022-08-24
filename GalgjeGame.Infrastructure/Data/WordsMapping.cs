using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GalgjeGame.Core;
using GalgjeGame.Core.Entities;
using static GalgjeGame.Core.Entities.Game;

namespace GalgjeGame.Infrastructure.Data
{
    public class WordsMapping : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder
                .ToTable("WordsToBeGuessed")
                .HasKey("Value");

            builder
                .Property(w => w.Value)
                .HasColumnType("nvarchar(100)");

            List<Word> words = new() {
            new(){ Value = "pannenkoek"},
            new(){ Value = "tankstation"},
            new(){ Value = "tijdperk"},
            new(){ Value = "kenniscentrum"},
            new(){ Value = "achterklap"},
            new(){ Value = "circustent"},
            new(){ Value = "rijsttafel"},
            new(){ Value = "garagehouder"},
            new(){ Value = "quizmaster"},
            new(){ Value = "beddenwinkel"}
        };
            builder.HasData(words);
        }
    }
}