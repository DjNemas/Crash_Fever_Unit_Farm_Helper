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

namespace Crash_Fever_Unit_Farm_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToFarm_Click(object sender, RoutedEventArgs e)
        {
            //vBoxUnitOverview.Visibility = Visibility.Hidden;
            //vBoxToFarm.Visibility = Visibility.Visible;
        }

        private void btnUnitOverview_Click(object sender, RoutedEventArgs e)
        {
            //vBoxToFarm.Visibility = Visibility.Hidden;
            //vBoxUnitOverview.Visibility = Visibility.Visible;
        }
    }
}
