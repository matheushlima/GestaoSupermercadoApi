using Dapper;
using GestaoSupermercado.Infraestrutura.Models;
using GestaoSupermercado.Infraestrutura.Repositorio.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestaoSupermercado.Infraestrutura.Repositorio.Implementacoes
{
    public class ProdutoRepository : RepositoryBase, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        private string ObterProdutosSql()
        {
            return @"SELECT * 
                       FROM PRODUTOS";
        }

        private string ObterProdutosIdSql()
        {
            return @"SELECT * 
                       FROM PRODUTOS
                      WHERE ID = @ID";
        }

        private string DeletarProdutoSql()
        {
            return @"DELETE 
                       FROM PRODUTOS
                      WHERE ID = @ID";
        }

        private string CadastrarProdutoSql()
        {
            return @"INSERT INTO PRODUTOS  
                            (NOME, QUANTIDADE, PESO, UNIDADE_MEDIDA)
                     VALUES (@Nome, @Quantidade, @Peso, @UnidadeMedida)";
        }

        private string AtualizarProdutoSql()
        {
            return @"UPDATE PRODUTOS  
                        SET NOME = @Nome,
                            QUANTIDADE = @Quantidade,
                            PESO = @Peso, 
                            UNIDADE_MEDIDA = @UnidadeMedida
                      WHERE ID = @ID";
        }

        private string AtualizarProdutoVendaSql()
        {
            return @"UPDATE PRODUTOS  
                        SET NOME = @Nome,
                            QUANTIDADE = @Quantidade,
                            PESO = @Peso, 
                            UNIDADE_MEDIDA = @UnidadeMedida,
                            DATA_ULTIMA_VENDA = @DataUltimaVenda
                      WHERE ID = @ID";
        }

        public async Task<RetornoOperacao> AtualizarProduto(ProdutoDto produtoDto)
        {
            try
            {
                using var db = GetSqlConnection();

                var sucesso = await db.ExecuteAsync(AtualizarProdutoSql(), produtoDto) > 0;

                if (sucesso)
                    return new RetornoOperacao(sucesso, "");

                return new RetornoOperacao(sucesso, "Produto não encontrado");
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
                using var db = GetSqlConnection();

                var sucesso = await db.ExecuteAsync(CadastrarProdutoSql(), produtoDto) > 0;

                if (sucesso)
                    return new RetornoOperacao(sucesso, "");

                return new RetornoOperacao(sucesso, "Produto não encontrado");
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
                using var db = GetSqlConnection();

                var sucesso = await db.ExecuteAsync(DeletarProdutoSql(), new { ID = id }) > 0;

                if(sucesso)
                    return new RetornoOperacao(sucesso, "");

                return new RetornoOperacao(sucesso, "Produto não encontrado");
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
                using var db = GetSqlConnection();

                return await db.QueryFirstOrDefaultAsync<ProdutoDto>(ObterProdutosIdSql(), new { ID = id });
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
                using var db = GetSqlConnection();

                return (ICollection<ProdutoDto>)await db.QueryAsync<ProdutoDto>(ObterProdutosSql());
            }
            catch
            {
                return null;
            }
        }

        public async Task<RetornoOperacao> AtualizarProdutoVenda(ProdutoDto produtoDto)
        {
            try
            {
                using var db = GetSqlConnection();

                var sucesso = await db.ExecuteAsync(AtualizarProdutoVendaSql(), produtoDto) > 0;

                if (sucesso)
                    return new RetornoOperacao(sucesso, "");

                return new RetornoOperacao(sucesso, "Produto não encontrado");
            }
            catch (Exception ex)
            {
                return new RetornoOperacao(false, ex.Message);
            }
        }
    }
}
