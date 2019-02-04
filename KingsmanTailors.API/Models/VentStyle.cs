using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class VentStyle
    {
        [Key]
        [Column("ventId")]

        public int VentId { get; set; }

        [Column("ventName")]
        public string VentName { get; set; }
    }
}
