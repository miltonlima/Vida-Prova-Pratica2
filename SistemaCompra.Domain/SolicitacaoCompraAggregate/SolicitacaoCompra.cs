using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, int condicaoPagamento = 0)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Itens = new List<Item>();
            CondicaoPagamento = new CondicaoPagamento(condicaoPagamento);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            var itensRegistrados = itens?.ToList() ?? new List<Item>();
            var totalItens = itensRegistrados.Sum(i => i.Qtde);
            var totalGeral = itensRegistrados.Sum(i => i.Subtotal.Value);

            ValidarRegrasCompra(totalItens, totalGeral);

            Itens = itensRegistrados;
            TotalGeral = new Money(totalGeral);
        }

        private void ValidarRegrasCompra(int totalItens, decimal totalGeral)
        {
            if (totalItens <= 0)
            {
                throw new BusinessRuleException("O total de itens de compra deve ser maior que 0.");
            }

            if (totalGeral > 50000 && CondicaoPagamento.Valor != 30)
            {
                throw new BusinessRuleException("Para compras acima de 50000, a condição de pagamento deve ser 30 dias.");
            }
        }
    }
}
