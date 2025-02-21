using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestaoSupermercado.Infraestrutura.Repositorio
{
    public abstract class RepositoryBase
    {
        private readonly IConfiguration _configuration;

        protected RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SupermercadoDB"));
        }
    }
}
