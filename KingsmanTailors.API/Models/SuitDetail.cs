namespace KingsmanTailors.API.Models
{
    public class SuitDetail
    {
        public int DetailId { get; set; }

        public int SuitId { get; set; }

        public double Price { get; set; }

        public int Qty { get; set; }

        public int TagId { get; set; }

        public bool InStock { get; set; }
    }
}
