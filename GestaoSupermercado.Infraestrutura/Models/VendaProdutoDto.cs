using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoSupermercado.Infraestrutura.Models
{
    public class VendaProdutoDto
    {
        public VendaProdutoDto() { }

        public VendaProdutoDto(int idProduto, int quantidadeVendida, DateTime data)
        {
            IdProduto = idProduto;
            QuantidadeVendida = quantidadeVendida;
            Data = data;
        }

        public VendaProdutoDto(int id, int idProduto, int quantidade, DateTime data)
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
