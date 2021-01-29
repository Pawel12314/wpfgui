using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class SummaryItemEntry:SummaryItem
    {
        public Entry el { get; set; }
        public SummaryItemEntry() { }
        public SummaryItemEntry(Entry p)
        {
            this.el = p;
        }
        public Entry getElement()
        {
            return el;
        }
        public override string ToString()
        {
            return el.name + " " + amount.ToString();
        }
    }
}
