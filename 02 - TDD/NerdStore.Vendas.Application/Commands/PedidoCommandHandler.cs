using MediatR;
using NerdStore.Vendas.Application.Events;
using NerdStore.Vendas.Domain;
using System.Threading;

namespace NerdStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler
    {
        private readonly IPedidoRepository _repository;
        private readonly IMediator _mediator;

        public PedidoCommandHandler(IPedidoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public bool Handle(AdicionarItemPedidoCommand message)
        {
            _repository.Adicionar(Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId));
            _mediator.Publish(new PedidoItemAdicionadoEvent());
            return true;
        }
    }
}