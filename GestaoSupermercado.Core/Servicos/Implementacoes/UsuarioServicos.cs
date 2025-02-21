using GestaoSupermercado.Core.Criptografia;
using GestaoSupermercado.Core.Servicos.Interface;
using GestaoSupermercado.Core.Validadores;
using GestaoSupermercado.Infraestrutura.Models;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;

namespace GestaoSupermercado.Core.Servicos.Implementacoes
{
    public class UsuarioServicos : IUsuarioServicos
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServicos(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RetornoOperacao> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                if (!EmailValidador.ValidarEmail(usuario.Email))
                    return new RetornoOperacao(false, "E-mail invalido.");

                var senhaHash = CriptografiaSenha.GerarHashSenha(usuario.Senha);

                return await _usuarioRepository.CadastrarUsuario(new Usuario(usuario.Email, senhaHash));
            }
            catch (Exception ex)
            {
                return new RetornoOperacao(false, ex.Message);
            }
        }

        public async Task<Usuario> ObterUsuario(string login)
        {
            try
            {
                return await _usuarioRepository.ObterUsuario(login);
            }
            catch
            {
                return null;
            }
            
        }

        public bool ValidarSenha(string senha, string senhaHash)
        {
            return CriptografiaSenha.ValidarSenha(senha, senhaHash);
        }
    }
}
