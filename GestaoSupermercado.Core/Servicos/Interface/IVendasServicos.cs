using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.Core.Servicos.Interface
{
    public interface IVendasServicos
    {
        Task<ICollection<VendaProdutoDto>> ObterVendas();

        Task<ICollection<VendaProdutoDto>> ObterVendasPorProduto(int idProduto);

        Task<RetornoOperacao> IncluirVenda(int idProduto, int quantidade);
    }
}
