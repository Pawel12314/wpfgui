using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekt_WPF.ViewModel;
using Projekt_WPF.views;
using Projekt_WPF.models;
using System.Collections.ObjectModel;
using NodaTime;
using Projekt_WPF.models.range;
using Projekt_WPF.commands;
using Projekt_WPF.models.patterns.CategoryPatterns.categoryPage;

namespace Projekt_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static views.UserControlStartScreen userControlStartScreen;
        public static views.UserControlEntries userControlEntries;
        public static views.UserControlCategories userControlCategories;
        public static views.UserControlSummary userControlSummary;

        public static views.UserControlPersonalize userControlPersonalization;
        public static views.SummaryPage summaryPage;
        public static views.SummareCreatePage summaryCreatePage;
        public static views.BudgetPage budgetPage;
        public static views.newCategorypageView categoriesPage;
        public static views.newCategorypageView categorieswishPage;
        public static MyViewModel vm { get; set; }

        public CommandTemplate nextSummary { get; set; }
        //public static ObservableCollection<Summary> summaryList { get; set; }

        public void newSummary(ObservableCollection<Category> included, LocalDate begin, LocalDate end,List<SummaryType>summaries,Range priceRange)
        {
            MessageBox.Show("job is done");
            SummaryCalculation summaryCalc = new SummaryCalculation(new List<Category>(included),priceRange,vm, begin,end,summaries);
            Summary summary= summaryCalc.calculate();
            vm.summaryList.Add(summary);
            //summaryList.Add(summary);
            Summary.saveToFile("summaries.json",new List<Summary>(vm.summaryList));
            summaryPage.setSummary(summary);
            mainWindowFrame.Content = summaryPage;
        }
        static MainWindow()
        {
            vm = new MyViewModel();
             userControlStartScreen = new views.UserControlStartScreen(vm);
            userControlSummary = new views.UserControlSummary(vm);
            userControlEntries = new views.UserControlEntries(vm);
             userControlCategories = new views.UserControlCategories(vm);
            
            userControlPersonalization = new views.UserControlPersonalize();
            summaryPage = new views.SummaryPage();
            summaryCreatePage = new views.SummareCreatePage(vm);
            budgetPage = new views.BudgetPage(vm);
            categoriesPage = new views.newCategorypageView(vm, new FactoryCategoryPage());
            categorieswishPage = new views.newCategorypageView(vm, new FactoryWishCategoryPage());
    }
        public MainWindow()
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            // vm = new MyViewModel();
            //this.DataContext = vm;
            InitializeComponent();
            mainWindowFrame.Content = userControlStartScreen;
            mainWindow.SizeToContent = SizeToContent.WidthAndHeight;
        }

        public void saveFile()
        {
            vm.serialize("saveddata.xml");
           // Entry.saveInFile("wpisy.json", new List<Entry>(vm.entries));
           // Category.saveToFile("kategorie.json", new List<Category>(vm.categories));
        }
        public void readFile()
        {
            //vm.categories = new ObservableCollection<Category>(Category.readFromFile("kategorie.json"));
            //vm.entries = new ObservableCollection<Entry>(Entry.readFromFile("wpisy.json"));
            //vm.summaryList = new ObservableCollection<Summary>(Summary.readFromFile("summaries.json"));
            vm.deserialize("saveddata.xml");
            
        }

        private void menuItemViewStartScreen_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = userControlStartScreen;
        }

        private void menuItemViewEntries_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = userControlEntries;
        }

        private void menuItemViewCategories_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = userControlCategories;
        }

        private void menuItemViewSummary_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = userControlSummary;
        }

        private void menuItemViewPersonalization_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = userControlPersonalization;
        }
        /*
        private void openSummary(object sender, SelectionChangedEventArgs e)
        {
            summaryPage.setSummary((Summary)listBoxSummary.SelectedItem);
            mainWindowFrame.Content = summaryPage;
        }
        */
        
        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            //listBoxSummary.ItemsSource = vm.summaryList;
        }

        private void menuItemViewSummary_Click2(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = summaryCreatePage;
        }
        private void MenuNewFile_Click(object sender, RoutedEventArgs e)
        {
            vm.entries.Clear();
            vm.categories.Clear();
        }

        private void menuOpenFile_Click(object sender, RoutedEventArgs e)
        {
            readFile();
            mainWindowFrame.Content = userControlStartScreen;
        }

        private void menuSaveFile_Click(object sender, RoutedEventArgs e)
        {
            saveFile();
        }

        private void menuSaveFileAs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuITemBudget_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = budgetPage;
        }

        ///////////////////////////////managing adding and editing items
        ///
        public void addWishGroup(WishGroup wishgroup)
        {
            vm.wishgroups.Add(wishgroup);
        }
        public void addCategory(Category cat)
        {
            vm.categories.Add(cat);
        }

        private void newCategoeries_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = categoriesPage;
        }

        private void newWishCategories_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Content = categorieswishPage;
        }
    }
}
