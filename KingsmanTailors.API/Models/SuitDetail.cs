using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class SuitDetail
    {
        [Key]
        [Column("detailId")]
        public int DetailId { get; set; }

        [Column("suitId")]
        public int SuitId { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("qty")]
        public int Qty { get; set; }

        [Column("tagId")]
        public int TagId { get; set; }

        [Column("inStock")]
        public bool InStock { get; set; }

        [ForeignKey("SuitId")]
        public virtual Suit Suit { get; set; }
    }
}
