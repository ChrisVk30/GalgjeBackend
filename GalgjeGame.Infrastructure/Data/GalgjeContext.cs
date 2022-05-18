﻿using GalgjeGame.Core;
using GalgjeGame.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GalgjeGame.Infrastructure.Data;

public class GalgjeContext : DbContext
{
    public GalgjeContext() { }
    public GalgjeContext(DbContextOptions<GalgjeContext> options)
    : base(options)
    {
    }
    public DbSet<Word> WordsToBeGuessed { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }

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
        //modelBuilder.ApplyConfiguration<UserGameScore>(new UserScoreMapping());
        //modelBuilder.ApplyConfiguration<UserOverallScore>(new UserOverallMapping());

        //modelBuilder.Entity<UserGameScore>()
        //    .HasOne(g => g.userOverallScore)
        //    .WithMany(o => o.userGameScores)
        //    .HasForeignKey(g => g.UserName);

    }
}

