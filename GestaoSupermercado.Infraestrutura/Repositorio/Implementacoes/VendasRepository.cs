using Dapper;
using GestaoSupermercado.Infraestrutura.Models;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.Configuration;

namespace GestaoSupermercado.Infraestrutura.Repositorio.Implementacoes
{
    public class VendasRepository : RepositoryBase, IVendasRepository
    {
        public VendasRepository(IConfiguration configuration) : base(configuration)
        {
        }

        private string ObterVendasSql()
        {
            return @"SELECT ID AS Id,
                            ID_PRODUTO AS IdProduto,
                            QUANTIDADE_VENDIDA AS QuantidadeVendida,
                            DATA AS Data
                       FROM VENDAS";
        }

        private string ObterVendasPorProdutoSql()
        {
            return @"SELECT *
                       FROM VENDAS
                      WHERE ID_PRODUTO = @ID";
        }

        private string InserirVendasSql()
        {
            return @"INSERT INTO VENDAS
                            (ID_PRODUTO, QUANTIDADE_VENDIDA, DATA)
                     VALUES (@IdProduto, @QuantidadeVendida, @Data)";
        }

        public async Task<RetornoOperacao> InserirVenda(VendaProdutoDto vendaProdutoDto)
        {
            try
            {
                using var db = GetSqlConnection();

                var sucesso = await db.ExecuteAsync(InserirVendasSql(), vendaProdutoDto) > 0;

                if (sucesso)
                    return new RetornoOperacao(sucesso, "");

                return new RetornoOperacao(sucesso, "Venda não registrada!");
            }
            catch (Exception ex)
            {
                return new RetornoOperacao(false, ex.Message);
            }
        }

        public async Task<ICollection<VendaProdutoDto>> ObterVendas()
        {
            try
            {
                using var db = GetSqlConnection();

                return (ICollection<VendaProdutoDto>)await db.QueryAsync<VendaProdutoDto>(ObterVendasSql());
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<ICollection<VendaProdutoDto>> ObterVendasPorProduto(int idProduto)
        {
            try
            {
                using var db = GetSqlConnection();

                return (ICollection<VendaProdutoDto>)await db.QueryAsync<VendaProdutoDto>(ObterVendasPorProdutoSql(), new { ID = idProduto });
            }
            catch
            {
                return null;
            }
            
        }
    }
}
