using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class SalesTag
    {
        [Key]
        [Column("tagId")]
        public int TagId { get; set; }

        [Column("tagName")]
        public string TagName { get; set; }

        [Column("applyAdjust")]
        public bool ApplyPriceAdjust { get; set; }

        [Column("priceAdjust")]
        public double PriceAdjust { get; set; }
    }
}
