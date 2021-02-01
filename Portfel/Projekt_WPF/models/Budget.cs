using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class Budget 
    {
        public Budget() { }

        //public override string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public LocalDate date { get; set; }
        public decimal amount { get; set; }
        public int id { get; set; }
        public static int maxID { get; set; }
        
        public Budget(LocalDate date,decimal amount)
        {

            this.amount = amount;
            this.date = date;
            this.id = ++maxID;
        }

      
    
    }
}
