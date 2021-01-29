using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.Decorator
{
    public class CategoryEmptyDecorated : ICategoryBase
    {

        public CategoryEmptyDecorated()
        {

        }
        public override Category getCategory()
        {
            throw new NotImplementedException();
        }

        public override Category getWishCategory()
        {
            throw new NotImplementedException();
        }
    }
}
