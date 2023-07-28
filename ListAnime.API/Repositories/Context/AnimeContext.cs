using System;
using ListAnime.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ListAnime.API.Repositories.Context
{
	public class AnimeContext: DbContext
	{

        private readonly IConfiguration _configuration;

        public AnimeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<AnimeModel>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.AnimeName).IsRequired();
                    entity.HasIndex(e => e.AnimeName).IsUnique();

                });
        }

        public DbSet<AnimeModel> Animes { get; set; }

    }
}

