﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handel.Core.BusinessClasses
{
    public interface IBaseObject<T>
    {
        T Id { get; set; }
    }
}
