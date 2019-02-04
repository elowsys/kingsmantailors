using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class UserRole
    {
        [Key]
        [Column("userRoleId")]
        public int Id { get; set; }

        [Column("userId")]
        public string UserId { get; set; }

        [Column("roleId")]
        public string RoleId { get; set; }
    }
}
