using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class SummaryItem
    {

       public SummaryItem() { }
        public decimal amount { get; set; }
       
        public void add (decimal kwota)
        {
            this.amount += kwota;
        }
        
        
        
    }
}
