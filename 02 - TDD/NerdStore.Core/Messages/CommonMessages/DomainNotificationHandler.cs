using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Core.Messages.CommonMessages
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}