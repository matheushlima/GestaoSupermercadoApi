using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoSupermercado.Infraestrutura.Models
{
    public class Usuario
    {
        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }

        public string Senha { get; private set; }
    }
}
