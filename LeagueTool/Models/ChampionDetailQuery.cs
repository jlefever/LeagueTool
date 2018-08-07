using System.ComponentModel.DataAnnotations;
using LeagueTool.Validation;

namespace LeagueTool.Models
{
    public class ChampionDetailQuery : ChampionQuery
    {
        // [ChampionName]
        [Required]
        public string ChampionName { get; set; }
    }
}