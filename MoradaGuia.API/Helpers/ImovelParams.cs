namespace MoradaGuia.API.Helpers
{
    public class ImovelParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value ;}
        }

        public int ImovelId { get; set; }
        public string Tipo { get; set; }
        public float ValorMin { get; set; } = 0;
        public float ValorMax { get; set; } = 5000;
        // public int QtdQuarto { get; set; } = 1;
        // public int QtdBanheiro { get; set; } = 1;
        // public int Garagem { get; set; } = 0;
        // public bool Likers { get; set; } = false;
    }
}