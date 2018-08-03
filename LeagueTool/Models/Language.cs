using System.Collections.Generic;
using System.Linq;

namespace LeagueTool.Models
{
    public class Language
    {
        private static readonly Language EnUs = new Language("en_US", "English (United States)");
        private static readonly Language EnGb = new Language("en_GB", "English (United Kingdom)");
        private static readonly Language EnAu = new Language("en_AU", "English (Australia)");
        private static readonly Language EnPh = new Language("en_PH", "English (Reprivate of the Philippines)");
        private static readonly Language EnSg = new Language("en_SG", "English (Singapore)");
        private static readonly Language CsCz = new Language("cs_CZ", "Czech (Czech Reprivate)");
        private static readonly Language ElGr = new Language("el_GR", "Greek (Greece)");
        private static readonly Language PlPl = new Language("pl_PL", "Polish (Poland)");
        private static readonly Language RoRo = new Language("ro_RO", "Romanian (Romania)");
        private static readonly Language HuHu = new Language("hu_HU", "Hungarian (Hungary)");
        private static readonly Language DeDe = new Language("de_DE", "German (Germany)");
        private static readonly Language EsEs = new Language("es_ES", "Spanish (Spain)");
        private static readonly Language ItIt = new Language("it_IT", "Italian (Italy)");
        private static readonly Language FrFr = new Language("fr_FR", "French (France)");
        private static readonly Language JaJp = new Language("ja_JP", "Japanese (Japan)");
        private static readonly Language KoKr = new Language("ko_KR", "Korean (Korea)");
        private static readonly Language EsMx = new Language("es_MX", "Spanish (Mexico)");
        private static readonly Language EsAr = new Language("es_AR", "Spanish (Argentina)");
        private static readonly Language PtBr = new Language("pt_BR", "Portuguese (Brazil)");
        private static readonly Language RuRu = new Language("ru_RU", "Russian (Russia)");
        private static readonly Language TrTr = new Language("tr_TR", "Turkish (Turkey)");
        private static readonly Language MsMy = new Language("ms_MY", "Malay (Malaysia)");
        private static readonly Language ThTh = new Language("th_TH", "Thai (Thailand)");
        private static readonly Language VnVn = new Language("vn_VN", "Vietnamese (Viet Nam)");
        private static readonly Language IdId = new Language("id_ID", "Indonesian (Indonesia)");
        private static readonly Language ZhMy = new Language("zh_MY", "Chinese (Malaysia)");
        private static readonly Language ZhCn = new Language("zh_CN", "Chinese (China)");
        private static readonly Language ZhTw = new Language("zh_TW", "Chinese (Taiwan)");

        public string Name { get; }
        public string DisplayName { get; }

        private Language(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        public static IEnumerable<Language> All()
        {
            return new[]
            {
                EnUs,
                EnGb,
                EnAu,
                EnPh,
                EnSg,
                CsCz,
                ElGr,
                PlPl,
                RoRo,
                HuHu,
                DeDe,
                EsEs,
                ItIt,
                FrFr,
                JaJp,
                KoKr,
                EsMx,
                EsAr,
                PtBr,
                RuRu,
                TrTr,
                MsMy,
                ThTh,
                VnVn,
                IdId,
                ZhMy,
                ZhCn,
                ZhTw
            };
        }

        public static bool IsValidLanguage(string language)
        {
            return All().Count(l => l.Name == language) == 1;
        }
    }
}