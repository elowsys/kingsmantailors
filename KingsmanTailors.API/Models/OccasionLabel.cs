using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class OccasionLabel
    {
        [Key]
        [Column("labelId")]
        public int LabelId { get; set; }

        [Column("labelName")]
        public string LabelName { get; set; }

        [Column("labelDesc")]
        public string Description { get; set; }
    }
}
