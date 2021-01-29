using Projekt_WPF.commands;
using Projekt_WPF.models;
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
using System.Windows.Shapes;

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy WindowNewCategory.xaml
    /// </summary>
    public partial class WindowNewCategory : Window
    {

        public CommandTemplate cancelCMD { get; set; }
        public CommandTemplate applyCMD { get; set; }
        public WindowNewCategory()
        {
            InitializeComponent();
            this.Background = globalSettings.GlobalSettings.WindowScreenColor;
        }

        private void cancelButtonClick(object sender, RoutedEventArgs e)
        {
            cancelCMD.Execute(1);
        }

        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            applyCMD.Execute(1);
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this,nameTextBox);
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
            string newName = nameTextBox.Text;

            if (newName.Length > 35)
            {
                MessageBox.Show("Maksymalna długość nazwy kategorii to 35 znaków!");
                return;
            }

            if (((UserControlCategories)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).isThisCategoryNameValid(newName) == false)
            {
                MessageBox.Show("Nazwa nie może byc pusta!");
            }
            else if (((UserControlCategories)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).doesCategoryWithNameAlreadyExist(newName))
            {
                MessageBox.Show("Już istnieje kategoria z taką nazwą!");
            }
            else
            {
                ((UserControlCategories)((MainWindow)Application.Current.MainWindow).mainWindowFrame.Content).dodajKategorie(newName);
                this.Close();
            }
        }

        private void Cancel()
        {
            this.Close();
        }
    }
}
