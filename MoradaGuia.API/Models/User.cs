using System.Xml;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoradaGuia.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string telefone { get; set; }
        public DateTime Criado { get; set; }
        public DateTime UltimoLogin { get; set; }
        public ICollection<Imovel> Imovels { get; set; }
        public ICollection<Like> ImovelLike { get; set; }
    }
}