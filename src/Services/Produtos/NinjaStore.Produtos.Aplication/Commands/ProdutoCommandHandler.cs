using FluentValidation.Results;
using MediatR;
using NinjaStore.Core.Messages;
using NinjaStore.Produtos.Aplication.Events;
using NinjaStore.Produtos.Domain;
using NinjaStore.Produtos.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Commands
{
    public class ProdutoCommandHandler : CommandHandler,
         IRequestHandler<AdicionarProdutoCommand, ValidationResult>,
         IDisposable
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var produto = new Produto
                (request.Descricao, request.Valor, request.Foto, request.Estoque);
           
            _produtoRepository.Adicionar(produto);

            //Evento
            produto.AdicionarEvento(new ProdutoAdicionadoEvent(produto.Id, produto.Descricao,
                                                               produto.Valor, produto.Foto,
                                                               produto.Estoque));

            return await PersistirDados(_produtoRepository.UnitOfWork);
        }
               

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
