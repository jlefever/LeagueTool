﻿using System.Collections.Generic;

namespace LeagueTool.Models.ViewModels
{
    public class ChampionListModel
    {
        public IEnumerable<ChampionListItemModel> Champions { get; set; }
    }
}