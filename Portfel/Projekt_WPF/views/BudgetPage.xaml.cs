using Projekt_WPF.models;
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
    /// Logika interakcji dla klasy BudgetPage.xaml
    /// </summary>
    public partial class BudgetPage : Page
    {
        private MyViewModel vm { get; set; }
        public BudgetPage(MyViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            definedWishesListBox.ItemsSource = vm.wishes;
        }

        private void addWishButton_Click(object sender, RoutedEventArgs e)
        {
            var aww = new AddWishWindow(vm);
            aww.Show();
        }
        public void addWish(Wish w)
        {
            vm.wishes.Add(w);
            definedWishesListBox.Items.Refresh();
        }
    }
}
