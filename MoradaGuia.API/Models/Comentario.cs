using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoradaGuia.API.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string Email_FK { get; set; }
        public int Id_FK { get; set; }
        public string Comment { get; set; }
        [ForeignKey("Email_FK")]
        public Usuario Usuario { get; set; }
        [ForeignKey("Id_FK")]
        public Imovel Imovel { get; set; }
    }
}