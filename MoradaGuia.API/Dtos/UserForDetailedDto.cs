using System;
using System.Collections.Generic;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string sobrenome { get; set; }
        public string Email { get; set; }
        public int telefone { get; set; }
        public DateTime Criado { get; set; }
        public DateTime UltimoLogin { get; set; }

    }
}