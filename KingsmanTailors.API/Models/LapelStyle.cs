using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class LapelStyle
    {
        [Key]
        [Column("lapelId")]
        public int LapelId { get; set; }

        [Column("lapelName")]
        public string LapelName { get; set; }
    }
}
