using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class Instrument
    {
        public string Name;
        public double MeasurementrangeBottom;
        public double MeasurementrangeTop;
        public string Unit;
        public string Vendor;
        public int VerificationSchedule;
        public int CalibrationSchedule;
    }
}
