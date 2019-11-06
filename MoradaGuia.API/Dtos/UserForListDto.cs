using System;
using System.Collections.Generic;

namespace MoradaGuia.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }
        public DateTime Criado { get; set; }
        public DateTime UltimoLogin { get; set; }
        public ICollection<ImovelForDetailedDto> Imovels { get; set; }

    }
}