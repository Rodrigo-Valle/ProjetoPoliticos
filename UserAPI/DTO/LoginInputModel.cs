using System.ComponentModel.DataAnnotations;

namespace UserAPI.DTO
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}