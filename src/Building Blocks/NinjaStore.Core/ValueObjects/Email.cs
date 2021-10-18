using NinjaStore.Core.DomainObjects;
using System.Text.RegularExpressions;

namespace NinjaStore.Core.ValueObjects
{
    public class Email
    {
        public const int EmailMaximo = 255;

        public string Endereco { get; private set; }

        protected Email() { }

        public Email(string endereco)
        {
            if (!string.IsNullOrEmpty(endereco))
            {
                setEndereco(endereco);
            }
        }

        private void setEndereco(string EnderecoDeEmail)
        {
            Regex regex = new Regex(@"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+");
            Match match = regex.Match(EnderecoDeEmail);

            if (match.Success)
                Endereco = EnderecoDeEmail.ToLower().Trim();
            else
                throw new DomainException("E-mail inválido!");
        }

        public override bool Equals(object obj)
        {
            var Email = (Email)obj;

            return Endereco.Trim().ToLower() == Email.Endereco.Trim().ToLower();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Endereco;
        }
    }
}