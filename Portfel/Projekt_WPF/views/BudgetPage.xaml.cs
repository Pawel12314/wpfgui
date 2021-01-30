using Projekt_WPF.commands;
using Projekt_WPF.models;
using Projekt_WPF.models.patterns.factoryMethodEntry;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private ICollectionView view { get; set; }

        private ICommand add { get; set; }
        public BudgetPage(MyViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //definedWishesListBox.ItemsSource = vm.wishes;
            wishesListbox.ItemsSource = vm.wishes;
            add = new CommandTemplate(o => addWishButton_Click(),o => true);
            menuButtons.AddProperty = add;
            view =
            CollectionViewSource.GetDefaultView(wishesListbox.ItemsSource);
            view.Filter = FilterDate;
        }

        private void addWishButton_Click()
        {
            var aww = new AddWishWindow(vm,new WishFactory());
            aww.Show();
        }
        public void addWish(Entry w)
        {
            vm.wishes.Add(w);
            //definedWishesListBox.Items.Refresh();
            wishesListbox.Items.Refresh();
        }

        public bool FilterDate(Object item)
        {
            Entry e = (Entry)item;
            int month;
            if(int.TryParse(monthTextBox.Text,out month))
            {
                if(e.begin.Month>month || e.end.Month<month)
                {
                    return false;
                }
            }
            int year;
            if(int.TryParse(yearTextBox.Text,out year))
            {
                if(e.begin.Year>year||e.end.Year<year)
                {
                    return false;
                }
            }
            return true;
           // if(datePicker.)
           //return true;
        }

        private void filternumbers(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string decimalnumbers = ".0123456789";
            tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, @"\s+", "");
            for (int i = 0; i < tb.Text.Trim().Length; i++)
            {
                if (decimalnumbers.IndexOf(tb.Text[i]) == -1)
                {
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.SelectionStart = tb.Text.Length;
                }
            }
            if(tb.Text.Length>0)
            if (tb.Text[tb.Text.Length - 1] == '.')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.SelectionStart = tb.Text.Length;
            }
            if (this.view != null)
                view.Refresh();
        }
    }
}
