using NinjaStore.Core.DomainObjects;
using NinjaStore.Pedidos.Aplication.ViewModels;
using System;

namespace NinjaStore.Pedidos.Aplication.DTO
{
    public class ClienteDTO
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }

        public string Aldeia { get; protected set; }

        public ClienteDTO()
        {
        }

        public ClienteDTO(Guid id, string nome, string email, string aldeia)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aldeia = aldeia;
        }
    }
}
