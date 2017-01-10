using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.DataAccess.Contract;
using Handel.DataAccess.Contract.IRepository;
using Handel.DataAccess.Contract.Services;
using Handel.DataAccess.Implementation.Context;

namespace Handel.DataAccess.Impl.Services
{
    public class FloatTestService:IFloatTestService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IAccountService _accountService;

        public FloatTestService(IShopRepository shopRepository,IAccountService accountService)
        {
            _shopRepository = shopRepository;
            _accountService = accountService;
        }
        public string DoSomeRandomShit(string message)
        {
            object repoAnswer;
              repoAnswer  = _shopRepository.someTestRepoFloatToService("mietek");
            if (repoAnswer == null)
                return "somethings goes wrong";
            return "I've done some random shit to test this float";
        }
    }
}
