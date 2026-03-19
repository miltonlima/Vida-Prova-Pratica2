using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.ViewModels
{
    public class ObterSolicitacaoCompraViewModel
    {
        public Guid Id { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalGeral { get; set; }
        public string Situacao { get; set; }
        public IList<ItemSolicitacaoCompraViewModel> Itens { get; set; }
    }

    public class ItemSolicitacaoCompraViewModel
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Qtde { get; set; }
        public decimal Subtotal { get; set; }
    }
}
