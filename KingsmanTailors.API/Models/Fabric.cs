using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class Fabric
    {
        [Key]
        [Column("fabricId")]
        public int FabricId { get; set; }

        [Column("fabricName")]
        public string FabricName { get; set; }

        [Column("fabricDesc")]
        public string Description { get; set; }
    }
}
