using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_WPF.models.patterns.CategoryPatterns.FactoryMethod
{
    public class FactoryWishGroupCreator : IFactoryCategoryCreator
    {
        public override void addCategory(MainWindow main,Category cat)
        {
            main.addWishGroup((WishGroup)cat);
        }

        public override Category createCategory(ICategoryCreator cateogory)
        {
            return new WishGroup(cateogory.getName(), cateogory.getBegin(), cateogory.getDuration());
        }
    }
}
