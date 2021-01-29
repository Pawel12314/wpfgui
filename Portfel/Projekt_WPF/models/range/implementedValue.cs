using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.range
{
    public class implementedValue : Value
    {
        private decimal value { get; set; }
        
        public implementedValue() { }
        public implementedValue(decimal val)
        {
            this.value = val;
        }
        public override decimal getValue()
        {
            return value;
        }
    }
}
