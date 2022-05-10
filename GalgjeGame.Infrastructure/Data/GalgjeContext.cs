using GalgjeGame.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalgjeGame.Infrastructure.Data;

public class GalgjeContext : DbContext
{
    public GalgjeContext() { }
    public GalgjeContext(DbContextOptions<GalgjeContext> options)
    : base(options)
    {
    }
    public DbSet<Word> WordsToBeGuessed { get; set; }
    public DbSet<UserGameScore> UserGameScores { get; set; }
    public DbSet<UserOverallScore> UserOverallScores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder();
            builder
                .AddJsonFile("appsettings.json");
            var connectionString = builder.Build();

            optionsBuilder.UseSqlServer(connectionString.GetConnectionString("GalgjeDatabase"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration<Word>(new WordsMapping());
        modelBuilder.ApplyConfiguration<UserGameScore>(new UserScoreMapping());
        modelBuilder.ApplyConfiguration<UserOverallScore>(new UserOverallMapping());

        modelBuilder.Entity<UserGameScore>()
            .HasOne(g => g.userOverallScore)
            .WithMany(o => o.userGameScores)
            .HasForeignKey(g => g.UserName);

    }
}

