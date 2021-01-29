using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.range
{
    public abstract class Value
    {
        public Value() { }
        public abstract decimal getValue(); 
    }
}
