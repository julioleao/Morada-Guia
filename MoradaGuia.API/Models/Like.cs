namespace MoradaGuia.API.Models
{
    public class Like
    {
        public int LikerId { get; set; }
        public int ImovelLikeId { get; set; }
        public User Liker { get; set; }
        public Imovel ImovelLike { get; set; }
    }
}