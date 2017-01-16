using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public interface IBase
    {
        DateTime CreatedDate { get; set; }
        int Id { get; set; }
    }
}
