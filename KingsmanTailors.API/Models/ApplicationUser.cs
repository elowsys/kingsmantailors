using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KingsmanTailors.API.Models
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; }

        public bool AccountConfirmed { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public bool LockedOutEnabled { get; set; }

        public DateTime LockedOutEnd { get; set; }

        public int AccessFailedCount { get; set; }

        public byte[] PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] SecurityStamp { get; set; }

        public string Username { get; set; }


        // [ProtectedPersonalData]
        // [Display(Name = "Name")]

        // [NotMapped]
        // [Display(Name = "Administrator")]
        // public bool IsSuperUser { get; set; }
    }
}
