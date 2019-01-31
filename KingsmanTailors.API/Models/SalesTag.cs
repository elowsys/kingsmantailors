namespace KingsmanTailors.API.Models
{
    public class SalesTag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public bool ApplyPriceAdjust { get; set; }

        public double PriceAdjust { get; set; }
    }
}
