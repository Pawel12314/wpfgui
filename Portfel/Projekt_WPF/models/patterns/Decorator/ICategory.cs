using Projekt_WPF.models.patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryClass
{
    public abstract class ICategory : ICategoryBase
    {
        
        protected abstract ICategoryBase getDecoree();

    }
}
