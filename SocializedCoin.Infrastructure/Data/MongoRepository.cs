using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;
using SocializedCoin.Core.Specifications;
using SocializedCoin.Infrastructure.Settings;

namespace SocializedCoin.Infrastructure.Data
{
    public class MongoRepository<T>:IAsyncRepository<T> where T: BaseEntity
    {
        private readonly MongoDbContext<T> _context;
        
        public MongoRepository()
        {
            _context = new MongoDbContext<T>(MongoDbSettings.SocializedCoinDatabase);
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.GetMongoCollection().AsQueryable(), spec);
        }
        public async Task<T> GetByIdAsync(ObjectId id)
        {
            try
            {
                return await _context.GetMongoCollection().Find(_ => _.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<T> GetBySpecAsync(ISpecification<T> spec)
        {
            return (await ListBySpecAsync(spec)).FirstOrDefault();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            try
            {
                return await _context.GetMongoCollection().Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.GetMongoCollection().InsertOneAsync(entity);
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*public void UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }*/
    }
}