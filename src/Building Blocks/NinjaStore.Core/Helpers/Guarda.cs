using NinjaStore.Core.DomainObjects;

namespace NinjaStore.Core.Helpers
{
    public static class Guarda
    {
        public static void ValidarTamanhoMaximo(string value, int maxLenght, string name)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length > maxLenght)
                    throw new DomainException($"Tamanho do(a) {name} excedido!");
            }
        }

        public static void ValidarTamanhoMinimo(string value, int minLenght, string name)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length < minLenght)
                    throw new DomainException($"{name} deve ter {minLenght} caracteres ou mais!");
            }
        }

        public static void ValidarTamanhoDaSenha(string value, int minLength, int maxLenght)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length < minLength || value.Length > maxLenght)
                    throw new DomainException("Tamanho da string não atente o padrão de senha (mínimo 5 de dígitos e máximo de 8)!");
            }
            else
            {
                throw new DomainException("Valor não pode ser vazio!");
            }
        }

      
    }
}
