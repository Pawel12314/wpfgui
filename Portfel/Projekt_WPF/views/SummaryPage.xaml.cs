using Projekt_WPF.commands;
using Projekt_WPF.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_WPF.views
{
    /// <summary>
    /// Logika interakcji dla klasy SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {

        public CommandTemplate printCommand { get; set; }
        private Summary summary { get; set; }
        public decimal variable1{ get; set; }
        public SummaryPage()
        {

            variable1 = 10000M;
            InitializeComponent();
        }
        public void setSummary(Summary summary)
        {
            this.summary = summary;
            nazwaPodsumowania.Text = summary.ToString();
            outcome_list.ItemsSource = summary.outcome_summary;
            income_List.ItemsSource = summary.income_summary;
            //columnsinglediagram.ItemsSource = summary.income_summary;
            //this.DataContext = summary;
            incomeChart.DataContext = summary.income_summary;
        }

        private void printit(/*object sender, RoutedEventArgs e*/)
        {
            MessageBox.Show("printing");
            summaryDocument.PagePadding = new Thickness(10, 10, 10, 10);
            summaryDocument.ColumnGap = 0;
            PrintDialog printDlg = new PrintDialog();
            printDlg.ShowDialog();
            summaryDocument.ColumnWidth = printDlg.PrintableAreaWidth;
            IDocumentPaginatorSource idpSource = summaryDocument;

            printDlg.PrintDocument(idpSource.DocumentPaginator, summary.ToString());
        }

        private void PageLoad(object sender, RoutedEventArgs e)
        {
            printCommand = new CommandTemplate((o) => printit(), o => true);
            KeyBinding keyBinding = new KeyBinding
            {
                Command = printCommand,
                Key = Key.K,
                Modifiers=ModifierKeys.Control
                
            };
            
            this.InputBindings.Add(keyBinding);
        }
    }
}
