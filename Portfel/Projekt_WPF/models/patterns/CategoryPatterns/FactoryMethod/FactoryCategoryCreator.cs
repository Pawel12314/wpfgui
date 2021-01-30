using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns.FactoryMethod
{
    public class FactoryCategoryCreator : IFactoryCategoryCreator
    {
        public override void addCategory(MainWindow main, Category cat)
        {
            main.addCategory(cat);
        }

        public override Category createCategory(ICategoryCreator cateogory)
        {
            return new Category(cateogory.getName());
        }
    }
}
