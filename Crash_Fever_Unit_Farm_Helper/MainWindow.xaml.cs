using Crash_Fever_Manager.datenbank.klassen;
using Crash_Fever_Manager.log.klassen;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        private log.klassen.Console _console;

        public MainWindow()
        {
            InitializeComponent();
            // Init Outputs For Console and Log
            _console = new log.klassen.Console(this);
            _log = new Log();

            // Init UnitDBToList
            Units unit = new Units();

            lBoxUnitUebersichtUnits.ItemsSource = Units.unitDB;
            lBoxAwakeFarmenNochZuGrinden.ItemsSource = unit.Name;
            lBoxAwakeFarmenEvent.ItemsSource = unit.Name;
            lBoxEventTimerEvents.ItemsSource = unit.Name;
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

        private void btnUnitHinzufuegenHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            if (tBoxUnitHinzufuegenName.Text.Equals("d"))
            {
                _console.ConsoleUnit("Test", Brushes.Yellow);
            }

            Units unit = new Units();
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenName.Text).Equals("")) return;
            unit.Name = tBoxUnitHinzufuegenName.Text;

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenCosts.Text).Equals("")) return;
            unit.Costs = Convert.ToInt32(tBoxUnitHinzufuegenCosts.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenStars.Text).Equals("")) return;
            unit.Stars = Convert.ToInt32(tBoxUnitHinzufuegenStars.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenElement.Text).Equals("")) return;
            unit.Element = tBoxUnitHinzufuegenElement.Text;

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenLevel.Text).Equals("")) return;
            unit.Level = Convert.ToInt32(tBoxUnitHinzufuegenLevel.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenBugs.Text).Equals("")) return;
            unit.Bugs = Convert.ToInt32(tBoxUnitHinzufuegenBugs.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenLimitBreak.Text).Equals("")) return;
            unit.LimitBreak = Convert.ToInt32(tBoxUnitHinzufuegenLimitBreak.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenLimitBreakBugs.Text).Equals("")) return;
            unit.LimitBreakBugs = Convert.ToInt32(tBoxUnitHinzufuegenLimitBreakBugs.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenSkillLevel.Text).Equals("")) return;
            unit.SkillLevel = Convert.ToInt32(tBoxUnitHinzufuegenSkillLevel.Text);

            if (TextfeldLeerConsole(tBoxUnitHinzufuegenSkillLevelMax.Text).Equals("")) return;
            unit.SkillLevelMax = Convert.ToInt32(tBoxUnitHinzufuegenSkillLevelMax.Text);

            unit.AddUnitToList().UpdateUnits();

            lBoxUnitUebersichtUnits.ItemsSource = null;
            lBoxUnitUebersichtUnits.ItemsSource = Units.unitDB;
            
            _console.ConsoleUnit("Unit " + unit.Name + " wurde Hinzugefügt!");

            tBoxUnitHinzufuegenName.Text = "";
            tBoxUnitHinzufuegenCosts.Text = "";
            tBoxUnitHinzufuegenStars.Text = "";
            tBoxUnitHinzufuegenElement.Text = "";
            tBoxUnitHinzufuegenLevel.Text = "";
            tBoxUnitHinzufuegenBugs.Text = "";
            tBoxUnitHinzufuegenLimitBreak.Text = "";
            tBoxUnitHinzufuegenLimitBreakBugs.Text = "";
            tBoxUnitHinzufuegenSkillLevel.Text = "";
            tBoxUnitHinzufuegenSkillLevelMax.Text = "";

        }

        private void OnlyNumber(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsOnlyNumberAllowed(e.Text);
        }

        private static readonly Regex onlyNumber = new Regex("[^0-9]"); //regex that matches disallowed text
        private static bool IsOnlyNumberAllowed(string text)
        {
            return !onlyNumber.IsMatch(text);
        }

        private string TextfeldLeerConsole(string str)
        {
            if (str == "")
            {
                _console.ConsoleUnit("Nicht alle Textfelder sind gefüllt!", Brushes.Yellow);
                return "";
            }
            else
            {
                return str;
            }
            
        }

        private void lBoxUnitUebersichtUnits_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Units unit = lBoxUnitUebersichtUnits.SelectedItem as Units;
            // Display Unit Übersicht
            tBoxUnitUebersichtName.Text = unit.Name;
            tBoxUnitUebersichtCosts.Text = unit.Costs.ToString();
            tBoxUnitUebersichtStars.Text = unit.Stars.ToString();
            tBoxUnitUebersichtElement.Text = unit.Element;
            tBoxUnitUebersichtLevel.Text = unit.Level.ToString();
            tBoxUnitUebersichtBugs.Text = unit.Bugs.ToString();
            tBoxUnitUebersichtLimitBreak.Text = unit.LimitBreak.ToString();
            tBoxUnitUebersichtLimitBreakBugs.Text = unit.LimitBreakBugs.ToString();
            tBoxUnitUebersichtSkillLevel.Text = unit.SkillLevel.ToString();
            tBoxUnitUebersichtSkillLevelMax.Text = unit.SkillLevelMax.ToString();

            // Display Unit Hinzufügen
            tBoxUnitHinzufuegenName.Text = unit.Name;
            tBoxUnitHinzufuegenCosts.Text = unit.Costs.ToString();
            tBoxUnitHinzufuegenStars.Text = unit.Stars.ToString();
            tBoxUnitHinzufuegenElement.Text = unit.Element;
            tBoxUnitHinzufuegenLevel.Text = unit.Level.ToString();
            tBoxUnitHinzufuegenBugs.Text = unit.Bugs.ToString();
            tBoxUnitHinzufuegenLimitBreak.Text = unit.LimitBreak.ToString();
            tBoxUnitHinzufuegenLimitBreakBugs.Text = unit.LimitBreakBugs.ToString();
            tBoxUnitHinzufuegenSkillLevel.Text = unit.SkillLevel.ToString();
            tBoxUnitHinzufuegenSkillLevelMax.Text = unit.SkillLevelMax.ToString();
            btnUnitUebersichtZuUnitUpdate.IsEnabled = true;
        }
    }
}
