using GalgjeGame.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalgjeGame.Infrastructure.Data
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey("Id");
            builder.HasOne(g => g.Player)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PlayerId);
        }
    }
}