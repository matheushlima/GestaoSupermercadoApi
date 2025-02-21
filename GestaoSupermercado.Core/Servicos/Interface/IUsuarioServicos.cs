using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.Core.Servicos.Interface
{
    public interface IUsuarioServicos
    {
        Task<RetornoOperacao> CadastrarUsuario(Usuario usuario);

        Task<Usuario> ObterUsuario(string login);

        bool ValidarSenha(string senha, string senhaHash);
    }
}
