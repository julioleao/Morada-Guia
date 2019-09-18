using System.ComponentModel.DataAnnotations;

namespace MoradaGuia.API.Models
{
    public class Usuario
    {
        [Key][MaxLength(30)]
        public string Email { get; set; }
        [Required][MaxLength(20)]
        public byte[] PasswordHash { get; set; }
        [Required][MaxLength(20)]
        public byte[] PasswordSalt { get; set; }
        [Required][MaxLength(20)]
        public string nome { get; set; }
        [Required][MaxLength(40)]
        public string sobrenome { get; set; }
        [Required][MaxLength(15)]
        public int telefone { get; set; }
        
    }
}