using MongoDB.Driver;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Core.Specifications
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        private static IFindFluent<T, T> _result;
        public static IFindFluent<T,T> GetQuery(IMongoCollection<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;
            // modify the IQueryable using the specification's criteria expression
            _result = specification.Criteria != null ? query.Find(specification.Criteria): query.Find(_ => true);
            // Includes all expression-based includes
            /*query = specification.Includes.Aggregate(query,
                (current, include) => current.Include(include));*/

            // Include any string-based include statements
            /*query = specification.IncludeStrings.Aggregate(query,
                (current, include) => current.Include(include));*/

            // Apply ordering if expressions are set
            if (!string.IsNullOrEmpty(specification.OrderBy))
                _result = _result.Sort(Builders<T>.Sort.Ascending(specification.OrderBy));
            
            /*else if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);*/

            // Apply paging if enabled
            /*if (specification.isPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }*/
            return _result;
        }
    }
}