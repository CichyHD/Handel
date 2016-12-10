using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;
using Handel.DataAccess.Contract.IRepository;

namespace Handel.DataAccess.Impl.Repositories
{
    public abstract class GenericRepository<TEntity,TId>:IGenericRepository<TEntity,TId>
        where TEntity:BaseObject<TId>
    {
        protected DbContext _context;
        protected readonly IDbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> query)
        {
            IQueryable<TEntity> q = _dbSet.Where(query).AsQueryable();
            return q;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity);
        }
    }
}
