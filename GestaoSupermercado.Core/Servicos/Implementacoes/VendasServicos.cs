using GestaoSupermercado.Core.Servicos.Interface;
using GestaoSupermercado.Infraestrutura.Models;
using GestaoSupermercado.Infraestrutura.Models.Enum;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;

namespace GestaoSupermercado.Core.Servicos.Implementacoes
{
    public class VendasServicos : IVendasServicos
    {
        private readonly IVendasRepository _vendasRepository;
        private readonly IProdutoRepository _produtoRepository;

        public VendasServicos(IVendasRepository vendasRepository, IProdutoRepository produtoRepository)
        {
            _vendasRepository = vendasRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<RetornoOperacao> IncluirVenda(int idProduto, int quantidade)
        {
            var produto = await _produtoRepository.ObterProdutoPorId(idProduto);

            if (quantidade > produto.Quantidade)
                return new RetornoOperacao(false, "Quantidade vendida superior ao estoque!");

            //Inserir Transaction em caso de falha

            var retorno = await _vendasRepository.InserirVenda(new VendaProdutoDto(idProduto, quantidade, DateTime.Now));

            if (retorno.Sucesso)
            {
                produto.Quantidade -= quantidade;

                if (produto.Quantidade == 0)
                    produto.Status = EStatusProduto.FORA_ESTOQUE;

                produto.DataUltimaVenda = DateTime.Now;

                return await _produtoRepository.AtualizarProdutoVenda(produto);
            }

            return retorno;
        }

        public async Task<ICollection<VendaProdutoDto>> ObterVendas()
        {
            try
            {
                return await _vendasRepository.ObterVendas();
            }
            catch
            {
                //log no banco para registrar erro
                return null;
            }
            
        }

        public async Task<ICollection<VendaProdutoDto>> ObterVendasPorProduto(int idProduto)
        {
            try
            {
                return await _vendasRepository.ObterVendasPorProduto(idProduto);
            }
            catch
            {
                //log no banco para registrar erro
                return null;
            }
        }
    }
}
