using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class VerificationTestToResult
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Result Result { get; set; }
        public VerificationTest VerificationTest{ get; set; }
    }
}
