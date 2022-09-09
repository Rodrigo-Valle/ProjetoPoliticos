using System.ComponentModel.DataAnnotations;

namespace AdminAPI.DTO.InputModel
{
    public class PartidoInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "O campo {0} deve possuir de {2} ate {1} Caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve possuir de {2} ate {1} Caracteres")]
        public string Nome { get; set; }
    }
}