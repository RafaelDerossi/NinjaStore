using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Aplication.Events;
using NinjaStore.Produtos.Domain.Interfaces;
using NinjaStore.Produtos.Infra.Data.Repository;
using NinjaStore.Produtos.Aplication.Query;
using NinjaStore.Clientes.Aplication.Commands;
using NinjaStore.Clientes.Aplication.Events;
using NinjaStore.Clientes.Aplication.Query;
using NinjaStore.Clientes.Domain.Interfaces;
using NinjaStore.Clientes.Infra.Data.Repository;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Domain.Interfaces;
using NinjaStore.Pedidos.Infra.Data.Repository;
using NinjaStore.Pedidos.Aplication.Events;
using NinjaStore.Pedidos.Aplication.Query;
using NinjaStore.Core.Messages.IntegrationEvents.Pedidos;

namespace NinjaStore.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();


            #region Cliente -Contexto
            //Cliente
            services.AddScoped<IRequestHandler<AdicionarClienteCommand, ValidationResult>, ClienteCommandHandler>();            
            services.AddScoped<INotificationHandler<ClienteAdicionadoEvent>, ClienteEventHandler>();            
            #endregion

            #region Produto -Contexto
            //Produto
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<DebitarEstoqueCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<INotificationHandler<ProdutoAdicionadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<EstoqueDebitadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoAdicionadoEvent>, ProdutoEventHandler>();
            #endregion

            #region Pedido -Contexto
            //Pedido            
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarPedidoCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<INotificationHandler<PedidoAdicionadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoAprovadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoCanceladoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<EstoqueDoPedidoDebitadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<EstoqueDoPedidoInsuficienteEvent>, PedidoEventHandler>();

            #endregion



            #region Querys            
            services.AddScoped<IProdutoQuery, ProdutoQuery>();            
            services.AddScoped<IClienteQuery, ClienteQuery>();            
            services.AddScoped<IPedidoQuery, PedidoQuery>();
            #endregion

            #region Repositórios                        
            services.AddScoped<IProdutoRepository, ProdutoRepository>();            
            services.AddScoped<IClienteRepository, ClienteRepository>();            
            services.AddScoped<IPedidoRepository, PedidoRepository>();            

            #endregion

            #region Repositórios Query                           
            services.AddScoped<IProdutoQueryRepository, ProdutoQueryRepository>();
            services.AddScoped<IClienteQueryRepository, ClienteQueryRepository>();
            services.AddScoped<IPedidoQueryRepository, PedidoQueryRepository>();
            #endregion

        }
    }
}
