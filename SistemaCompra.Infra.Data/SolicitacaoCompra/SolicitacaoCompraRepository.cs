using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitacaoAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public async Task<SolicitacaoAgg.SolicitacaoCompra> ObterAsync(Guid id)
        {
            return await context.Set<SolicitacaoAgg.SolicitacaoCompra>()
                .Include(s => s.Itens)
                    .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public void RegistrarCompra(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<SolicitacaoAgg.SolicitacaoCompra>().Add(solicitacaoCompra);
        }

        public async Task RegistrarCompraAsync(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            await context.Set<SolicitacaoAgg.SolicitacaoCompra>().AddAsync(solicitacaoCompra);
        }
    }
}
