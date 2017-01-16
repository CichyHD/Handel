using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class ShirtModel : Base
    {
        [Required]
        public string Color { get; set; }

        [Required]
        public string ColorType { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Made { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int Collar { get; set; }

        [Required]
        public int Arms { get; set; }

        [Required]
        public int Sleeve { get; set; }

        [Required]
        public int ShirtLength { get; set; }

        [Required]
        public int Waist { get; set; }

        [Required]
        public int Chest { get; set; }

        [Required]
        public int Cuff { get; set; }
    }
}
