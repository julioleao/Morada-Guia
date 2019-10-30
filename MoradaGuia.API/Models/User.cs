using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoradaGuia.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(20)]
        public byte[] PasswordHash { get; set; }
        [MaxLength(20)]
        public byte[] PasswordSalt { get; set; }
        [MaxLength(40)]
        public string sobrenome { get; set; }
        [MaxLength(15)]
        public int telefone { get; set; }
        public DateTime Criado { get; set; }
        public DateTime UltimoLogin { get; set; }
        public ICollection<Photo> Fotos { get; set; }
        
    }
}