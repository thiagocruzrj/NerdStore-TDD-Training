using FluentValidation.Results;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }

    public abstract class Command : Message
    {
        public DateTime TimesStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            TimesStamp = DateTime.Now;
        }
    }
}