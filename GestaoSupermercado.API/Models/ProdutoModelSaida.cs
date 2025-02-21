namespace GestaoSupermercado.API.Models
{
    public class ProdutoModelSaida
    {
        public ProdutoModelSaida(int id, string nome, int quantidade, double peso, string unidadeMedida)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Peso = peso;
            UnidadeMedida = unidadeMedida;
        }

        public int Id { get; set; }

        public string Nome { get; private set; }

        public int Quantidade { get; private set; }

        public double Peso { get; private set; }

        public string UnidadeMedida { get; private set; }
    }
}
