using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns
{
    public abstract class ICategoryDecoratorCreator : ICategoryCreator
    {
        public abstract ICategoryCreator getDecoree();
    }
}
