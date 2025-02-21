namespace GestaoSupermercado.API.Models
{
    public class VendaProdutoModelSaida
    {
        public VendaProdutoModelSaida() { }

        public VendaProdutoModelSaida(int id, int idProduto, int quantidade, DateTime data)
        {
            Id = id;
            IdProduto = idProduto;
            QuantidadeVendida = quantidade;
            Data = data;
        }

        public int Id { get; private set; }

        public int IdProduto { get; private set; }

        public int QuantidadeVendida { get; private set; }

        public DateTime Data { get; private set; }
    }
}
