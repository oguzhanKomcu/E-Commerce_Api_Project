using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.RepositoriesInterface
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        void Update(T entity);
        Task Commit();

        void Delete(T entity);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);

        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                                 Expression<Func<T, bool>> expression,
                                                                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool dissableTracing = true);

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector,
                                                  Expression<Func<T, bool>> expression,
                                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                    bool dissableTracing = true,
                                    int pageIndex = 1,
                                    int pageSize = 3);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                int index = 0, int size = 10, bool enableTracking = true,
                                CancellationToken cancellationToken = default);



        Task<IPaginate<T>> GetListByDynamicAsync(Dynamic dynamic,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 int index = 0, int size = 10, bool enableTracking = true,
                                                 CancellationToken cancellationToken = default);


    }
}
