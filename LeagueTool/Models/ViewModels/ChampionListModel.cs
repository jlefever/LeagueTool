using System.Collections.Generic;

namespace LeagueTool.Models.ViewModels
{
    public class ChampionListModel : LayoutModel
    {
        public IEnumerable<ChampionListItemModel> Champions { get; set; }
    }
}