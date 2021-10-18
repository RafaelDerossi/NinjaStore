using FluentValidation.Results;
using MediatR;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Core.Messages.IntegrationEvents.Pedidos;
using NinjaStore.Pedidos.Domain;
using NinjaStore.Pedidos.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public class PedidoCommandHandler : CommandHandler,
         IRequestHandler<AdicionarPedidoCommand, ValidationResult>,
         IRequestHandler<AprovarPedidoCommand, ValidationResult>,
         IRequestHandler<CancelarPedidoCommand, ValidationResult>,
         IDisposable
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarPedidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var pedido = new Pedido(request.Cliente.Id);

            foreach (var item in request.Produtos)
            {                
                pedido.AdicionarProduto(new Produto(item.Id, item.ProdutoId,
                                                    item.Descricao, item.Foto,
                                                    item.Valor, item.Quantidade,
                                                    item.Desconto, item.ValorTotal));
            }

            _pedidoRepository.Adicionar(pedido);

            //Evento
            pedido.AdicionarEvento
                 (new PedidoAdicionadoEvent
                 (pedido.Id, pedido.Numero, pedido.Status, pedido.Valor, pedido.Desconto,
                  pedido.ValorTotal, request.Cliente, request.Produtos));

            return await PersistirDados(_pedidoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AprovarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.ObterPorId(request.AggregateId);
            if (pedido == null)
            {
                AdicionarErro("Pedido não encontrado");
                return ValidationResult;
            }
                

            pedido.AprovarPedido();

            _pedidoRepository.Atualizar(pedido);

            //Evento
            pedido.AdicionarEvento
                (new PedidoAprovadoEvent(pedido.Id));

            return await PersistirDados(_pedidoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CancelarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.ObterPorId(request.Id);
            if (pedido == null)
            {
                AdicionarErro("Pedido não encontrado");
                return ValidationResult;
            }

            pedido.CancelarPedido(request.JustificativaCancelamento);

            _pedidoRepository.Atualizar(pedido);

            //Evento
            pedido.AdicionarEvento
                (new PedidoCanceladoEvent(pedido.Id, request.JustificativaCancelamento));

            return await PersistirDados(_pedidoRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _pedidoRepository?.Dispose();
        }

    }
}
