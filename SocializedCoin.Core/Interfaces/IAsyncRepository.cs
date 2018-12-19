using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(ObjectId id);
        Task<T> GetBySpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        /*void UpdateAsync(T entity);
        void DeleteAsync(T entity);*/
    }
}