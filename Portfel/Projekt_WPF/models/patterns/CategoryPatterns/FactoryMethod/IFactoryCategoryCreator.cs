using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns.FactoryMethod
{
    public abstract class IFactoryCategoryCreator
    {

        public abstract Category createCategory(ICategoryCreator cateogory);

        public abstract void addCategory(MainWindow main,Category cat);
    }
}
