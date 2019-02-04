using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class FrontStyle
    {
        [Key]
        [Column("frontId")]
        public int FrontId { get; set; }

        [Column("frontName")]
        public string FrontName { get; set; }
    }
}
