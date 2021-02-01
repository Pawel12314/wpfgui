using NodaTime;
using Projekt_WPF.commands;
using Projekt_WPF.models;
using Projekt_WPF.models.range;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logika interakcji dla klasy SummareCreatePage.xaml
    /// </summary>
    public partial class SummareCreatePage : Page
    {
        public CommandTemplate moveSelectedToExludedCMD { get; set; }
        public CommandTemplate moveSelectedToInludedCMD { get; set; }
        public CommandTemplate moveAllToIncludedCMD { get; set; }
        public CommandTemplate moveAllToExludedCMD { get; set; }
        public MyViewModel vm { get; set; }
        public ObservableCollection<Category> included { get; set; }
        public ObservableCollection<Category> excluded { get; set; }
        public SummareCreatePage(MyViewModel vm)
        {
            this.vm = vm;
            included = new ObservableCollection<Category>();
            InitializeComponent();
        }

        public bool CanMoveToIncluded()
        {
            if (excluded.Count == 0)
                return false;
            return true;
        }
        public bool CanMoveToExcluded()
        {
            if (included.Count == 0)
                return false;
            return true;
        }
        public void moveAllToIncluded()
        {
            List<Category> temp = new List<Category>(excluded);
            foreach(Category c in excluded)
            {
                try
                {
                    Category Ctmp = temp.Where(item => item.id == c.id).First();
                    included.Add(Ctmp);
                }
                catch
                {

                }
            }
            excluded.Clear();
            temp.Clear();

        }
       
        public void moveAllToExcluded()
        {
            
            List<Category> temp = new List<Category>(included);
            foreach (Category c in included)
            {
                try
                {
                    Category Ctmp = temp.Where(item => item.id == c.id).First();
                    excluded.Add(Ctmp);
                }
                catch 
                {

                }
            }
            included.Clear();
            temp.Clear();

        }
        public void moveSelectedToIncluded()
        {
            for (int i = selectCategoriesIgnoreListBox.SelectedItems.Count - 1; i >= 0; --i)
            {
                Category k = (Category)selectCategoriesIgnoreListBox.SelectedItems[i];
                included.Add(k);

            }

            for (int i = selectCategoriesIgnoreListBox.SelectedItems.Count - 1; i >= 0; --i)
            {
                Category k = (Category)selectCategoriesIgnoreListBox.SelectedItems[i];
                excluded.Remove(k);

            }
            selectCategoriesIncludeListBox.Items.Refresh();
            selectCategoriesIgnoreListBox.Items.Refresh();


        }

        public void moveSelectedToExcluded()
        {
            for (int i = selectCategoriesIncludeListBox.SelectedItems.Count - 1; i >= 0; --i)
            {
                Category k = (Category)selectCategoriesIncludeListBox.SelectedItems[i];
                excluded.Add(k);

            }
            for (int i = selectCategoriesIncludeListBox.SelectedItems.Count - 1; i >= 0; --i)
            {
                Category k = (Category)selectCategoriesIncludeListBox.SelectedItems[i];
                included.Remove(k);

            }


            selectCategoriesIncludeListBox.Items.Refresh();
            selectCategoriesIgnoreListBox.Items.Refresh();
        }
        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = vm;
            excluded = vm.categories;

            selectCategoriesIgnoreListBox.ItemsSource = excluded;
            selectCategoriesIncludeListBox.ItemsSource = included;
            //selectCategoriesIgnoreListBox.Items.Refresh();
            // selectCategoriesIncludeListBox.Items.Refresh();
            // selectDatesSinceDatePicker.DisplayMode = CalendarMode.Year;
            // selectDatesUntilDatePicker.DisplayMode = CalendarMode.Year;
            selectDatesSinceDatePicker.SelectionMode = CalendarSelectionMode.SingleRange;
                //calendar.DisplayMode = CalendarMode.Year;
            //DateTimerPicker.CustomFormat = "MM/yyyy";
            // selectDatesSinceDatePicker.Se
            // = DateTimePickerFormat.Custom;
            // DateTimePicker1.CustomFormat = "MMMM"

            moveAllToExludedCMD = new CommandTemplate(
                o=>moveAllToExcluded(),
                o=>CanMoveToExcluded()
                );
            KeyBinding keymvToex = new KeyBinding
            {
                Command = moveAllToExludedCMD,
                Key = Key.Left,
                Modifiers = ModifierKeys.Control
            };
            
            this.InputBindings.Add(keymvToex);
            moveAllToIncludedCMD = new CommandTemplate(
                o => moveAllToIncluded(),
                o=>CanMoveToIncluded()
                );
            KeyBinding keymvtoIn = new KeyBinding
            {
                Command = moveAllToIncludedCMD,
                Key = Key.Right,
                Modifiers = ModifierKeys.Control
            };
            this.InputBindings.Add(keymvtoIn);
            moveSelectedToExludedCMD = new CommandTemplate(
            o => moveSelectedToExcluded(),
            o => selectCategoriesIncludeListBox.SelectedItems.Count > 0
            );
            KeyBinding keymvSelToex = new KeyBinding
            {
                Command = moveSelectedToExludedCMD,
                Key = Key.Left,
                Modifiers = ModifierKeys.Shift
            };
            this.selectCategoriesIncludeListBox.InputBindings.Add(keymvSelToex);
            moveSelectedToInludedCMD = new CommandTemplate(
                o => moveSelectedToIncluded(),
                o => selectCategoriesIgnoreListBox.SelectedItems.Count > 0
                );
            KeyBinding keymvSelToin = new KeyBinding
            {
                Command = moveSelectedToInludedCMD,
                Key = Key.Right,
                Modifiers = ModifierKeys.Shift
            };
            this.selectCategoriesIgnoreListBox.InputBindings.Add(keymvSelToin);


        }

        private void selectCategoriesIncludeSelectedButton_Click(object sender, RoutedEventArgs e)
        {

            moveSelectedToInludedCMD.Execute(1);


        }

        private void selectCategoriesIgnoreSelectedButton_Click(object sender, RoutedEventArgs e)
        {

            moveSelectedToExludedCMD.Execute(1);
        }

        private void genereateSummary(object sender, RoutedEventArgs e)
        {
            LocalDate begin;
            LocalDate end;
           
            Instant now = SystemClock.Instance.GetCurrentInstant();

            // get a time zone
            DateTimeZone tz = DateTimeZoneProviders.Tzdb["Asia/Tokyo"];

            // use now and tz to get "today"
            //LocalDate today = now.InZone(tz).Date;
            end = now.InZone(tz).Date;
            begin = end.PlusMonths(-3);

            MessageBox.Show("sending data");
            List<SummaryType> summaries = new List<SummaryType>();
            if (generateChartsIncomeCheckBox.IsChecked == true)
            {
                summaries.Add(SummaryType.INCOME_PIE);
            }
            if (generateChartsExpensesCheckBox.IsChecked == true)
            {
                summaries.Add(SummaryType.OUTCOME_PIE);
            }
            if (generateChartsCompareWithoutCategoriesRadioButton.IsChecked == true)
            {
                summaries.Add(SummaryType.COMAPRISON);
            }
            if (generateChartsCompareWithCategoriesRadioButton.IsChecked == true)
            {
                summaries.Add(SummaryType.COMPARISON_CATEGORY);
            }

            int min = -1;
            Value minv;
            Value maxv;
            if (selectAmountFromTextBox.Text != "")
            {
                int.TryParse(selectAmountFromTextBox.Text, out min);
                minv = new implementedValue(min);
            }else
            {
                minv = new UnimplementedValue(); 
            }
            
            int max = -1;
            if (selectAmountUpToTextBox.Text != "")
            {
                int.TryParse(selectAmountUpToTextBox.Text, out max);
                maxv= new implementedValue(max);
            }
            else
            {
                maxv = new UnimplementedValue();
            }
            Range priceRange;
            MessageBox.Show(min.ToString() + " " + max.ToString() + " ZAKRES");
            priceRange = new Range(minv, maxv);



            ((MainWindow)Application.Current.MainWindow).newSummary(included, begin, end, summaries, priceRange);
        }

        private void onlymonthandyearAvalilable(object sender, CalendarModeChangedEventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            if (calendar.DisplayMode == CalendarMode.Month)
            {
                calendar.DisplayMode = CalendarMode.Year;
            }

           //var datePicker = (DatePicker)sender;
        }
    }
}
