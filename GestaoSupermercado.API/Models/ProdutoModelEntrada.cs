using GestaoSupermercado.Infraestrutura.Models.Enum;

namespace GestaoSupermercado.API.Models
{
    public class ProdutoModelEntrada
    {
        public ProdutoModelEntrada(string nome, int quantidade, double peso, string unidadeMedida, EStatusProduto status)
        {
            Nome = nome;
            Quantidade = quantidade;
            Peso = peso;
            UnidadeMedida = unidadeMedida;
            Status = status;
        }

        public string Nome { get; private set; }

        public int Quantidade { get; private set; }

        public double Peso { get; private set; }

        public string UnidadeMedida { get; private set; }

        public EStatusProduto Status { get; private set; }
    }
}
