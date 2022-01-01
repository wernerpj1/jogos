using System.ComponentModel.DataAnnotations;

namespace Jogos.Views
{
    public class JogoViewInput
    {
        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        [StringLength(250, MinimumLength = 3, ErrorMessage ="O nome tem que ter de 3 à 250 caracteres")]
        public string Nome { get; set; }


        public string Produtora { get; set; }
        
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Descreva algo sobre o jogo")]
        [StringLength(2500, MinimumLength = 3, ErrorMessage ="A descrição tem que ter de 3 à 2500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "É necessário colocar o preço que deseja pelo jogo")]
        [Range(1, 1000, ErrorMessage ="O preço pode variar de R$ 1,00 à R$ 1.000,00")]
        public double Price { get; set; }
    }
}