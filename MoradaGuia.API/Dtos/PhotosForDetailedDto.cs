using System;

namespace MoradaGuia.API.Dtos
{
    public class PhotosForDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descricao { get; set; }
        public bool Principal { get; set; }
    }
}