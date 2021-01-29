using Newtonsoft.Json;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class Income : Entry
    {

     
        public Income(string name, decimal income, ref Category cateogry, Frequency frequency, LocalDate begin,int duration, string description):base(name,income,ref cateogry,frequency,begin,duration,description)
        {
           
        }
        public Income()
        {

        }

        
    }
}
