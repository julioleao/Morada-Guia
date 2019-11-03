namespace MoradaGuia.API.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descricao { get; set; }
        public bool Principal { get; set; }
        public string PublicId { get; set; }
    }
}