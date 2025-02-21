using GestaoSupermercado.Infraestrutura.Models.Enum;

namespace GestaoSupermercado.Infraestrutura.Models
{
    public class ProdutoDto
    {

        #region Construtor

        public ProdutoDto() { }

        public ProdutoDto(string nome, int quantidade, double peso, string unidadeMedida)
        {
            Nome = nome;
            Quantidade = quantidade;
            Peso = peso;
            UnidadeMedida = unidadeMedida;
        }

        public ProdutoDto(int id, string nome, int quantidade, double peso, string unidadeMedida, EStatusProduto status, DateTime dataUltimaVenda)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Peso = peso;
            UnidadeMedida = unidadeMedida;
            Status = status;
            DataUltimaVenda = dataUltimaVenda;
        }

        #endregion


        #region Propriedades

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public double Peso { get; set; }

        public string UnidadeMedida { get; set; }

        public EStatusProduto Status { get; set; }

        public DateTime DataUltimaVenda { get; set; }

        #endregion


    }
}
