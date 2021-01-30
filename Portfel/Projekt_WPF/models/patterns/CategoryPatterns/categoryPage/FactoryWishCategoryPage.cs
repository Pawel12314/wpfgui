using Projekt_WPF.models.patterns.CategoryPatterns.FactoryMethod;
using Projekt_WPF.ViewModel;
using Projekt_WPF.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projekt_WPF.models.patterns.CategoryPatterns.categoryPage
{
    class FactoryWishCategoryPage : IfactoryCategoryPage
    {
        public override Window getAddPage()
        {
            return new addNewCategory(new FactoryWishGroupCreator());
        }

        public override ObservableCollection<Category> getList(MyViewModel vm)
        {
            return vm.wishgroups;
        }
    }
}
