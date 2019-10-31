using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoradaGuia.API.Models
{
    public class Imovel
    {
        [Key]
        public int Id { get; set; }
        [Required][MaxLength(20)]
        public string Tipo { get; set; }
        [Required][MaxLength(40)]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required][MaxLength(30)]
        public string Bairro { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public int Qtd_Quarto { get; set; }
        [Required]
        public int Qtd_Banheiro { get; set; }
        public int Garagem { get; set; }
        public DateTime Data { get; set; }
        [Required]
        public ICollection<Photo> Fotos { get; set; }

        public string Email_FK { get; set; }
        [ForeignKey("Email_FK")]

        public Usuario Usuario { get; set; }
        public int UserId { get; set; }
    }
}