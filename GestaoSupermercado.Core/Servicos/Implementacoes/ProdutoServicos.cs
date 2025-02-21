using GestaoSupermercado.Core.Servicos.Interface;
using GestaoSupermercado.Infraestrutura.Models;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;

namespace GestaoSupermercado.Core.Servicos.Implementacoes
{
    public class ProdutoServicos : IProdutoServicos
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoServicos(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<RetornoOperacao> AtualizarProduto(int id, ProdutoDto produtoDto)
        {
            try
            {
                produtoDto.Id = id;

                return await _produtoRepository.AtualizarProduto(produtoDto);
            }
            catch (Exception ex)
            {
                return new RetornoOperacao(false, ex.Message);
            }
            
        }

        public async Task<RetornoOperacao> CadastrarProduto(ProdutoDto produtoDto)
        {
            try
            {
                return await _produtoRepository.CadastrarProduto(produtoDto);
            }
            catch (Exception ex)
            {
                return new RetornoOperacao(false, ex.Message);
            }
        }

        public async Task<RetornoOperacao> DeletarProduto(int id)
        {
            try
            {
                return await _produtoRepository.DeletarProduto(id);
            }
            catch (Exception ex)
            {
                return new RetornoOperacao(false, ex.Message);
            }
        }

        public async Task<ProdutoDto> ObterProdutoPorId(int id)
        {
            try
            {
                return await _produtoRepository.ObterProdutoPorId(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ICollection<ProdutoDto>> ObterProdutos()
        {
            try
            {
                return await _produtoRepository.ObterProdutos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
