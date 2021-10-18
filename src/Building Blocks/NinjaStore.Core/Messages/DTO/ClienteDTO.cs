using System;

namespace NinjaStore.Core.Messages.DTO
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Aldeia { get; set; }

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
