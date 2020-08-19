using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLLIMS.Models
{
    public class Laboratory
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public ICollection<LaboratoryToInstrument> LaboratoryToInstruments { get; set; }
    }
}
