using System.ComponentModel.DataAnnotations;

namespace MoradaGuia.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required][MaxLength(20)]
        public string Username { get; set; }
        [Key][MaxLength(30)]
        public string Email { get; set; }
        [Required][MaxLength(20)]
        public byte[] PasswordHash { get; set; }
        [Required][MaxLength(20)]
        public byte[] PasswordSalt { get; set; }
        [Required][MaxLength(40)]
        public string sobrenome { get; set; }
        [Required][MaxLength(15)]
        public int telefone { get; set; }
        
    }
}