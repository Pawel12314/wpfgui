using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class SummaryItemOutcome:SummaryItem
    {
        public SummaryItemOutcome() { }
        public Outcome el { get; set; }
        public SummaryItemOutcome(Outcome w)
        {
            this.el = w;
        }

        
        
        public Outcome getElement()
        {
            return el;

        }
        public override string ToString()
        {
            return el.ToString() + "łączna kwota: " + amount.ToString();
        }
    }
}
