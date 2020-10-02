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
            _repository.Adicionar(Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId));

            await _mediator.Publish(new PedidoItemAdicionadoEvent(), cancellationToken);
            return true;
        }
    }
}