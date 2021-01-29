using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class Outcome : Entry
    {
     
        public Outcome(string name, decimal outcome, Category category, Frequency grequency, LocalDate begin,int duration,string description) : base(name, outcome, category, grequency, begin,duration,description)
        {
        
        }

        public Outcome()
        {

        }
    }
}
