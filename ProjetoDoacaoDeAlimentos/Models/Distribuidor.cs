namespace ProjetoDoacaoDeAlimentos.Models
{
    public class Distribuidor
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Doacao> Doacaos { get; set; }
    }
}