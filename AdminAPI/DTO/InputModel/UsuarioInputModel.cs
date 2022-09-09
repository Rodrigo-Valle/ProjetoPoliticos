using System.ComponentModel.DataAnnotations;

namespace AdminAPI.DTO.InputModel
{
    public class UsuarioInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Admin { get; set; }
    }
}