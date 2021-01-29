using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Projekt_WPF.globalSettings
{
    public static class GlobalSettings
    {
        private static double fontsize = 16;
        private static SolidColorBrush startscreencolor = new SolidColorBrush(Colors.White);
        private static SolidColorBrush entryscreencolor = startscreencolor;
        private static SolidColorBrush categoryscreencolor = startscreencolor;
        private static SolidColorBrush summaryscreencolor = startscreencolor;
        private static SolidColorBrush personalizescreencolor = startscreencolor;
        private static SolidColorBrush windowscreencolor = startscreencolor;
        public static double FontSize
        { 
            get { return fontsize; }
            set
            {
                fontsize = value;
                MainWindow.userControlCategories.FontSize = FontSize;
                MainWindow.userControlEntries.FontSize = FontSize;
                MainWindow.userControlPersonalization.FontSize = FontSize;
                MainWindow.userControlStartScreen.FontSize = FontSize;
                MainWindow.userControlSummary.FontSize = FontSize;

            }
        }

        public static SolidColorBrush StartScreenColor
        { 
            get { return startscreencolor; }
            set { startscreencolor = value; MainWindow.userControlStartScreen.mainGrid.Background = StartScreenColor; }
        }
        public static SolidColorBrush EntryScreenColor
        {
            get { return entryscreencolor; }
            set { entryscreencolor = value; MainWindow.userControlEntries.mainGrid.Background = EntryScreenColor; }
        }
        public static SolidColorBrush CategoryScreenColor
        {
            get { return categoryscreencolor; }
            set { categoryscreencolor = value; MainWindow.userControlCategories.mainGrid.Background = CategoryScreenColor; }
        }
        
        public static SolidColorBrush PersonalizeScreenColor
        { get { return personalizescreencolor; }
            set { personalizescreencolor = value; MainWindow.userControlPersonalization.mainGrid.Background = PersonalizeScreenColor; }
        }
        public static SolidColorBrush SummaryScreenColor
        {
            get { return summaryscreencolor; }
            set { summaryscreencolor = value; MainWindow.userControlSummary.mainGrid.Background = SummaryScreenColor; }
        }
        public static SolidColorBrush WindowScreenColor
        {
            get { return windowscreencolor; }
            set { windowscreencolor = value; }
        }

        public static void SetAllColorsTo(SolidColorBrush newColor)
        {
            StartScreenColor = newColor;
            EntryScreenColor = newColor;
            CategoryScreenColor = newColor;
            SummaryScreenColor = newColor;
           
            PersonalizeScreenColor = newColor;
            WindowScreenColor = newColor;
        }
    }
}
