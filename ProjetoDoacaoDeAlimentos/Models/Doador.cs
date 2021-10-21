namespace ProjetoDoacaoDeAlimentos.Models
{
    public class Doador
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string TipoEstabelecimento { get; set; }
        public int Pontuacao { get; set; }
    }
}