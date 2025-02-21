using Dapper;
using GestaoSupermercado.Infraestrutura.Models;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace GestaoSupermercado.Infraestrutura.Repositorio.Implementacoes
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        private string CadastrarUsuarioSql()
        {
            return @"INSERT INTO USUARIOS
                            (USUARIO, SENHA)
                     VALUES (@Email, @Senha)";
        }

        private string ObterUsuarioSql()
        {
            return @"SELECT USUARIO AS EMAIL, 
                            SENHA AS SENHA
                       FROM USUARIOS
                      WHERE USUARIO = @LOGIN";
        }

        public async Task<RetornoOperacao> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                using var db = GetSqlConnection();

                var sucesso = await db.ExecuteAsync(CadastrarUsuarioSql(), usuario) > 0;

                if (sucesso)
                    return new RetornoOperacao(sucesso, "");

                return new RetornoOperacao(sucesso, "Não foi possível cadastrar o usuario");
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
                using var db = GetSqlConnection();

                return await db.QueryFirstOrDefaultAsync<Usuario>(ObterUsuarioSql(), new { LOGIN = login});
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
