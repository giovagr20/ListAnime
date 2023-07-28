using System;
using ListAnime.API.Models;

namespace ListAnime.API.Repositories
{
	public interface IRepository
	{
        Task<bool> SaveAsync(AnimeModel animeModel);

        Task<List<AnimeModel>> GetAsync();

        Task<AnimeModel> GetByIdAsync(int id);

        Task<AnimeModel> UpdateAsync(AnimeModel animeModel);
        Task DeleteAsync(int id);

    }
}

