using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.Infraestrutura.Repositorio.Interface
{
    public interface IProdutoRepository
    {
        Task<ICollection<ProdutoDto>> ObterProdutos();

        Task<ProdutoDto> ObterProdutoPorId(int id);

        Task<RetornoOperacao> CadastrarProduto(ProdutoDto produtoDto);

        Task<RetornoOperacao> AtualizarProduto(ProdutoDto produtoDto);

        Task<RetornoOperacao> DeletarProduto(int id);

        Task<RetornoOperacao> AtualizarProdutoVenda(ProdutoDto produtoDto);
    }
}
