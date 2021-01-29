using NodaTime;
using Projekt_WPF.models.patterns.CategoryClass;
using Projekt_WPF.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.factoryMethodEntry
{
    public class WishFactory : IEntryFactory
    {
        public override void addElement(Entry e,MainWindow window)
        {
            ((BudgetPage)(window).mainWindowFrame.Content).addWish(e);
        }

        public override Entry createEntry(string name, decimal amount, string description, ICategory categories, LocalDate begin, int duration)
        {
            Category entrycat = categories.getCategory();
            //Category wishCategory = categories.getWishCategory();
            return new Wish(name, amount, ref entrycat, Frequency.comiesieczny, begin, duration, description);
        }
    }
}
