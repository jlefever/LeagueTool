using System.ComponentModel.DataAnnotations;

namespace LeagueTool.Models
{
    public class ChampionQuery
    {
        [Required]
        public string Region { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Version { get; set; }
    }
}