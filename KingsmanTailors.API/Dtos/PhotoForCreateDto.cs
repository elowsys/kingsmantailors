using System;
using Microsoft.AspNetCore.Http;

namespace KingsmanTailors.API.Dtos
{
    public class PhotoForCreateDto
    {

        public int Id { get; set; }

        public object InternalId { get; set; }

        public DateTime AddedDate { get; set; }

        public string Description { get; set; }

        public string PublicId { get; set; }

        public string Url { get; set; }

        public IFormFile File { get; set; }

        public PhotoForCreateDto()
        {
            AddedDate = DateTime.Now;
        }
    }
}
