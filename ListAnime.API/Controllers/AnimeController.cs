using ListAnime.API.Models;
using ListAnime.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListAnime.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : Controller
    {
        private readonly IService _service;

        public AnimeController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAnimesAsync()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetAnimeById(int id)
        {
            var anime = await _service.GetByIdAsync(id);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }

        [HttpPost]
        public async Task<IActionResult> PostAnimeAsync([FromBody] AnimeModel animeModel)
        {
            bool result = await _service.SaveAsync(animeModel);

            if (result == false)
            {
                return Ok("An error has ocurred");
            }

            return Ok("Anime has saved");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimeAsync([FromBody] AnimeModel animeModel)
        {
            var result = await _service.UpdateAsync(animeModel);

            if (result == null)
            {
                return BadRequest("An error has ocurred");
            }
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAnimeByIdAsync(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}

