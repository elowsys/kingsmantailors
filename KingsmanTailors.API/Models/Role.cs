using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingsmanTailors.API.Models
{
    public class Role
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("roleId")]
        public string RoleId { get; set; }

        [Column("roleName")]
        public string RoleName { get; set; }

        [Column("roleAbbrev")]
        public string RoleAbbrev { get; set; }

        public Role()
        {
            RoleId = Guid.NewGuid().ToString();
        }
    }
}
