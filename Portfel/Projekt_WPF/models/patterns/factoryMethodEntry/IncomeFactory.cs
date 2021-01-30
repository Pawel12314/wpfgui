using NodaTime;
using Projekt_WPF.models.patterns.CategoryClass;
using Projekt_WPF.models.patterns.Decorator;
using Projekt_WPF.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.factoryMethodEntry
{
    public class IncomeFactory : IEntryFactory
    {
        public override void addElement(Entry e,MainWindow main)
        {
            ((UserControlEntries)(main).mainWindowFrame.Content).dodajWpis(e);
        }

        public override Entry createEntry(string name, decimal amount, string description, ICategoryBase categories, LocalDate begin, int duration)
        {
            Category cat =categories.getCategory();
            return new Income(name, amount,ref cat, Frequency.comiesieczny, begin, duration, description);
        }
    }
}
