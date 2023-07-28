using System;
using ListAnime.API.Models;
using ListAnime.API.Repositories;

namespace ListAnime.API.Services
{
    public class Service : IService
	{
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<AnimeModel>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<AnimeModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> SaveAsync(AnimeModel animeModel)
        {
            return await _repository.SaveAsync(animeModel);
        }

        public async Task<AnimeModel> UpdateAsync(AnimeModel animeModel)
        {
            return await _repository.UpdateAsync(animeModel);
        }


    }
}

