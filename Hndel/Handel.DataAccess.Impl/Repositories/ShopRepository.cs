﻿using System;
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
    public class ShopRepository : GenericRepository<Shop, Guid>
    {
        public ShopRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
