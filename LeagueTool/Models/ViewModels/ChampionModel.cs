using System.Collections.Generic;
using LeagueTool.Models.DataDragonDtos;

namespace LeagueTool.Models.ViewModels
{
    public class ChampionModel
    {
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string Lore { get; set; }
        public string Blurb { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> AllyTips { get; set; }
        public IEnumerable<string> EnemyTips { get; set; }
        public StatsDto Stats { get; set; }
    }
}