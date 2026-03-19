using AutoMapper;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Application.ViewModels;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d=> d.Preco, o=> o.MapFrom(src=> src.Preco.Value));

            CreateMap<SolicitacaoAgg.SolicitacaoCompra, ObterSolicitacaoCompraViewModel>()
                .ForMember(d => d.UsuarioSolicitante, o => o.MapFrom(src => src.UsuarioSolicitante.Nome))
                .ForMember(d => d.NomeFornecedor, o => o.MapFrom(src => src.NomeFornecedor.Nome))
                .ForMember(d => d.TotalGeral, o => o.MapFrom(src => src.TotalGeral.Value));

            CreateMap<SolicitacaoAgg.Item, ItemSolicitacaoCompraViewModel>()
                .ForMember(d => d.ProdutoId, o => o.MapFrom(src => src.Produto.Id))
                .ForMember(d => d.NomeProduto, o => o.MapFrom(src => src.Produto.Nome))
                .ForMember(d => d.Subtotal, o => o.MapFrom(src => src.Subtotal.Value));
        }
    }
}
