using System.Collections.Generic;

namespace LeagueTool.Models.ViewModels
{
    public class LayoutModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<string> Versions { get; set; }

        public ChampionQuery ChampionQuery { get; set; }
    }
}