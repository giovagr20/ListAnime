using System;
using ListAnime.API.Models;

namespace ListAnime.API.Services
{
	public interface IService
	{
        Task<bool> SaveAsync(AnimeModel animeModel);

        Task<List<AnimeModel>> GetAsync();

        Task<AnimeModel> GetByIdAsync(int id);

        Task<AnimeModel> UpdateAsync(AnimeModel animeModel);

        Task DeleteAsync(int id);
    }
}

