using System;

namespace KingsmanTailors.API.Dtos
{
    public class UserForEditDto
    {

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool AccountConfirmed { get; set; }

        public bool LockedOutEnabled { get; set; }

        public DateTime LockedOutEnd { get; set; }

        public int AccessFailedCount { get; set; }

        public string RoleCode { get; set; }

        public string PublicId { get; set; }

        public string Url { get; set; }
    }
}
