using System.Collections.Generic;
using System.Windows;

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
            List<string> test = new List<string>();
            test.Add("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takim");

            lBoxAwakeFarmenNochZuGrinden.ItemsSource = test;
            lBoxAwakeFarmenEvent.ItemsSource = test;
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
