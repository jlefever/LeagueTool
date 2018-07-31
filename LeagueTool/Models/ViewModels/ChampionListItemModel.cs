namespace LeagueTool.Models.ViewModels
{
    public class ChampionListItemModel
    {
        private string _title;

        public string Title
        {
            get => _title;

            set
            {
                if (value[0].Equals('t'))
                {
                    _title = "T" + value.Substring(1);
                }
                else
                {
                    _title = value;
                }
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SquareImage { get; set; }
    }
}