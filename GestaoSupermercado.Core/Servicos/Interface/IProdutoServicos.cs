using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.Core.Servicos.Interface
{
    public interface IProdutoServicos
    {
        Task<ICollection<ProdutoDto>> ObterProdutos();

        Task<ProdutoDto> ObterProdutoPorId(int id);

        Task<RetornoOperacao> CadastrarProduto(ProdutoDto produtoDto);

        Task<RetornoOperacao> AtualizarProduto(int id, ProdutoDto produtoDto);

        Task<RetornoOperacao> DeletarProduto(int id);
    }
}
