using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MoradaGuia.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool Principal { get; set; }
        public string PublicId { get; set; }
        public int ImovelId { get; set; }
        [ForeignKey("ImovelId")]
        public Imovel Imovel { get; set; }
    }
}