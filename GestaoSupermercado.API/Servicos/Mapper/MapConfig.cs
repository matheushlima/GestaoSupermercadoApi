using AutoMapper;
using GestaoSupermercado.API.Models;
using GestaoSupermercado.Infraestrutura.Models;

namespace GestaoSupermercado.API.Servicos.Mapper
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<ProdutoModelEntrada, ProdutoDto>();
            CreateMap<ProdutoDto, ProdutoModelSaida>();
            CreateMap<VendaProdutoDto, VendaProdutoModelSaida>();
        }
    }
}
