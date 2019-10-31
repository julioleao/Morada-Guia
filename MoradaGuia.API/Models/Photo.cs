using System;

namespace MoradaGuia.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DataAdded { get; set; }
        public bool Principal { get; set; }
        public Imovel Imovel { get; set; }
        public int ImovelId { get; set; }

    }
}