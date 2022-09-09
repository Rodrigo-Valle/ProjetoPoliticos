using System.Threading.Tasks;
using AdminAPI.DTO.InputModel;

namespace AdminAPI.Services
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(UsuarioInputModel usuario);
        Task<string> Login(LoginInputModel login);
    }
}