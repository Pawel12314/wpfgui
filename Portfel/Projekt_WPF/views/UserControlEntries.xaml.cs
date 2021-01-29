using NodaTime;
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
    /// Logika interakcji dla klasy UserControlEntries.xaml
    /// </summary>
    public partial class UserControlEntries : Page
    {
        MyViewModel vm;
        public CommandTemplate newEntryCMD { get; set; }
        public CommandTemplate editEntryCMD { get; set; }
        public CommandTemplate deleteEntryCMD { get; set; }
        ICollectionView view { get; set; } 
        private string[] sortingOptions = new string[]
        {"Data wpisu (od najnowszych)", "Data wpisu (od najstarszych)", "Nazwa wpisu", "Nazwa wpisu (odwrotnie)",
            "Kwota rosnąco", "Kwota malejąco", "Kategoriami", "Kategoriami (odwrotnie)",
            "Trwające najdłużej", "Trwające najkrócej"};

        public UserControlEntries(MyViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
            
        }
        public void newEntryCmd()
        {
            //var temp = new WindowNewEntry(vm);
            var temp = new AddWishWindow(vm, new IncomeFactory());
            temp.ShowDialog();
        }
        public void editEntryCmd()
        {
            var temp = new WindowEditEntry(vm,(Entry)entriesListBox.SelectedItem);
            temp.ShowDialog();
        }
        public void deleteEntryCmd()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wpis wybrany wpis?", "Usuwanie wpisu", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Entry tmp = (Entry)entriesListBox.SelectedItem;
                usunWpis(tmp);
            }
        }

        private bool isSelected()
        {
            if (entriesListBox.SelectedItem != null)
            {
                return true;
            }
            return false;
        }
        private void addNewEntryButton_Click(object sender, RoutedEventArgs e)
        {
            var temp = new AddWishWindow(vm, new IncomeFactory());
            temp.Show();
        }
        public void dodajWpis(Entry wpis)
        {
            vm.entries.Add(wpis);
            //vm.addEntry(wpis);
            //Entry.saveInFile("wpisy.json", new List<Entry>(vm.entries));
            //incomeListBox.Items.Refresh();
        }
        public void edytujWpis(Entry edytowanyWpis, Entry nowyWpis)
        {
            vm.entries.Insert(vm.entries.IndexOf(edytowanyWpis), nowyWpis);
            vm.entries.Remove(edytowanyWpis);
            //Entry.saveInFile("wpisy.json", new List<Entry>(vm.entries));
        }
        public void usunWpis(Entry wpis)
        {
            vm.entries.Remove(wpis);
            //Entry.saveInFile("wpisy.json", new List<Entry>(vm.entries));
        }
        public bool doesEntryWithNameAndDateExist(string name, LocalDate date)
        {
            for(int i = 0; i < vm.entries.Count; i++)
            {
                if (vm.entries[i].begin.Day == date.Day && vm.entries[i].begin.Month == date.Month && vm.entries[i].begin.Year == date.Year && vm.entries[i].name == name)
                    return true;
            }
            return false;
        }
        public Entry getEntryWithNameAndDate(string name, LocalDate date)
        {
            for (int i = 0; i < vm.entries.Count; i++)
                if (vm.entries[i].begin.Day == date.Day && vm.entries[i].begin.Month == date.Month && vm.entries[i].begin.Year == date.Year && vm.entries[i].name == name)
                    return vm.entries[i];
            return null;
        }

        private void showCategoryCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(showCategoryCheckBox.IsChecked ?? false)
                showCategoryComboBox.IsEnabled = true;
            else
                showCategoryComboBox.IsEnabled = false;

            refreshView();
        }

        private void showMinAmountCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (showMinAmountCheckBox.IsChecked ?? false)
                showMinAmountTextBox.IsEnabled = true;
            else
                showMinAmountTextBox.IsEnabled = false;

            refreshView();
        }

        private void showMaxAmountCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (showMaxAmountCheckBox.IsChecked == true)
                showMaxAmountTextBox.IsEnabled = true;
            else
                showMaxAmountTextBox.IsEnabled = false;

            refreshView();
        }

        private void showFilterNameCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (showFilterNameCheckBox.IsChecked == true)
                showFilterNameTextBox.IsEnabled = true;
            else
                showFilterNameTextBox.IsEnabled = false;

            refreshView();
        }

        private void entriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (entriesListBox.SelectedIndex >= 0)
            {
                editSelectedEntryButton.IsEnabled = true;
                deleteSelectedEntryButton.IsEnabled = true;
            }
            else
            {
                editSelectedEntryButton.IsEnabled = false;
                deleteSelectedEntryButton.IsEnabled = false;
            }
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            // vm = new MyViewModel();
            this.DataContext = vm;
           
            decimal minimumPrice;
            if (showOnlyCheckBox.IsChecked == true)
                showOnlyGrid.Visibility = Visibility.Visible;
            else
                showOnlyGrid.Visibility = Visibility.Collapsed;

            showCategoryComboBox.ItemsSource = vm.categories;
            entriesListBox.ItemsSource = vm.entries;
            //entriesDataGrid.ItemsSource = vm.entries;
            sortByComboBox.ItemsSource = sortingOptions;
            view = CollectionViewSource.GetDefaultView(entriesListBox.ItemsSource);
            view.Filter = delegate (object item)
            {
                Entry wpis = item as Entry;
                if (wpis == null)
                {
                    return false;
                }
                if (showOnlyCheckBox.IsChecked == false)
                    return true;

                if (showCategoryCheckBox.IsChecked==true && showCategoryComboBox.SelectedItem != null)
                    if (wpis.category.id != ((Category)showCategoryComboBox.SelectedItem).id)
                        return false;

                decimal limit;

                if (showMinAmountCheckBox.IsChecked==true && Decimal.TryParse(showMinAmountTextBox.Text, out limit))
                    if (limit > wpis.amount)
                        return false;

                if (showMaxAmountCheckBox.IsChecked==true && Decimal.TryParse(showMaxAmountTextBox.Text, out limit))
                    if (limit < wpis.amount)
                        return false;

                if (showOneTimeCheckBox.IsChecked == false && wpis.frequency==Frequency.jednorazowy)
                    return false;

                if (showMonthlyCheckBox.IsChecked == false && wpis.frequency == Frequency.comiesieczny)
                    return false;

                if (showFilterNameCheckBox.IsChecked==true && !wpis.name.Contains(showFilterNameTextBox.Text))
                    return false;


                DateTime beginDate = new DateTime(wpis.begin.Year, wpis.begin.Month, wpis.begin.Day);
                DateTime endDate = new DateTime(wpis.end.Year, wpis.end.Month, wpis.end.Day);
                if (showDatesSinceCheckBox.IsChecked == true && showDatesSinceDatePicker.SelectedDate.HasValue && endDate<showDatesSinceDatePicker.SelectedDate.Value)
                    return false;


                if (showDatesUntilCheckBox.IsChecked == true && showDatesUntilDatePicker.SelectedDate.HasValue && beginDate>showDatesUntilDatePicker.SelectedDate.Value)
                    return false;

                return true;
            };
            newEntryCMD = new CommandTemplate(o => newEntryCmd(), o => true);
            KeyBinding keyBindingnew = new KeyBinding
            {
                Command = newEntryCMD,
                Key = Key.N,
                Modifiers = ModifierKeys.Control

            };
            this.InputBindings.Add(keyBindingnew);


            editEntryCMD = new CommandTemplate(o => editEntryCmd(), o =>

                isSelected()

            );
            KeyBinding keyBindingedit = new KeyBinding
            {
                Command = editEntryCMD,
                Key = Key.E,
                Modifiers = ModifierKeys.Control

            };
            this.InputBindings.Add(keyBindingedit);

            deleteEntryCMD = new CommandTemplate(o => deleteEntryCmd(), o => isSelected());
            KeyBinding keyBindingdelete = new KeyBinding
            {
                Command = deleteEntryCMD,
                Key = Key.X,
                Modifiers = ModifierKeys.Control
            };
            this.InputBindings.Add(keyBindingdelete);

        }
        private void refreshView()
        {
            if (this.view != null)
                view.Refresh();
        }
        private void showMinAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterLetters(sender, e);
            refreshView();
        }

        private void showOneTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            refreshView();
        }

        private void filterLetters(object sender, TextChangedEventArgs e)
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
            int firstDotIndex = -1;
            int dots = 0;
            for (int i = 0; i < tb.Text.Length; i++)
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

        private void showMonthlyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            refreshView();
        }

        private void showMaxAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterLetters(sender, e);
            refreshView();
        }

        private void showFilterNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshView();
        }

        private void showCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshView();
        }

        private void showOnlyCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if(showOnlyCheckBox.IsChecked == true)
                showOnlyGrid.Visibility = Visibility.Visible;
            else
                showOnlyGrid.Visibility = Visibility.Collapsed;

            refreshView();
        }

        private void showDatesSinceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(showDatesSinceCheckBox.IsChecked == true)
                showDatesSinceDatePicker.IsEnabled = true;
            else
                showDatesSinceDatePicker.IsEnabled = false;

            refreshView();
        }

        private void showDatesUntilCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (showDatesUntilCheckBox.IsChecked == true)
                showDatesUntilDatePicker.IsEnabled = true;
            else
                showDatesUntilDatePicker.IsEnabled = false;

            refreshView();
        }

        private void editSelectedEntryButton_Click(object sender, RoutedEventArgs e)
        {
            editEntryCMD.Execute(1);
        }

        private void deleteSelectedEntryButton_Click(object sender, RoutedEventArgs e)
        {
            deleteEntryCMD.Execute(1);
        }

        private void sortByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (entriesListBox.Items.SortDescriptions.Count == 1)
                entriesListBox.Items.SortDescriptions.RemoveAt(0);

            switch (sortByComboBox.SelectedIndex)
            {
                case 0:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("begin", ListSortDirection.Descending));
                    break;
                case 1:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("begin", ListSortDirection.Ascending));
                    break;
                case 2:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));
                    break;
                case 3:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Descending));
                    break;
                case 4:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("amount", ListSortDirection.Ascending));
                    break;
                case 5:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("amount", ListSortDirection.Descending));
                    break;
                case 6:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("category.name", ListSortDirection.Ascending));
                    break;
                case 7:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("category.name", ListSortDirection.Descending));
                    break;
                case 8:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("duration", ListSortDirection.Descending));
                    break;
                case 9:
                    entriesListBox.Items.SortDescriptions.Add(new SortDescription("duration", ListSortDirection.Ascending));
                    break;
                    //"Data wpisu (od najnowszych)", "Data wpisu (od najstarszych)", "Nazwa wpisu", "Nazwa wpisu (odwrotnie)", "Kwota rosnąco", "Kwota malejąco", "Kategoriami", "Kategoriami (odwrotnie)" 
            }
            entriesListBox.Items.Refresh();
        }


        private void showDatesUntilDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime t = showDatesUntilDatePicker.SelectedDate.Value;
            showDatesUntilDatePicker.SelectedDate = new DateTime(t.Year, t.Month, DateTime.DaysInMonth(t.Year, t.Month));
            refreshView();
        }

        private void showDatesSinceDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshView();
        }
    }
}