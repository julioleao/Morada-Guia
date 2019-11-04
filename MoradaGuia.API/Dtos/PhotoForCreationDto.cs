using System;
using Microsoft.AspNetCore.Http;

namespace MoradaGuia.API.Dtos
{
    public class PhotoForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public DateTime Data{ get; set; }
        public string PublicId { get; set; }
        public PhotoForCreationDto()
        {
            Data = DateTime.Now;
        }
    }
}