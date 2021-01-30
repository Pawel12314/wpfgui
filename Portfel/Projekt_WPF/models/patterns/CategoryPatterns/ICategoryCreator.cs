using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns
{
    public  abstract class ICategoryCreator
    {

        public abstract string getName();

        public abstract LocalDate getBegin();

        public abstract int  getDuration();
    }
}
