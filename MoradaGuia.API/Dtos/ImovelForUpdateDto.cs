namespace MoradaGuia.API.Dtos
{
    public class ImovelForUpdateDto
    {
        public string Tipo { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public float Valor { get; set; }
        public int QtdQuarto { get; set; }
        public int QtdBanheiro { get; set; }
        public int Garagem { get; set; }
    }
}