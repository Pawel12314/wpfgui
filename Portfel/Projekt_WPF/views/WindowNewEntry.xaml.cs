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
    /// Logika interakcji dla klasy WindowNewEntry.xaml
    /// </summary>
    public partial class WindowNewEntry : Window
    {

        public CommandTemplate cancelCMD { get; set; }
        public CommandTemplate applyCMD { get; set; }
        private MyViewModel vm { get; set; }
        public WindowNewEntry(MyViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
            this.Background = globalSettings.GlobalSettings.WindowScreenColor;
        }

       

        private void additionalInfoCheckBoxChanged(object sender, RoutedEventArgs e)
        {
            if(additionalInfoCheckBox.IsChecked ?? false)
            {
                additionalInfoTextBox.IsEnabled = true;
            }
            else
            {
                additionalInfoTextBox.IsEnabled = false;
                additionalInfoTextBox.Text = "";
            }
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            applyCMD.Execute(1);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            cancelCMD.Execute(1);
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            startDatePicker.SelectedDate = DateTime.Today;
            endDateRBsStackPanel.Visibility = Visibility.Collapsed;
           // vm = new MyViewModel();
            this.DataContext = vm;
            categoryComboBox.ItemsSource = vm.categories;

            cancelCMD = new CommandTemplate(
              o => Cancel(),
              o => true
              );
            KeyBinding cancelKB = new KeyBinding
            {
                Key = Key.Q,
                Command = cancelCMD,
                Modifiers = ModifierKeys.Control
            };
            this.InputBindings.Add(cancelKB);


            applyCMD = new CommandTemplate(
                o => Apply(),
                o => true
                );
            KeyBinding applyKB = new KeyBinding
            {
                Key = Key.S,
                Command = applyCMD,
                Modifiers = ModifierKeys.Control
            };
            this.InputBindings.Add(applyKB);
        }

        private void Apply()
        {
            string name = nameTextBox.Text;
            string amountString = amountTextBox.Text;
            Category sCategory = (Category)categoryComboBox.SelectedItem;
            LocalDate beginDate = new LocalDate(startDatePicker.SelectedDate.Value.Year, startDatePicker.SelectedDate.Value.Month, startDatePicker.SelectedDate.Value.Day);
            LocalDate endDate;
            Frequency freq;
            string lengthString;
            string desc = additionalInfoTextBox.Text;
            Entry wpis;

            if (desc.Length > 200)
            {
                MessageBox.Show("Maksymalna długość opisu to 200 znaków!");
                return;
            }

            if (((UserControlEntries)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).doesEntryWithNameAndDateExist(name, beginDate))
            {
                MessageBox.Show(String.Format("Wpis o nazwie '{0}' z datą '{1}' już istnieje!",name,beginDate));
            }
            else if (name.Trim().Length < 1)
            {
                MessageBox.Show("Musisz podać nazwę wpisu!");
            }
            else if (name.Length > 35)
            {
                MessageBox.Show("Maksymalna długość nazwy wpisu to 35 znaków!");
            }
            else if (amountString.Trim('.').Length < 1)
            {
                MessageBox.Show("Musisz podać kwotę wpisu!");
            }
            else if (categoryComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Musisz wybrać kategorię wpisu!");
            }
            else if (oneTimeRadioButton.IsChecked == true)
            {
                freq = Frequency.jednorazowy;
                if (incomeRadioButton.IsChecked == true)
                {
                    wpis = new Income(name, Convert.ToDecimal(amountString), sCategory, freq, beginDate, 0, desc);
                }
                else
                {
                    wpis = new Outcome(name, Convert.ToDecimal(amountString), sCategory, freq, beginDate, 0, desc);
                }
                ((UserControlEntries)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).dodajWpis(wpis);
                this.Close();
            }
            else if(monthlyRadioButton.IsChecked == true)
            {
                freq = Frequency.comiesieczny;
                if(endDateWriteRB.IsChecked == true)
                {
                    lengthString = endDateWriteTextBox.Text;
                    if (lengthString.Trim().Length < 1)
                    {
                        MessageBox.Show("Musisz podać przez ile miesięcy ma występować dany wpis");
                    }
                    else if(lengthString=="1" || lengthString.Trim('0').Length==0)
                    {
                        MessageBox.Show("Jeżeli chcesz aby wpis wystąpił tylko raz, wybierz opcję 'jednorazowy'.\nOpcja 'comiesięszny' służy do oznaczenia wpisów, które wystąpią przynajmniej dwa razy");
                    }
                    else
                    {
                        /*
                        DateTime tempDate = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day);
                        tempDate.AddMonths(Convert.ToInt32(lengthString));
                        endDate = new LocalDate(tempDate.Year, tempDate.Month, tempDate.Day);
                        */

                        if (incomeRadioButton.IsChecked == true)
                        {
                            wpis = new Income(name, Convert.ToDecimal(amountString), sCategory, freq, beginDate, Convert.ToInt32(lengthString),desc);
                        }
                        else
                        {
                            wpis = new Outcome(name, Convert.ToDecimal(amountString), sCategory, freq, beginDate, Convert.ToInt32(lengthString),desc);
                        }
                        ((UserControlEntries)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).dodajWpis(wpis);
                        this.Close();
                    }
                }
                else if(endDatePickRB.IsChecked==true)
                {
                    int lengthInMonths = (endDatePicker.SelectedDate.Value.Year - beginDate.Year) * 12 + (endDatePicker.SelectedDate.Value.Month - beginDate.Month);
                    if (lengthInMonths < 1)
                    {
                        MessageBox.Show("Ostatni miesiąc wystąpienia wpisu występuje przed pierwszym wpisem!");
                    }
                    else if (endDatePicker.SelectedDate.Value.Month == beginDate.Month)
                    {
                        MessageBox.Show("Jeżeli chcesz aby wpis wystąpił tylko raz, wybierz opcję 'jednorazowy'.\nOpcja 'comiesięszny' służy do oznaczenia wpisów, które wystąpią przynajmniej dwa razy");
                    }
                    else
                    {
                        if (incomeRadioButton.IsChecked == true)
                        {
                            wpis = new Income(name, Convert.ToDecimal(amountString), sCategory, freq, beginDate, lengthInMonths,desc);
                        }
                        else
                        {
                            wpis = new Outcome(name, Convert.ToDecimal(amountString), sCategory, freq, beginDate, lengthInMonths,desc);
                        }
                        ((UserControlEntries)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).dodajWpis(wpis);
                        this.Close();
                    }
                }
            }
        }

        private void Cancel()
        {
            this.Close();
        }

        private void filterLetters(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string decimalnumbers = ".0123456789";
            tb.Text = Regex.Replace(tb.Text, @"\s+", "");
            for (int i = 0; i < tb.Text.Trim().Length; i++)
            {
                if (decimalnumbers.IndexOf(tb.Text[i]) == -1)
                {
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.SelectionStart = tb.Text.Length;
                }
            }
            int firstDotIndex = -1;
            int dots = 0;
            for(int i=0; i<tb.Text.Length; i++)
            {
                if (tb.Text[i] == '.')
                {
                    dots++;
                    if (firstDotIndex == -1)
                        firstDotIndex = i;
                }
                if (dots > 1)
                {
                    tb.Text = tb.Text.Remove(i);
                    tb.SelectionStart = tb.Text.Length;
                }
            }
            if (dots > 0 && tb.Text.Length > firstDotIndex + 3)
            {
                tb.Text = tb.Text.Remove(firstDotIndex + 3);
                tb.SelectionStart = tb.Text.Length;
            }
        }
        private void filterNumbersOnly(object sender, TextChangedEventArgs e)
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

        private void endDateRBs_Clicked(object sender, RoutedEventArgs e)
        {
            if(endDatePickRB.IsChecked == true)
            {
                endDatePicker.IsEnabled = true;
                endDateWriteTextBox.IsEnabled = false;
                endDatePicker.SelectedDate = startDatePicker.SelectedDate.Value;
                endDatePicker.SelectedDate = endDatePicker.SelectedDate.Value.AddMonths(1);
            }
            else
            {
                endDatePicker.IsEnabled = false;
                endDateWriteTextBox.IsEnabled = true;
            }
        }

        private void entryFrequencyRBs_Click(object sender, RoutedEventArgs e)
        {
            if (monthlyRadioButton.IsChecked == true)
            {
                endDateRBsStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                endDateRBsStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(monthlyRadioButton.IsChecked == true && endDatePickRB.IsChecked == true)
            {
                endDatePicker.SelectedDate = startDatePicker.SelectedDate.Value;
                endDatePicker.SelectedDate = endDatePicker.SelectedDate.Value.AddMonths(1);
            }
        }



        /*
        <StackPanel Grid.Row="3" Grid.Column="2" Grid.ColumnSpan="3" Orientation="Horizontal">
            <Label x:Name="endDateLabel" Content="Do:" Margin="5"  Visibility="{Binding ElementName=monthlyRadioButton, Path=IsChecked, Converter={StaticResource BoolToVis}}"/>
            <TextBox Name="okresTB" MinWidth="100" Visibility="{Binding ElementName=monthlyRadioButton, Path=IsChecked, Converter={StaticResource BoolToVis}}" TextChanged="filterLetters"></TextBox>
        </StackPanel>
         */
    }
}
