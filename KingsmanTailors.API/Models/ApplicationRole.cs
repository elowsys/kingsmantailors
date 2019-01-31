using System.ComponentModel.DataAnnotations;

namespace KingsmanTailors.API.Models
{
    public class ApplicationRole
    {
        [Key]
        public string Id { get; set; }


        public string RoleName { get; set; }
    }
}
