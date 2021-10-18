using NinjaStore.Core.Mediator;
using NinjaStore.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NinjaStore.Clientes.Aplication.Query;
using NinjaStore.Pedidos.Aplication.ViewModels;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Aplication.Query;
using NinjaStore.Core.Messages.DTO;
using AutoMapper;

namespace NinjaStore.Api.Controllers
{
    [Route("api/pedido")]
    public class PedidoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPedidoQuery _pedidoQuery;
        private readonly IClienteQuery _clienteQuery;
        private readonly IMapper _mapper;

        public PedidoController
            (IMediatorHandler mediatorHandler, IPedidoQuery pedidoQuery,
             IClienteQuery clienteQuery, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _pedidoQuery = pedidoQuery;
            _clienteQuery = clienteQuery;
            _mapper = mapper;
        }




        /// <summary>
        /// Retorna todos os pedidos cadastrados;
        /// </summary>
        /// <response code="200">
        /// Id: Guid do pedido;   
        /// DataDeCadastro: Data em que o pedido foi realizado;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que o pedido foi realizado;   
        /// DataDeAlteracao:  Data em que o pedido foi alterado;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que o pedido foi alterado;   
        /// Lixeira: Informa se o pedido esta na lixeira;   
        /// Numero: Número do pedido;   
        /// Valor: Valor do Pedido;     
        /// Desconto: Desconto do pedido;   
        /// ValorTotal: Valor total do pedido;   
        /// ClienteId: Guid do cliente do pedido;   
        /// NomeDoCliente: Nome do cliente;   
        /// EmailDoCliente: Endereço de e-mail do cliente;   
        /// AldeiaDoCliente: Aldeia do cliente;    
        /// Produtos: Lista de Produtos do pedido:;   
        /// -- Id: Guid do produto no pedido;      
        /// -- ProdutoId: Guid do produto;      
        /// -- DataDeCadastro: Data em que o produto foi inserido no pedido;    
        /// -- DataDeCadastroFormatada: Data formatada para exibição em que o produto foi inserido no pedido;   
        /// -- DataDeAlteracao:  Data em que o produto foi alterado no pedido;   
        /// -- DataDeAlteracaoFormatada: Data formatada para exibição em que o produto foi alterado no pedido;   
        /// -- Lixeira: Informa se o produto esta na lixeira no pedido;   
        /// -- Descricao : Descrição do produto no pedido;   
        /// -- Foto: Foto do produto no pedido;   
        /// -- Valor: Valor do produto no pedido;
        /// -- Quantidade: Quantidade pedida do produto no pedido; 
        /// -- Desconto: Desconto do produto no pedido;   
        /// -- ValorTotal: Total do produto no pedido;   
        /// -- PedidoFlatId: Guid do pedido;  
        /// </response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoFlat>>> ObterTodos()
        {
            var pedidos = await _pedidoQuery.ObterTodos();
            if (pedidos.Count() == 0)
                return CustomResponse("Nenhum pedido encontrado.");

            return pedidos.ToList();
        }


        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="viewModel">
        /// ClienteId: Guid do cliente (Obrigatório);     
        /// Produtos: Lista de produtos do pedido (Obrigatório):;   
        /// -- Id: Guid do produto (Obrigatório);      
        /// -- Descricao: Descrição do produto (Obrigatório)(De 1 a 200 caracteres);    
        /// -- Foto: Foto do profuto;   
        /// -- Valor: Preço do produto;   
        /// -- Quantidade: Quantidade pedida do produto no pedido; 
        /// -- Desconto: Valor do desconto do produto;   
        /// -- ValorTotal: Valor total do produto;   
        /// </param>        
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaPedidoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = await _clienteQuery.ObterPorId(viewModel.ClienteId);
            if (cliente == null)
                return CustomResponse("Cliente não encontrado!");

            var clienteDTO = new ClienteDTO(cliente.Id, cliente.Nome, cliente.Email, cliente.Aldeia);

            var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(viewModel.Produtos).ToList();

            var comando = new AdicionarPedidoCommand(clienteDTO, produtosDTO);           

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }        
    }
}
