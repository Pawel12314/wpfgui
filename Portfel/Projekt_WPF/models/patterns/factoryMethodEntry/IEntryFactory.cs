using NodaTime;
using Projekt_WPF.models.patterns.CategoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.factoryMethodEntry
{
    public abstract class IEntryFactory
    {
        public abstract Entry createEntry(string name, decimal amount, string description, ICategory categories, LocalDate begin, int duration);

        public abstract void addElement(Entry e,MainWindow window);
       

        
    }
}
