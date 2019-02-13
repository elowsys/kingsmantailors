namespace KingsmanTailors.API.Dtos
{
    public class UserForListDto
    {
        // public int Id { get; set; }
        public string UserId { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        // public int RoleId { get; set; }
        public string RoleCode { get; set; }

        public string PublicId { get; set; }

        public string Url { get; set; }
    }
}
