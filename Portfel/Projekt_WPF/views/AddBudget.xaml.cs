using NodaTime;
using Projekt_WPF.commands;
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
using System.Windows.Shapes;

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy AddBudget.xaml
    /// </summary>
    public partial class AddBudget : Window
    {

        private MyViewModel vm { get; set; }
        private bool isedit { get; set; }
        private int id { get; set; }
        public AddBudget(MyViewModel vm,Budget b=null)
        {
            this.vm = vm;
            InitializeComponent();
           
            //  beginDatePicker.SelectedDate
            if (b != null)
            {
                id = b.id;
                isedit = true;
                beginDatePicker.SelectedDate = new DateTime(b.date.Year, b.date.Month, b.date.Day);
                //startDatePicker.SelectedDate = new DateTime(editedEntry.begin.Year, editedEntry.begin.Month, editedEntry.begin.Day);
                amount.Text = b.amount.ToString();
            }
            else
            {
                isedit = false;
            }

        }
        private ICommand saveCMD { get; set; }
        private void filterletters(object sender, TextChangedEventArgs e)
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
        public void save()
        {

            decimal val = 0;
            Decimal.TryParse(amount.Text, out val);
            LocalDate date = new LocalDate(beginDatePicker.SelectedDate.Value.Year, beginDatePicker.SelectedDate.Value.Month, 1);
            if (vm.budget.Where(elem => elem.date.Year == date.Year & elem.date.Month == date.Month).Any())
            {
                Budget budget1 = new Budget(date, val);
                budget1.id = vm.budget.Where(elem => elem.date.Year == date.Year & elem.date.Month == date.Month).First().id;
                ((MainWindow)Application.Current.MainWindow).editBudget(budget1);
                Close();
                return;
            }

            Budget budget = new Budget(date,val);
           // budget.id = id;
            if (isedit == false)
                ((MainWindow)Application.Current.MainWindow).addBudget(budget);
            
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveCMD = new CommandTemplate(o => save(), o => true);
            menubuttons.saveProperty = saveCMD;
          
        }
    }
}
