using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class UserPreferences : Base
    {
        public string UserId { get; set; }
        public string Color { get; set; }
        public string ColorType { get; set; }
        public int Price { get; set; }
        public string Made { get; set; }
        public string Sex { get; set; }
        public int Collar { get; set; }
        public int Arms { get; set; }
        public int Sleeve { get; set; }
        public int ShirtLength { get; set; }
        public int Waist { get; set; }
        public int Chest { get; set; }
        public int Cuff { get; set; }
        public string Composition { get; set; }
    }
}
