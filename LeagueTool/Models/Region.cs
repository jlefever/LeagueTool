using System.Collections.Generic;
using System.Linq;

namespace LeagueTool.Models
{
    public class Region
    {
        public static readonly Region Na = new Region("na", "North America");
        public static readonly Region Euw = new Region("euw", "Europe West");
        public static readonly Region Eune = new Region("eune", "Europe Nordic & East");
        public static readonly Region Lan = new Region("lan", "Latin America North");
        public static readonly Region Las = new Region("las", "Latin America South");
        public static readonly Region Br = new Region("br", "Brazil");
        public static readonly Region Tr = new Region("tr", "Turkey");
        public static readonly Region Ru = new Region("ru", "Russia");
        public static readonly Region Oce = new Region("oce", "Oceania");
        public static readonly Region Jp = new Region("jp", "Japan");
        public static readonly Region Kr = new Region("kr", "Korea");
        public static readonly Region Pbe = new Region("pbe", "Public Beta Environment");

        public string Name { get; }
        public string DisplayName { get; }

        private Region(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        public static IEnumerable<Region> All()
        {
            return new[]
            {
                Na,
                Euw,
                Eune,
                Lan,
                Las,
                Br,
                Tr,
                Ru,
                Oce,
                Jp,
                Kr,
                Pbe,
            };
        }

        public static bool IsValidRegion(string region)
        {
            return All().Count(r => r.Name == region) == 1;
        }
    }
}