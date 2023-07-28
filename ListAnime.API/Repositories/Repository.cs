using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using ListAnime.API.Models;
using ListAnime.API.Repositories.Context;

namespace ListAnime.API.Repositories
{
	public class Repository : IRepository
	{
        private readonly AnimeContext _animeContext;

        public Repository(AnimeContext animeContext)
        {
            _animeContext = animeContext;
        }

        public async Task DeleteAsync(int id)
        {
            var anime = await _animeContext.Animes.FirstOrDefaultAsync(t => t.Id == id);

            if (anime == null)
            {
                throw new Exception("Error");
            }
            _animeContext.Remove(anime);
            await _animeContext.SaveChangesAsync();
        }

        public async Task<List<AnimeModel>> GetAsync()
        {
            return await _animeContext.Animes.AsQueryable()
                .OrderBy(anime => anime.AnimeName)
                .ToListAsync();
        }

        public async Task<AnimeModel> GetByIdAsync(int id)
        {
            AnimeModel? animeModel = await _animeContext.Animes.FirstOrDefaultAsync(anime => anime.Id == id);

            if (animeModel == null)
            {
                return new AnimeModel();
            }

            return animeModel;
        }

        public async Task<bool> SaveAsync(AnimeModel animeModel)
        {
            _animeContext.Animes.Add(animeModel);
            await _animeContext.SaveChangesAsync();

            return true;
        }

        public async Task<AnimeModel> UpdateAsync(AnimeModel animeModel)
        {
            _animeContext.Update(animeModel);
            await _animeContext.SaveChangesAsync();

            return animeModel;
        }


    }
}

