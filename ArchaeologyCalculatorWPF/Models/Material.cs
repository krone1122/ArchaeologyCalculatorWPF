using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchaeologyCalculatorWPF.Models
{
    public class Material
    {
        public string? Name { get; set; }
        public int AmountNeeded { get; set; }

        public int AmountOwned { get; set; }
    }
}
