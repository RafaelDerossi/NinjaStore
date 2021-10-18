using NinjaStore.Core.Mediator;
using NinjaStore.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NinjaStore.Produtos.Aplication.Query;
using NinjaStore.Produtos.Aplication.ViewModels;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Domain.FlatModel;

namespace NinjaStore.Api.Controllers
{
    [Route("api/produto")]
    public class ProdutoController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        private readonly IProdutoQuery _produtoQuery;

        public ProdutoController
            (IMediatorHandler mediatorHandler, IProdutoQuery produtoQuery)
        {
            _mediatorHandler = mediatorHandler;
            _produtoQuery = produtoQuery;
        }


        /// <summary>
        /// Retorna todos os produtos cadastrados;
        /// </summary>
        /// <response code="200">
        /// Id: Guid do produto;   
        /// DataDeCadastro: Data em que o produto foi cadastrado;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que o produto foi cadastrado;   
        /// DataDeAlteracao:  Data em que o produto foi alterado;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que o produto foi alterado;   
        /// Lixeira: Informa se o produto esta na lixeira;   
        /// Descricao: Descrição do produto;   
        /// Valor: Preço do produto; 
        /// Estoque: Quantidade em estoque do produto;    
        /// Foto: Foto do produto;   
        /// </response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFlat>>> ObterTodos()
        {
            var produtos = await _produtoQuery.ObterTodos();
            if (produtos.Count() == 0)
                return CustomResponse("Nenhum produto encontrado.");
            
            return produtos.ToList();
        }


        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="viewModel">
        /// Descricao: Descrição do produto (Obrigatório)(De 1 a 200 caracteres);             
        /// Valor: Preço do produto (Obrigatório);   
        /// Foto: Foto do produto;  
        /// Estoque: Quantidade em estoque do produto;    
        /// </param>        
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarProdutoCommand
                (viewModel.Descricao, viewModel.Valor, viewModel.Foto, viewModel.Estoque);           

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }
        
    }
}
