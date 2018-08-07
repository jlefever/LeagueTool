using System.ComponentModel.DataAnnotations;

namespace LeagueTool.Models
{
    public class ChampionDetailQuery : ChampionQuery
    {
        [Required]
        public string ChampionName { get; set; }
    }
}