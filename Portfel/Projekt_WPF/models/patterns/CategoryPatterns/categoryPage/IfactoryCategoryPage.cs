using Projekt_WPF.ViewModel;
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
    public abstract class IfactoryCategoryPage
    {
        public abstract ObservableCollection<Category> getList(MyViewModel vm);
        public abstract Window getAddPage();
            
        
    }
}
