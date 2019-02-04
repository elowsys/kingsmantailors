using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class OccasionStyle
    {
        [Key]
        [Column("styleId")]
        public int StyleId { get; set; }

        [Column("styleName")]
        public string StyleName { get; set; }
    }
}
