using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;
using Handel.DataAccess.Contract.IRepository;
using Handel.DataAccess.Implementation.Context;

namespace Handel.DataAccess.Impl.Repositories
{
    public class ShopRepository : RepositoryBase, IRepository<Shop>
    {
        public ShopRepository(ApplicationContext context) : base(context)
        {

        }

        public void Add(Shop obiekt)
        {
            throw new NotImplementedException();
        }

        public Shop FindObject(Expression<Func<Shop, bool>> query)
        {
            throw new NotImplementedException();
        }

        public void AddRange(ICollection<Shop> collection)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Shop> GetAll()
        {
            throw new NotImplementedException();
        }

        public Shop Delete(Shop entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Shop> FindAll(Expression<Func<Shop, bool>> func)
        {
            throw new NotImplementedException();
        }

        public Shop Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
