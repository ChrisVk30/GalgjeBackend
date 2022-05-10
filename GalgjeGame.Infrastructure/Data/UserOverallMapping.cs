using GalgjeGame.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GalgjeGame.Infrastructure.Data
{
    internal class UserOverallMapping : IEntityTypeConfiguration<UserOverallScore>
    {
        public void Configure(EntityTypeBuilder<UserOverallScore> builder)
        {
            builder.
                HasKey("UserName");

            builder.Property("UserName").
                HasColumnType("nvarchar(100)");

            builder.
                Ignore("Ratio");
                
        }
    }
}