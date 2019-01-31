namespace KingsmanTailors.API.Models
{
    public class Suit
    {
        public int SuitId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int SuitTypeId { get; set; }

        public int TypeId { get; set; }

        public int FitId { get; set; }

        public int StyleId { get; set; }

        public int LapelId { get; set; }

        public int FrontId { get; set; }

        public int VentId { get; set; }
    }
}
