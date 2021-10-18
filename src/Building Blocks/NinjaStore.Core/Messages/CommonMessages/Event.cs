using System;
using NinjaStore.Core.Helpers;
using MediatR;

namespace NinjaStore.Core.Messages.CommonMessages
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DataHoraDeBrasilia.Get();
        }
    }
}