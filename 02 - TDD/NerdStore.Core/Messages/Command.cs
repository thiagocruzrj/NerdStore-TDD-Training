using FluentValidation.Results;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Command : Message
    {
        public DateTime TimesStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            TimesStamp = DateTime.Now;
        }

        public abstract bool EhValido();
    }
}