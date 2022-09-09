using System.ComponentModel.DataAnnotations;

namespace AdminAPI.DTO.InputModel
{
    public class ProjetoInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NumeroLei { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Politico { get; set; }
    }
}