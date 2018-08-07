using LeagueTool.Validation;
using System.ComponentModel.DataAnnotations;

namespace LeagueTool.Models
{
    public abstract class ChampionQuery
    {
        [Region]
        [Required]
        public string Region { get; set; }

        [Language]
        [Required]
        public string Language { get; set; }

        [Version]
        [Required]
        public string Version { get; set; }
    }
}