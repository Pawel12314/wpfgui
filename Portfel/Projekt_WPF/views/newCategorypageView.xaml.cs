using Projekt_WPF.commands;
using Projekt_WPF.models.patterns.CategoryPatterns.categoryPage;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy newCategorypageView.xaml
    /// </summary>
    public partial class newCategorypageView : Page
    {
        private IfactoryCategoryPage factory { get; set; }
        private MyViewModel vm { get; set; }

        private ICommand addCMD { get; set; }
        public newCategorypageView(MyViewModel vm,IfactoryCategoryPage factory)
        {
            InitializeComponent();
            this.vm = vm;
            this.factory = factory;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            categoryListBox.ItemsSource = factory.getList(vm);
            addCMD = new CommandTemplate(o => factory.getAddPage().Show(), o => true);
            menubuttons.AddProperty = addCMD;
        }
    }
}
