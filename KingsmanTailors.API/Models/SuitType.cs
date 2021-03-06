using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class SuitType
    {
        [Key]
        [Column("suitTypeId")]
        public int SuitTypeId { get; set; }

        [Column("typeName")]
        public string SuitTypeName { get; set; }

        [Column("typeDesc")]
        public string Description { get; set; }
    }
}
