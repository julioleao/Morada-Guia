using System;

namespace MoradaGuia.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string sobrenome { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }
    }
}