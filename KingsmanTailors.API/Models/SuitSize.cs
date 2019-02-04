using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class SuitSize
    {
        [Key]
        [Column("sizeId")]
        public int SizeId { get; set; }

        [Column("sizeName")]
        public string SizeName { get; set; }

        [Column("adjustIndex")]
        public double PriceAdjustIndex { get; set; }
    }
}
