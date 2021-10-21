namespace ProjetoDoacaoDeAlimentos.Models
{
    public enum status
    {
        AGUARDANDO_DISTRIBUIDORA,
        RESERVADO,
        DOACAO_REALIZADA
    }

    public class Doacao
    {
        public int ID { get; set; }
        public int DoadorID { get;set; }
        public int DistribuidorID { get; set; }
        public status Status { get; set; }
        public virtual ICollection<Alimento> Alimentos { get; set; }
    }
}