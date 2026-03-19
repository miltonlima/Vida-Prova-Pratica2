using System;
using System.Threading.Tasks;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        Task<SolicitacaoCompra> ObterAsync(Guid id);
        Task RegistrarCompraAsync(SolicitacaoCompra solicitacaoCompra);
    }
}
