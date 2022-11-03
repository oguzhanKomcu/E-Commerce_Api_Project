using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using ECommerceApi.Application.RepositoriesInterface;
using ECommerceApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.RepositoriesConcretes
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> table;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<T>();
        }

        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await table.AnyAsync(expression);
        }

        public async Task Create(T entity)
        {
            await table.AddAsync(entity);
        }


        public async void Delete(T entity)
        {

        }

        public async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await table.FirstOrDefaultAsync(expression);
        }
        public async Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy =
                                                        null,
                                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>?
                                                        include = null,
                                                      int index = 0, int size = 10, bool enableTracking = true,
                                                      CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                                      Expression<Func<T, bool>> expression = null,
                                                                      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                                      bool disableTracing = true)
        {
            IQueryable<T> query = table;

            if (disableTracing)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (expression != null)
                query = query.Where(expression);

            return await query.Select(selector).FirstOrDefaultAsync();
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracing = true, int pageIndex = 1, int pageSize = 3)
        {
            IQueryable<T> query = table;

            if (disableTracing)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (expression != null)
                query = query.Where(expression);

            if (orderBy != null)
                return await orderBy(query).Select(selector).Skip((pageIndex - 1) * pageSize).ToListAsync();
            else
                return await query.Select(selector).Skip((pageIndex - 1) * pageSize).ToListAsync();
        }

        public void Update(T entity)
        {
            _appDbContext.Entry<T>(entity).State = EntityState.Modified;
        }



        public IQueryable<T> Query()
        {
            return _appDbContext.Set<T>();
        }

        public async Task<IPaginate<T>> GetListByDynamicAsync(Dynamic dynamic,
                                                                  Func<IQueryable<T>,
                                                                          IIncludableQueryable<T, object>>?
                                                                      include = null,
                                                                  int index = 0, int size = 10,
                                                                  bool enableTracking = true,
                                                                  CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }


    }
}
