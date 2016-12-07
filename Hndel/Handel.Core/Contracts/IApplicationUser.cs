using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;

namespace Handel.Core.Contracts
{
    public interface IApplicationUser : IBaseObject
    {
        
        /// <summary>
        /// UserName i Email to tak na prawdę to samo w Identity (tzn logowanie w SignInManagerze jest po UserName ale wszystkie operacje w UserManagerze są po Emailu
        /// </summary>
        string UserName { get; set; }
        string Email { get; set; }
        /// <summary>
        /// np. Jan Kowalski
        /// </summary>
        string DisplayName { get; set; }
        T ConvertTo<T>() where T : class, IApplicationUser;
    }
}
