using System.Collections.Generic;
using System.Linq;

namespace LeagueTool.Models
{
    public class Region
    {
        public static readonly Region Br = new Region("br");
        public static readonly Region Eune = new Region("eune");
        public static readonly Region Euw = new Region("euw");
        public static readonly Region Jp = new Region("jp");
        public static readonly Region Kr = new Region("kr");
        public static readonly Region Lan = new Region("lan");
        public static readonly Region Las = new Region("las");
        public static readonly Region Na = new Region("na");
        public static readonly Region Oce = new Region("oce");
        public static readonly Region Tr = new Region("tr");
        public static readonly Region Ru = new Region("ru");
        public static readonly Region Pbe = new Region("pbe");

        public string Name { get; }

        private Region(string name)
        {
            Name = name;
        }

        public static IEnumerable<Region> All()
        {
            return new[]
            {
                Br,
                Eune,
                Euw,
                Jp,
                Kr,
                Lan,
                Las,
                Na,
                Oce,
                Tr,
                Ru,
                Pbe
            };
        }

        public static bool IsValidRegion(string region)
        {
            return All().Count(r => r.Name == region) == 1;
        }
    }
}