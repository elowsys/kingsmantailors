using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class Suit
    {
        [Key]
        [Column("suitId")]
        public int SuitId { get; set; }

        [Column("suitDesc")]
        public string Description { get; set; }

        [Column("suitImg")]
        public string Image { get; set; }

        [Column("suitTypeId")]
        public int SuitTypeId { get; set; }

        // [Column("labelId")]
        // public int LabelId { get; set; }

        [Column("typeId")]
        public int TypeId { get; set; }

        [Column("fitId")]
        public int FitId { get; set; }

        [Column("styleId")]
        public int StyleId { get; set; }

        [Column("lapelId")]
        public int LapelId { get; set; }

        [Column("frontId")]
        public int FrontId { get; set; }

        [Column("ventId")]
        public int VentId { get; set; }

        // [ForeignKey("LabelId")]
        // public virtual OccasionLabel OccasionLabel { get; set; }

        [ForeignKey("SuitTypeId")]
        public virtual SuitType SuitType { get; set; }

        [ForeignKey("TypeId")]
        public virtual OccasionType OccasionType { get; set; }

        [ForeignKey("FitId")]
        public virtual OccasionFit OccasionFit { get; set; }

        [ForeignKey("StyleId")]
        public virtual OccasionStyle OccasionStyle { get; set; }

        [ForeignKey("LapelId")]
        public virtual LapelStyle LapelStyle { get; set; }

        [ForeignKey("FrontId")]
        public virtual FrontStyle FrontStyle { get; set; }

        [ForeignKey("VentId")]
        public virtual VentStyle VentStyle { get; set; }
    }
}
