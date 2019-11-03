using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoradaGuia.API.Models
{
    public class Imovel
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
        public ICollection<Photo> Fotos { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}