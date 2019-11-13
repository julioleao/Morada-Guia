using System;
using System.ComponentModel.DataAnnotations;

namespace MoradaGuia.API.Dtos
{
    public class ImovelForRegisterDto
    {
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public int qtdQuarto { get; set; }
        [Required]
        public int qtdBanheiro { get; set; }
        [Required]
        public string Garagem { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime Data { get; set; }
        public ImovelForRegisterDto()
        {
            Data = DateTime.Now;
        }
    }
}