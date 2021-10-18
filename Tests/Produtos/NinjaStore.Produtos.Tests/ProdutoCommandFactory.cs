using NinjaStore.Produtos.Aplication.Commands;
using System;

namespace NinjaStore.Produtos.Tests
{
    public class ProdutoCommandFactory
    {
        private static AdicionarProdutoCommand AdicionarProdutoCommandFactoy()
        {
            return new AdicionarProdutoCommand("Produto", 20, "foto.jpg", 5);
        }       


        public static AdicionarProdutoCommand CriarComandoAdicionarProduto()
        {
            return AdicionarProdutoCommandFactoy();
        }

        public static AdicionarProdutoCommand CriarComandoAdicionarProdutoSemDescricao()
        {
            var comando = AdicionarProdutoCommandFactoy();
            comando.SetDescricao("");

            return comando;
        }

        public static AdicionarProdutoCommand CriarComandoAdicionarProdutoComValorZero()
        {
            var comando = AdicionarProdutoCommandFactoy();
            comando.SetValor(0);

            return comando;
        }

        public static AdicionarProdutoCommand CriarComandoAdicionarProdutoComValorNegativo()
        {
            var comando = AdicionarProdutoCommandFactoy();
            comando.SetValor(-1);

            return comando;
        }
    }
}