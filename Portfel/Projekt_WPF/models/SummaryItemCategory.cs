using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class SummaryItemCategory : SummaryItem
    {
        public Category el { get; set; }

        public SummaryItemCategory() { }
        public SummaryItemCategory(Category k)
        {
            this.el = k;
        }
        public Category getElement()
        {
            return el;

        }
        public override string ToString()
        {
            return el.ToString() + " łączna kwota: " + amount.ToString();
        }
    }
}
