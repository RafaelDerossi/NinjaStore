using NinjaStore.Clientes.Aplication.Commands;
using System;

namespace NinjaStore.Clientes.Tests
{
    public class ClienteCommandFactory
    {
        private static AdicionarClienteCommand AdicionarClienteCommandFactoy()
        {
            return new AdicionarClienteCommand
                ("Nome do cliente", "rafael@gmail.com", "aldeia");
        }       


        public static AdicionarClienteCommand CriarComandoAdicionarCliente()
        {
            return AdicionarClienteCommandFactoy();
        }

        public static AdicionarClienteCommand CriarComandoAdicionarClienteSemEmail()
        {
            var comando = AdicionarClienteCommandFactoy();
            comando.SetEmail("");

            return comando;
        }
       
    }
}