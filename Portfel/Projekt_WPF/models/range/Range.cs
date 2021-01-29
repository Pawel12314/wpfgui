using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.range
{
    public class Range
    {
        private Value min { get; set; }
        private Value max { get; set; }
        

        public Range() { }
        public Range(Value min, Value max)
        {
            this.min = min;
            this.max = max;
        }

        public decimal getMin()
        {
            return min.getValue();
        }
        public decimal getMax()
        {
            return max.getValue();
        }
    }
}
