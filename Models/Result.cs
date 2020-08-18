using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class Result
    {
        public DateTime RunDate { get; set; }
        public double Value { get; set; }
        public string Comment { get; set; }

        public bool Deleted = false;
    }
}
