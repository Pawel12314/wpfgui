using NodaTime;
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
    /// Logika interakcji dla klasy UserControlSummary.xaml
    /// </summary>
    public partial class UserControlSummary : Page
    {
        public MyViewModel vm { get; set; }
        public ObservableCollection<Category> included { get; set; }
        public ObservableCollection<Category> excluded { get; set; }
        public UserControlSummary(MyViewModel vm)
        {
            this.vm = vm;
            included = new ObservableCollection<Category>();
            InitializeComponent();
        }
        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = vm;
            excluded = vm.categories;

            selectCategoriesIgnoreListBox.ItemsSource = excluded;
            selectCategoriesIncludeListBox.ItemsSource = included;
            selectCategoriesIgnoreListBox.Items.Refresh();
            selectCategoriesIncludeListBox.Items.Refresh();
            selectCategoriesGrid.IsEnabled = false;
            selectDatesGrid.IsEnabled = false;
            selectAmountGrid.IsEnabled = false;
            generateChartsGrid.IsEnabled = false;
        }

        private void selectCategoriesIncludeSelectedButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < selectCategoriesIgnoreListBox.SelectedItems.Count; i++)
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

        private void selectCategoriesIgnoreSelectedButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < selectCategoriesIncludeListBox.SelectedItems.Count; i++)
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

        private void selectCategoriesIncludeAllButton_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < selectCategoriesIgnoreListBox.Items.Count; i++)
            {
                Category k = (Category)selectCategoriesIgnoreListBox.Items[i];
                included.Add(k);
            }
            
            excluded.Clear();

            selectCategoriesIncludeListBox.Items.Refresh();
            selectCategoriesIgnoreListBox.Items.Refresh();
        }

        private void selectCategoriesIgnoreAllButton_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < selectCategoriesIncludeListBox.Items.Count; i++)
            {
                Category k = (Category)selectCategoriesIncludeListBox.Items[i];
                excluded.Add(k);
            }
            
            included.Clear();

            selectCategoriesIncludeListBox.Items.Refresh();
            selectCategoriesIgnoreListBox.Items.Refresh();
        }

        private void genereateSummary(object sender, RoutedEventArgs e)
        {

        }

        private void selectCategoriesCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(selectCategoriesCheckBox.IsChecked ?? false)
            {
                selectCategoriesGrid.IsEnabled = true;
            }
            else
            {
                selectCategoriesGrid.IsEnabled = false;
            }
        }

        private void selectDatesCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (selectDatesCheckBox.IsChecked ?? false)
            {
                selectDatesGrid.IsEnabled = true;

                if (selectDatesSinceCheckBox.IsChecked ?? false)
                {
                    selectDatesSinceDatePicker.IsEnabled = true;
                }
                else
                {
                    selectDatesSinceDatePicker.IsEnabled = false;
                }
                if(selectDatesUntilCheckBox.IsChecked ?? false)
                {
                    selectDatesUntilDatePicker.IsEnabled = true;
                }
                else
                {
                    selectDatesUntilDatePicker.IsEnabled = false;
                }
            }
            else
            {
                selectDatesGrid.IsEnabled = false;
            }
        }

        private void selectAmountCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (selectAmountCheckBox.IsChecked ?? false)
            {
                selectAmountGrid.IsEnabled = true;
                if (selectAmountFromCheckBox.IsChecked ?? false)
                {
                    selectAmountFromTextBox.IsEnabled = true;
                }
                else
                {
                    selectAmountFromTextBox.IsEnabled = false;
                }
                if (selectAmountUpToCheckBox.IsChecked ?? false)
                {
                    selectAmountUpToTextBox.IsEnabled = true;
                }
                else
                {
                    selectAmountUpToTextBox.IsEnabled = false;
                }
            }
            else
            {
                selectAmountGrid.IsEnabled = false;
            }
        }

        private void generateChartsCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (generateChartsCheckBox.IsChecked ?? false)
            {
                generateChartsGrid.IsEnabled = true;
            }
            else
            {
                generateChartsGrid.IsEnabled = false;
            }
        }

        private void selectAmountFromCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(selectAmountFromCheckBox.IsChecked ?? false)
            {
                selectAmountFromTextBox.IsEnabled = true;
            }
            else
            {
                selectAmountFromTextBox.IsEnabled = false;
            }
        }

        private void selectAmountUpToCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(selectAmountUpToCheckBox.IsChecked ?? false)
            {
                selectAmountUpToTextBox.IsEnabled = true;
            }
            else
            {
                selectAmountUpToTextBox.IsEnabled = false;
            }
        }

        private void selectDatesSinceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(selectDatesSinceCheckBox.IsChecked ?? false)
            {
                selectDatesSinceDatePicker.IsEnabled = true;
            }
            else
            {
                selectDatesSinceDatePicker.IsEnabled = false;
            }
        }

        private void selectDatesUntilCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (selectDatesUntilCheckBox.IsChecked ?? false)
            {
                selectDatesUntilDatePicker.IsEnabled = true;
            }
            else
            {
                selectDatesUntilDatePicker.IsEnabled = false;
            }
        }
    }
}