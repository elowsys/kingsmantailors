using System;

namespace KingsmanTailors.API.Dtos
{
    public class SuitPhotoForDetailedDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime AddedDate { get; set; }

        public bool IsDefault { get; set; }
    }
}
