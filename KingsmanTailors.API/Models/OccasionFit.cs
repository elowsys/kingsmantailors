using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class OccasionFit
    {
        [Key]
        [Column("fitId")]
        public int FitId { get; set; }

        [Column("fitName")]
        public string FitName { get; set; }

        [Column("fitDesc")]
        public string Description { get; set; }
    }
}
