﻿using System.Threading.Tasks;
using NinjaStore.Core.Messages;
using FluentValidation.Results;

namespace NinjaStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
