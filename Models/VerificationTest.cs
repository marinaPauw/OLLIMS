using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class VerificationTest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double MeasurementrangeBottom { get; set; }
        public double MeasurementrangeTop { get; set; }
        public string Unit { get; set; }
        public ICollection<VerificationTestToResult> VerTestToResults { get; set; }
    }
}
