using Projekt_WPF.commands;
using Projekt_WPF.models;

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


        private ICommand addCMD { get; set; }
        private ICommand editCMD { get; set; }
        private ICommand deleteCMD { get; set; }
        private ICollectionView viewgroups { get; set; }
        private ICollectionView viewwishes { get; set; }

        private ICommand add { get; set; }
        public BudgetPage(MyViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
        }
        public void  openAddmenuWish()
        {
            var dialog = new addwishNewCategory(null);
            dialog.Show();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //definedWishesListBox.ItemsSource = vm.wishes;
            wishesgroupsListbox.ItemsSource = vm.wishgroups;

            wishesListbox.ItemsSource = vm.wishes;

            add = new CommandTemplate(o => addWishButton_Click(),o => true);
            menuButtons.AddProperty = add;
          

            App.Current.Dispatcher.Invoke((Action)delegate
            {
                viewgroups =
           CollectionViewSource.GetDefaultView(wishesgroupsListbox.ItemsSource);
                viewgroups.Filter = FilterDate;
                viewwishes = CollectionViewSource.GetDefaultView(wishesListbox.ItemsSource);
                viewwishes.Filter = FilterWishGroup;
            });

            addCMD = new CommandTemplate(o => openAddmenuWish(), o => true);
        }

        private void addWishButton_Click()
        {
            var aww = new AddWishWindow(vm);
            aww.Show();
        }
        public void addWish(Entry w)
        {
            vm.wishes.Add(w);
            refreshView();
            // wishesListbox.Items.Refresh();
            //definedWishesListBox.Items.Refresh();
            //wishesgroupsListbox.Items.Refresh();

        }
        public bool FilterWishGroup(Object item)
        {
            if(wishesgroupsListbox.SelectedItem==null)
            {
                return true;
            }
            
            Wish w = (Wish)item;
            if(w.groupID==((WishGroup)wishesgroupsListbox.SelectedItem).id)
            {
                return true;

            }
            return false;
        }
        private void refreshView()
        {
            if (this.viewgroups != null)
                viewgroups.Refresh();

            if (this.viewwishes != null)
                viewwishes.Refresh();


        }
        public bool FilterDate(Object item)
        {
            WishGroup e = (WishGroup)item;
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
            if (this.viewgroups != null)
                viewgroups.Refresh();
        }
       
        private void wishesgroupsListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewwishes.Refresh();
            //MessageBox.Show(((WishGroup)wishesgroupsListbox.SelectedItem).id.ToString()+" selected id");
        }
    }
}
