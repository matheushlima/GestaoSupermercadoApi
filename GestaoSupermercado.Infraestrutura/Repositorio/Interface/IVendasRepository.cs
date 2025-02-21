using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.Infraestrutura.Repositorio.Interface
{
    public interface IVendasRepository
    {
        Task<ICollection<VendaProdutoDto>> ObterVendas();

        Task<ICollection<VendaProdutoDto>> ObterVendasPorProduto(int idProduto);

        Task<RetornoOperacao> InserirVenda(VendaProdutoDto vendaProdutoDto);
    }
}
