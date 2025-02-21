using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoSupermercado.Infraestrutura.Models.Enum
{
    public enum EStatusProduto
    {
        INDEFINIDO = -1,

        EM_ESTOQUE = 0,

        FORA_ESTOQUE = 1
    }
}
