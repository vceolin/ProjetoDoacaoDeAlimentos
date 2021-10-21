using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeAlimentos.Models
{
    public class Distribuidor
    {
        public int ID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"\d{2}.?\d{3}.?\d{3}/?\d{4}-?\d{2}")]
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Doacao>? Doacaos { get; set; }
    }
}