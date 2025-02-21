using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.Infraestrutura.Repositorio.Interface
{
    public interface IUsuarioRepository
    {
        Task<RetornoOperacao> CadastrarUsuario(Usuario usuario);

        Task<Usuario> ObterUsuario(string login);
    }
}
