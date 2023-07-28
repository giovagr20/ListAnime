using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListAnime.API.Models
{
    public class AnimeModel
    {
        public int Id { get; set; }

        public string? AnimeName { get; set; }

        public string? Description { get; set; }

        public bool? HasSeasons { get; set; }

        public int? TotalSeasons { get; set; }

        public string? PictureUrl { get; set; }
    }
}

