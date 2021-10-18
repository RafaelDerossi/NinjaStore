using NinjaStore.Core.ValueObjects;
using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Clientes.Domain.FlatModel
{
   public class ClienteFlat : IAggregateRoot
   {
        public const int Max = 200;
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada
        {
            get
            {
                if (DataDeCadastro != null)
                    return DataDeCadastro.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada
        {
            get
            {
                if (DataDeAlteracao != null)
                    return DataDeAlteracao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }        

        public bool Lixeira { get; private set; }

       
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Aldeia { get; private set; }

        protected ClienteFlat()
        {
        }

        public ClienteFlat(Guid id, string nome, Email email, string aldeia)
        {
            Id = id;
            Nome = nome;
            SetEmail(email);
            Aldeia = aldeia;
        }

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public void SetNome(string nome) => Nome = nome;

        public void SetEmail(Email email)
        {
            if (email == null)
                Email = "";
            Email = email.Endereco;
        }

        public void SetAldeia(string aldeia) => Aldeia = aldeia;

    }
}
