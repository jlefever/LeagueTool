using System.Collections.Generic;

namespace LeagueTool.Models.Views
{
    public class HomeViewModel
    {
        public IEnumerable<ChampionListItemViewModel> Champions { get; set; }
    }
}