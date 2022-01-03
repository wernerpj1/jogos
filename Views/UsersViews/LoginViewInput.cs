using System.ComponentModel.DataAnnotations;

namespace Jogos.Views.UsersViews
{
    public class LoginViewInput
    {
        [Required(ErrorMessage = "O Email de usuário é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário digitar a senha cadastrada")]
        public string Senha { get; set; }
    }
}