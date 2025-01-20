using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> QueryableAsNoTracking<TEntity>(this DbContext context)
        where TEntity : class
    {
        return context.Queryable<TEntity>().AsNoTracking();
    }

    public static IQueryable<TEntity> Queryable<TEntity>(this DbContext context)
        where TEntity : class
    {
        return context.Set<TEntity>();
    }
}