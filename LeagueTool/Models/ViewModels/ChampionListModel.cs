using System.Collections.Generic;

namespace LeagueTool.Models.ViewModels
{
    public class ChampionListModel
    {
        public string SelectedRegion { get; set; }
        public string SelectedLanguage { get; set; }
        public string SelectedVersion { get; set; }

        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<string> Versions { get; set; }

        public IEnumerable<ChampionListItemModel> Champions { get; set; }
    }
}