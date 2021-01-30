using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public class WishGroup:Category
    {
        public LocalDate begin { get; set; }
        public LocalDate end { get; set; }


        public WishGroup()
        {

        }
        public WishGroup(string name, LocalDate begin,int duration):base(name)
        {
            this.begin = begin;
            this.end = begin.PlusMonths(duration);
        }
    }
}
