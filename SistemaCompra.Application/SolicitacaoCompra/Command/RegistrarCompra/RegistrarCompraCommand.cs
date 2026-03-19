using MediatR;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public int CondicaoPagamento { get; set; }
        public IList<ItemRegistrarCompraCommand> Itens { get; set; } = new List<ItemRegistrarCompraCommand>();
    }

    public class ItemRegistrarCompraCommand
    {
        public Guid ProdutoId { get; set; }
        public int Qtde { get; set; }
    }
}
