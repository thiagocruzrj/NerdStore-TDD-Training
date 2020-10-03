using MediatR;
using NerdStore.Vendas.Application.Events;
using NerdStore.Vendas.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepository _repository;
        private readonly IMediator _mediator;

        public PedidoCommandHandler(IPedidoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
            pedido.AdicionarItem(pedidoItem);

            _repository.Adicionar(pedido);

            await _mediator.Publish(new PedidoItemAdicionadoEvent(message.ClienteId, pedido.Id, message.ProdutoId,
                message.Nome, message.ValorUnitario, message.Quantidade), cancellationToken);

            return true;
        }
    }
}