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
    }
}