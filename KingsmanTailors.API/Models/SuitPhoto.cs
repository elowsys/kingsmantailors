using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class SuitPhoto
    {
        [Key]
        [Column("photoId")]
        public int Id { get; set; }

        [Column("suitId")]
        public int SuitId { get; set; }

        [Column("photoDesc")]
        public string Description { get; set; }

        [Column("photoUrl")]
        public string Url { get; set; }

        [Column("isDefault")]
        public bool IsDefault { get; set; }

        [Column("publicId")]
        public string PublicId { get; set; }
    }
}
