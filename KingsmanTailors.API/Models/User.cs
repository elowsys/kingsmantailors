using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KingsmanTailors.API.Models
{
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("userName")]
        public string Username { get; set; }

        [Column("passwordHash")]
        public byte[] PasswordHash { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("accountConfirmed")]
        public bool AccountConfirmed { get; set; }

        [Column("displayName")]
        public string DisplayName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("lockoutEnabled")]
        public bool LockedOutEnabled { get; set; }

        [Column("lockOutEnd")]
        public DateTime LockedOutEnd { get; set; }

        [Column("accessFailedCount")]
        public int AccessFailedCount { get; set; }

        [Column("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("securityStamp")]
        public byte[] SecurityStamp { get; set; }

        [Column("userId")]
        public string UserId { get; set; }

        [NotMapped]
        public string RoleCode { get; set; }
    }
}
