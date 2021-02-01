using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_WPF.models
{
    
    public class Wish : Entry
    {
       
        
        
        public WishGroup group { get; set; }
        public int groupID { get; set; }
        public Wish(string name, decimal amount,ref  Category category,ref WishGroup group, Frequency frequency, LocalDate begin, int duration = 0, string desc = "") : base(name, amount,ref category, frequency, begin, duration, desc)
        {
            //this.wishDate = when;
            this.group = group;
            this.id = ++maxID;
            this.groupID = group.id;
            MessageBox.Show(groupID + " this is group wish id");
        }

        public Wish() { }
    }
}
