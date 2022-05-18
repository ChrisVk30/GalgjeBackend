using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GalgjeGame.Core;
using GalgjeGame.Core.Entities;

namespace GalgjeGame.Infrastructure.Data
{
    public class WordsMapping : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder
                .ToTable("WordsToBeGuessed")
                .HasKey("Value");

            builder.Property(w => w.Value)
                .HasColumnType("nvarchar(100)");
        }
    }
}