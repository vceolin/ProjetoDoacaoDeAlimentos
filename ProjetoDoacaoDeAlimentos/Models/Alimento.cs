namespace ProjetoDoacaoDeAlimentos.Models
{
    public class Alimento
    {
        public int ID { get; set; }
        public int DoacaoID { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime Validade { get; set; }
        public string? Observacoes { get; set; }


    }
}
