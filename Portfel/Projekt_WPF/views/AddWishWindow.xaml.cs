﻿using NodaTime;
using Projekt_WPF.models;

using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy AddWishWindow.xaml
    /// </summary>
    public partial class AddWishWindow : Window
    {

        
        private MyViewModel viewModel { get; set; }
        private int id { get; set; }
        public AddWishWindow(MyViewModel vm,Wish w=null)
        {
            
            this.viewModel = vm;
            InitializeComponent();
            id = -1;
            if(w!=null)
            {
                nameTextBox.Text = w.name;
                durationTextBox.Text = w.duration.ToString();
                amountTextBox.Text = w.amount.ToString();
                categoryCombobox.SelectedItem = vm.categories.Where(item => item.id == w.categoryID).FirstOrDefault();
                wishCategoryCombobox.SelectedItem = vm.wishgroups.Where(item=>item.id==w.groupID).FirstOrDefault();
                beginDatePicker.SelectedDate = new DateTime(w.begin.Year, w.begin.Month, w.begin.Day);
                id = w.id;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            categoryCombobox.ItemsSource = viewModel.categories;
            wishCategoryCombobox.ItemsSource = viewModel.wishgroups;
        }

        

       

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Entry wish;
            //WishDate wishdate;
            LocalDate begin = new LocalDate();
            
            if(nameTextBox.Text=="")
            {
                MessageBox.Show("musisz podać nazwę");
                return;
            }
            String name = nameTextBox.Text;
            decimal amount;
            if (!Decimal.TryParse(amountTextBox.Text, out amount))
            {
                MessageBox.Show("musisz podać kwotę");
            }
            String description = DescriptionTextBox.Text;
            if(isPeriodDefined.IsChecked==false)
            {
                //wishdate = WishDate.notspecified;
            }
            else
            {
                try
                {
                    begin = new LocalDate(beginDatePicker.SelectedDate.Value.Year, beginDatePicker.SelectedDate.Value.Month, 1);
                }
                catch
                {
                    MessageBox.Show("nie podano daty początku");
                    return;
                }
                
               // wishdate = WishDate.specified;
            }
            //if()
            int duration=0;
            Frequency freq;
            if(PeriodRadioButton.IsChecked==true)
            {
                if (!int.TryParse(durationTextBox.Text, out duration))
                {
                    MessageBox.Show("nie podano okresu trwania");
                    return;
                }
                freq = Frequency.comiesieczny;
            }
            else
            {
                freq = Frequency.jednorazowy;
            }
          
            if(categoryCombobox.SelectedItem==null)
            {
                MessageBox.Show("nie wybrano kategorii");
                return;
            }
            Category category = (Category)categoryCombobox.SelectedItem;

            WishGroup group;// = new WishGroup();
            
            if(wishCategoryCombobox.SelectedItem==null)
            {
                    MessageBox.Show("nie wybrano grupy");
                    return;
            }
                 group = (WishGroup)wishCategoryCombobox.SelectedItem;
                    
            

            wish = new Wish(name, amount, ref category,ref group, Frequency.comiesieczny, begin, duration, description);
                       
            
            if(id!=-1)
            {
                wish.id = id;
                ((BudgetPage)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).editWish(wish);
                Close();
                return;
            }
            ((BudgetPage)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).addWish(wish);
            
            //((BudgetPage)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).addWish(wish);
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            amountTextBox.Text = "";
            nameTextBox.Text = "";
            DescriptionTextBox.Text = "";

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void onlynumbersTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string decimalnumbers = "0123456789";
            tb.Text = Regex.Replace(tb.Text, @"\s+", "");
            for (int i = 0; i < tb.Text.Trim().Length; i++)
            {
                if (decimalnumbers.IndexOf(tb.Text[i]) == -1)
                {
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.SelectionStart = tb.Text.Length;
                }
            }
            if (tb.Text.Length > 6)
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.SelectionStart = tb.Text.Length;
            }
        }
    }
}
