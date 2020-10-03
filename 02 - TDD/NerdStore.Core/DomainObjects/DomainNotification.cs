using MediatR;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.DomainObjects
{
    public class DomainNotification: Message, INotification
    {
        public DomainNotification(DateTime timestamp, Guid domainNotificationId, string key, string value, int version)
        {
            Timestamp = DateTime.Now;
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
    }
}