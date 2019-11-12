using System;
using System.Collections.Generic;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Dtos

{
    public class ImovelForDetailedDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public float Valor { get; set; }
        public int QtdQuarto { get; set; }
        public int QtdBanheiro { get; set; }
        public int Garagem { get; set; }
        public DateTime Data { get; set; }
        public string UrlFoto { get; set; }
        public ICollection<PhotosForDetailedDto> Fotos { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}