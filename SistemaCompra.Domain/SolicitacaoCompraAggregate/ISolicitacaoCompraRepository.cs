using System;
using System.Threading.Tasks;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
        Task<SolicitacaoCompra> ObterAsync(Guid id);
        Task RegistrarCompraAsync(SolicitacaoCompra solicitacaoCompra);
    }
}
