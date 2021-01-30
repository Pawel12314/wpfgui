using NodaTime;
using Projekt_WPF.commands;
using Projekt_WPF.models;
using Projekt_WPF.models.patterns.CategoryPatterns;
using Projekt_WPF.models.patterns.CategoryPatterns.FactoryMethod;
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
using System.Windows.Shapes;

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy addNewCategory.xaml
    /// </summary>
    public partial class addNewCategory : Window
    {


        public ICommand saveCMD { get; set; }
        private IFactoryCategoryCreator factory { get; set; }
       
        public addNewCategory( IFactoryCategoryCreator factorymethod)
        {
            InitializeComponent();

            this.factory = factorymethod;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(factory is FactoryWishGroupCreator)
            {
                wishGroupOptions.Visibility = Visibility.Visible;
            }
            else
            {
                wishGroupOptions.Visibility = Visibility.Collapsed;
            }
            saveCMD = new CommandTemplate(o => addCategory(), o => true);
            menuButtonsCreation.saveProperty = saveCMD;
        }
        public void addCategory()
        {
            
            if(nameTextBox.Text=="")
            {
                MessageBox.Show("nie podano nazwy");
            }
            String name = nameTextBox.Text;
            ICategoryCreator basecreator =new CategoryDecoratorCreator(name, new CategoryItemCreator());
            ICategoryCreator cateogry = basecreator;

           
            if (factory is FactoryWishGroupCreator)
            {
                if(!beginDatePicker.SelectedDate.HasValue)
                {
                    MessageBox.Show("nie podano daty początku");
                    return;
                }
                LocalDate date = new LocalDate(beginDatePicker.SelectedDate.Value.Year, beginDatePicker.SelectedDate.Value.Month, 1);
                int duration = 0;
                if (!int.TryParse(durationTextBox.Text, out duration))
                {
                    MessageBox.Show("musisz podać czas trwania");
                    return;
                }

                cateogry = new WishDecoratorCreator(duration, date, cateogry);

            }
            Category result = factory.createCategory(cateogry);

            factory.addCategory((MainWindow)Application.Current.MainWindow,result);
                
                 
            
            
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
