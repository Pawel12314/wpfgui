using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns
{
    public class WishDecoratorCreator : ICategoryDecoratorCreator
    {

        private ICategoryCreator decor { get; set; }
        private int duration { get; set; }
        private LocalDate date { get; set; }
        public WishDecoratorCreator(int duration, LocalDate date,ICategoryCreator decor)
        {
            this.duration = duration;
            this.date = date;
            this.decor = decor;
        }
        public override LocalDate getBegin()
        {
            return date;
        }

        public override ICategoryCreator getDecoree()
        {
            return decor;    
        }

        public override int getDuration()
        {
            return duration;
        }

        public override string getName()
        {
            return getDecoree().getName();
        }
    }
}
