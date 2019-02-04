using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class OccasionType
    {
        [Key]
        [Column("typeId")]
        public int TypeId { get; set; }

        [Column("labelId")]
        public int LabelId { get; set; }

        [Column("colorName")]
        public string ColorName { get; set; }

        [Column("colorValue")]
        public string ColorValue { get; set; }

        [ForeignKey("LabelId")]
        public virtual OccasionLabel OccasionLabel { get; set; }
    }
}
