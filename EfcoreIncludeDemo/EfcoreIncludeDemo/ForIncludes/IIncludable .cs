using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreIncludeDemo.Application
{
    public interface IIncludable { }

    public interface IIncludable<out TEntity> : IIncludable {
        IQueryable<TEntity> Input { get; }
    }

    public interface IIncludable<out TEntity, out TProperty> : IIncludable<TEntity> {
        IIncludableQueryable<TEntity, TProperty> IncludableInput { get; }
    }

    public class Includable<TEntity> : IIncludable<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Input { get; }

        public Includable(IQueryable<TEntity> queryable)
        {
            Input = queryable ?? throw new ArgumentNullException(nameof(queryable));
        }
    }

    public class Includable<TEntity, TProperty> :
        Includable<TEntity>, IIncludable<TEntity, TProperty>
        where TEntity : class
    {
        public IIncludableQueryable<TEntity, TProperty> IncludableInput { get; }

        public Includable(IIncludableQueryable<TEntity, TProperty> queryable) :
            base(queryable)
        {
            IncludableInput = queryable;
        }
    }
}
