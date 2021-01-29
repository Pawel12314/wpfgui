using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.Decorator
{
    public abstract class ICategoryBase
    {
        public abstract Category getCategory();
        public abstract Category getWishCategory();
    }
}
