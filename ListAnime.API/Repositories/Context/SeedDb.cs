using System;
using ListAnime.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ListAnime.API.Repositories.Context
{
	public class SeedDb
	{
		private readonly AnimeContext _animeContext;

        public SeedDb(AnimeContext animeContext)
        {
            _animeContext = animeContext;
        }

        public async Task SeedAsync()
        {
            await _animeContext.Database.EnsureCreatedAsync();
    
            await CreateAnime();

        }

        public async Task CreateAnime() 
        {
            if (!_animeContext.Animes.Any())
            {
                var anime = new AnimeModel()
                {
                    AnimeName = "Naruto Shippuden",
                    Description = "About ninjas and wars",
                    HasSeasons = true,
                    PictureUrl = "<url:here>",
                    TotalSeasons = 3
                };

                _animeContext.Animes.Add(anime);
                await _animeContext.SaveChangesAsync();

            }

        }
    }
}

