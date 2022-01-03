namespace Jogos.Business.Entities
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Image { get; set; }
        public string Produtora { get; set; }
        public double Price { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public bool IsExclude { get; set; }
    }
}