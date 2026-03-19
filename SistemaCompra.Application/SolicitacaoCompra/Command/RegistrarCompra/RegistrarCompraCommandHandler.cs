using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : IRequestHandler<RegistrarCompraCommand>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(
            ISolicitacaoCompraRepository solicitacaoCompraRepository,
            IProdutoRepository produtoRepository)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _produtoRepository = produtoRepository;
        }

        async Task<Unit> IRequestHandler<RegistrarCompraCommand, Unit>.Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(
                request.UsuarioSolicitante,
                request.NomeFornecedor,
                request.CondicaoPagamento);

            var itens = new List<Item>();
            foreach (var item in request.Itens)
            {
                var produto = await _produtoRepository.ObterAsync(item.ProdutoId);
                if (produto == null)
                {
                    continue;
                }

                itens.Add(new Item(produto, item.Qtde));
            }

            solicitacaoCompra.RegistrarCompra(itens);
            await _solicitacaoCompraRepository.RegistrarCompraAsync(solicitacaoCompra);

            return Unit.Value;
        }
    }
}
