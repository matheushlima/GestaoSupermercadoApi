using System.Text.RegularExpressions;

namespace GestaoSupermercado.Core.Validadores
{
    public static class EmailValidador
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public static bool ValidarEmail(string email)
        {
            return EmailRegex.IsMatch(email);
        }
    }
}
