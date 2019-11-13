using System;
using System.ComponentModel.DataAnnotations;

namespace MoradaGuia.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Você deve digitar uma senha de 4 a 8 caracteres")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string telefone { get; set; }
        public DateTime Criado { get; set; }
        public DateTime UltimoLogin { get; set; }
        public UserForRegisterDto()
        {
            Criado = DateTime.Now;
            UltimoLogin = DateTime.Now;
        }
    }
}