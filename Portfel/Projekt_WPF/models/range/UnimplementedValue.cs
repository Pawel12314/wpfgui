using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.range
{
    public class UnimplementedValue :Value
    {
        public UnimplementedValue() { }
        public override decimal getValue()
        {
            throw new NotImplementedException();
        }
    }
}
