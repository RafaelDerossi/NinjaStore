using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NinjaStore.Core.DomainObjects;

namespace NinjaStore.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWorks UnitOfWork { get; }

        Task<TEntity> ObterPorId(Guid Id);               

        /// <summary>
        /// Método Genérico para consultas aleatórias
        /// </summary>
        /// <param name="expression">Expressão de consulta</param>
        /// <param name="OrderByDesc">[false - Padrão] = Order by Crescente / [True] = Ordernar decrescentemente pela data de cadastro</param>
        /// <param name="take">Quando passado efetua um Take da quantidade de itens selecionada</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Obter(Expression<Func<TEntity, bool>> expression, bool OrderByDesc = false, int take = 0);

        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Apagar(Func<TEntity, bool> predicate);        
    }
}