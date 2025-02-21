using BCrypt.Net;

namespace GestaoSupermercado.Core.Criptografia
{
    public static class CriptografiaSenha
    {
        public static string GerarHashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool ValidarSenha(string senha, string senhaUsuarioBd)
        {
            return BCrypt.Net.BCrypt.Verify(senha, senhaUsuarioBd);
        }
    }
}
