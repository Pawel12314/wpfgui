using Projekt_WPF.commands;
using Projekt_WPF.models;
using Projekt_WPF.models.patterns.CategoryPatterns.FactoryMethod;
using Projekt_WPF.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy UserControlCategories.xaml
    /// </summary>
    public partial class UserControlCategories : Page
    {
        MyViewModel vm;

        public CommandTemplate newCategoryCMD { get; set; }
        public CommandTemplate editCategoryCMD { get; set; }
        public CommandTemplate deleteCategoryCMD { get; set; }
        
        public UserControlCategories(MyViewModel vm)
        {
            this.vm = vm;
            InitializeComponent();
        }
        public void dodajKategorie(String newCategoryName)
        {
            Category newCategory = new Category(newCategoryName);
            vm.categories.Add(newCategory);
            categoriesListBox.Items.Refresh();
            //Category.saveToFile("kategorie.json", new List<Category>(vm.categories));
        }
        public void edytujKategorie(Category category, string newName)
        {
            category.changeName(newName);

            categoriesListBox.Items.Refresh();
            //Category.saveToFile("kategorie.json", new List<Category>(vm.categories));
        }
        public void usunKategorie(Category category)
        {
            //TODO: error handling kiedy istnieją wpisy o kategorii którą chcemy usunąć
            if (isThisCategoryUsed(category.name))
            {
                MessageBox.Show("Nie można usunąć kategorii do której są przypisane wpisy!");
            }
            else
            {
                vm.categories.Remove(category);

                categoriesListBox.Items.Refresh();
                //Category.saveToFile("kategorie.json", new List<Category>(vm.categories));
            }
        }
        public bool isThisCategoryNameValid(string name)
        {
            if (name.Trim().Length > 0)
            {
                return true;
            }
            return false;
        }
        public bool doesCategoryWithNameAlreadyExist(string name)
        {
            for (int i = 0; i < vm.categories.Count; i++)
                if (vm.categories[i].name == name)
                    return true;
            return false;
        }
        public bool isThisCategoryUsed(string name)
        {
            for(int i = 0; i < vm.entries.Count; i++)
                if (vm.entries[i].category.name == name)
                    return true;
            return false;
        }

        

        private void newCategoryButton_Click(object sender , RoutedEventArgs e )
        {
            //var temp = new WindowNewCategory();
            //temp.Show();
            newCategoryCMD.Execute(1);
        }

        private void editCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            editCategoryCMD.Execute(1);
        }

        private void deleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            deleteCategoryCMD.Execute(1);
        }
        public void newCategoryCmd()
        {
            var temp = new addNewCategory( new FactoryCategoryCreator());
            temp.ShowDialog();
        }
        public void editCategoryCmd()
        {
            Category sCategory = (Category)categoriesListBox.SelectedItem;
            var temp = new WindowEditCategory(sCategory);
            temp.ShowDialog();
        }
        public void deleteCategoryCmd()
        {
            ;
            if(MessageBox.Show("Czy na pewno chcesz usunąć kategorię " + categoriesListBox.SelectedItem.ToString(), "Usuwanie kategorii", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Category kat = (Category)categoriesListBox.SelectedItem;
                ((UserControlCategories)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).usunKategorie(kat);
            }
        }
       
        private bool isSelected()
        {
            if(categoriesListBox.SelectedItem!=null)
            {
                return true;
            }
            return false;
        }
        private void loadWindow(object sender, RoutedEventArgs e)
        {
           
           this.DataContext = vm;
            categoriesListBox.ItemsSource = vm.categories;
            newCategoryCMD = new CommandTemplate(o => newCategoryCmd(), o => true);
           
           
            editCategoryCMD = new CommandTemplate(o => editCategoryCmd(), o =>
            
                isSelected()
            
            );
           
           

            deleteCategoryCMD = new CommandTemplate(o => deleteCategoryCmd(), o => isSelected());

            menubuttons.AddProperty = newCategoryCMD;
            menubuttons.EditProperty = editCategoryCMD;
            menubuttons.DeleteProperty = deleteCategoryCMD;
            // this.InputBindings.Add(keyBinding);
            // var li = this.Resources[""];
            // MessageBox.Show(li.ToString());
            //vm = new MyViewModel();

            //if(kategorie==null)
            //kategorie = new List<Kategoria>();
            //kategorie = Kategoria.wczytajZPliku("kategorie.json");

        }

        
    }
}
