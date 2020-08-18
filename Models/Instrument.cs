using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class Instrument
    {
        public string Name { get; set; }
        public string Vendor { get; set; }
        public int VerificationSchedule { get; set; }
        public int CalibrationSchedule { get; set; }
        public ICollection<InstrumentToVerificationTests> InstrumentToVerTests { get; set; }
    }
}
