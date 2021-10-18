using NinjaStore.Core.ValueObjects;
using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Clientes.Domain
{
    public class Cliente : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Nome { get; private set; }

        public Email Email { get; private set; }

        public string Aldeia { get; private set; }

        protected Cliente()
        {
        }

        public Cliente(string nome, Email email, string aldeia)
        {
            Nome = nome;
            Email = email;
            Aldeia = aldeia;
        }


        public void SetNome(string nome) => Nome = nome;

        public void SetEmail(Email email) => Email = email;

        public void SetAldeia(string aldeia) => Aldeia = aldeia;
    }
}
