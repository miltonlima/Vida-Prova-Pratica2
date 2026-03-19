using AutoMapper;
using MediatR;
using SistemaCompra.Application.ViewModels;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Query.ObterSolicitacaoCompra
{
    public class ObterSolicitacaoCompraQueryHandler : IRequestHandler<ObterSolicitacaoCompraQuery, ObterSolicitacaoCompraViewModel>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IMapper _mapper;

        public ObterSolicitacaoCompraQueryHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IMapper mapper)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _mapper = mapper;
        }

        public async Task<ObterSolicitacaoCompraViewModel> Handle(ObterSolicitacaoCompraQuery request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = await _solicitacaoCompraRepository.ObterAsync(request.Id);
            return _mapper.Map<ObterSolicitacaoCompraViewModel>(solicitacaoCompra);
        }
    }
}
