using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns
{
    public class CategoryDecoratorCreator : ICategoryDecoratorCreator
    {
        private string name { get; set; }

        private ICategoryCreator decor { get; set; }
        public CategoryDecoratorCreator(string name, ICategoryCreator decor)
        {
            this.name = name;
            this.decor = decor;

        }

        public override string getName()
        {
            return name;
        }

        public override LocalDate getBegin()
        {
            return getDecoree().getBegin();
        }

        public override int getDuration()
        {
            return getDecoree().getDuration();
        }

        public override ICategoryCreator getDecoree()
        {
            return decor;
        }
    }
}
