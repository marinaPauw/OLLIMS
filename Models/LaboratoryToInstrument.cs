using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class LaboratoryToInstrument
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Laboratory Laboratory {get; set;}
        public Instrument Instrument { get; set; }
        
    }
}
