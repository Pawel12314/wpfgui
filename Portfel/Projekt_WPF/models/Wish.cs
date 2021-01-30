using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models
{
    public  enum WishDate
    {
        notspecified,
        specified
    }
    public class Wish : Entry
    {
        public WishDate wishDate;
        public WishGroup group { get; set; }
        public Wish(string name, decimal amount,ref  Category category,ref WishGroup group, Frequency frequency, LocalDate begin, int duration = 0, string desc = "") : base(name, amount,ref category, frequency, begin, duration, desc)
        {
            //this.wishDate = when;
            this.group = group;
        }

        public Wish() { }
    }
}
