using Crash_Fever_Manager.log.klassen;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Crash_Fever_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Log _log;
        private Console _console;

        public MainWindow()
        {
            InitializeComponent();
            // Init Outputs For Console and Log
            _console = new Console(this);
            _log = new Log();

            List<string> test = new List<string>();
            test.Add("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takim");

            lBoxAwakeFarmenNochZuGrinden.ItemsSource = test;
            lBoxAwakeFarmenEvent.ItemsSource = test;
            lBoxUnitUebersichtUnits.ItemsSource = test;
            lBoxEventTimerEvents.ItemsSource = test;
        }

        private void btnUnitUebersichtZuUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            btnUnitHinzufuegen_Click(sender, e);
        }

        private void btnUnitUebersicht_Click(object sender, RoutedEventArgs e)
        {
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnUnitUebersicht.Background = Brushes.LightBlue;
            grdUnitUebersicht.Visibility = Visibility.Visible;
        }

        private void btnUnitHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnUnitUebersicht.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnUnitHinzufuegen.Background = Brushes.LightBlue;
            grdUnitHinzufuegen.Visibility = Visibility.Visible;
        }

        private void btnEventHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnUnitUebersicht.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnEventHinzufuegen.Background = Brushes.LightBlue;
            grdEventHinzufuegen.Visibility = Visibility.Visible;
        }

        private void btnAwakeFarmen_Click(object sender, RoutedEventArgs e)
        {
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnUnitUebersicht.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnAwakeFarmen.Background = Brushes.LightBlue;
            grdAwakeFarmen.Visibility = Visibility.Visible;
        }

        private void btnEventTimer_Click(object sender, RoutedEventArgs e)
        {
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;

            btnUnitUebersicht.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;

            btnEventTimer.Background = Brushes.LightBlue;
            grdEventTimer.Visibility = Visibility.Visible;
        }
    }
}
