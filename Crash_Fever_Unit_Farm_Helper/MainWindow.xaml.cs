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
        public MainWindow()
        {
            InitializeComponent();

            this.InitAll();

            
        }

        private void InitAll()
        {
            ConsoleUI.Init(this);
            Log.Init();
            Datenbank.Init();

            Units units = new Units();
            //Sort List
            List<Units> unitsList = units.GetAllUnitsFromDB();
            unitsList = units.SortByName(unitsList);
            // Init UnitDBToList
            lBoxUnitUebersichtUnits.ItemsSource = unitsList;

        }

        #region MENÜ BUTTONS
        private void btnUnitUebersicht_Click(object sender, RoutedEventArgs e)
        {
            ViewSelectUnitUebersicht();
        }

        private void btnUnitHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxUnitHinzufügen();
            lBoxUnitUebersichtUnits.SelectedItem = null;
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenHinzufuegen.IsEnabled = true;

            ConsoleUI.ConsoleUnit("Neue Unit kann hinzugefügt werden.");
            ViewSelectUnitHinzufuegen();
        }

        private void btnEventHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            ViewSelectEventHinzufuegen();
        }

        private void btnAwakeFarmen_Click(object sender, RoutedEventArgs e)
        {
            ViewSelectAwakeFarmen();
        }

        private void btnEventTimer_Click(object sender, RoutedEventArgs e)
        {
            ViewSelectEventTimer();
        }
        #endregion

        #region UNIT ÜBERSICHT CONTENT

        #region BUTTON
        private void btnUnitUebersichtZuUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            btnUnitHinzufuegenUnitUpdate.IsEnabled = true;
            btnUnitHinzufuegenHinzufuegen.IsEnabled = false;
            Units selectedUnit = (Units)lBoxUnitUebersichtUnits.SelectedItem;
            ConsoleUI.ConsoleUnit("Ausgewählte Unit: " + selectedUnit.Name);
            ViewSelectUnitHinzufuegen();
        }

        private void btnUnitUebersichtName_Click(object sender, RoutedEventArgs e)
        {
            Units unit = new Units();
            List<Units> unitList = unit.GetAllUnitsFromDB();
            unitList = unit.SortByName(unitList);
            lBoxUnitUebersichtUnits.ItemsSource = null;
            lBoxUnitUebersichtUnits.ItemsSource = unitList;
        }

        private void btnUnitUebersichtStars_Click(object sender, RoutedEventArgs e)
        {
            Units unit = new Units();
            List<Units> unitList = unit.GetAllUnitsFromDB();
            unitList = unit.SortByStars(unitList);
            lBoxUnitUebersichtUnits.ItemsSource = null;
            lBoxUnitUebersichtUnits.ItemsSource = unitList;
        }

        private void btnUnitUebersichtCosts_Click(object sender, RoutedEventArgs e)
        {
            Units unit = new Units();
            List<Units> unitList = unit.GetAllUnitsFromDB();
            unitList = unit.SortByCosts(unitList);
            lBoxUnitUebersichtUnits.ItemsSource = null;
            lBoxUnitUebersichtUnits.ItemsSource = unitList;
        }

        #endregion

        #region LISTBOX
        private void UpdateListBoxUnitUebersicht()
        {
            lBoxUnitUebersichtUnits.ItemsSource = null;

            Units unit = new Units();
            lBoxUnitUebersichtUnits.ItemsSource = unit.GetAllUnitsFromDB();
        }
        private void lBoxUnitUebersichtUnits_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lBoxUnitUebersichtUnits.SelectedItem != null)
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
        #endregion

        #endregion

        #region UNIT HINZUFÜGEN CONTENT

        #region BUTTONS
        private void btnUnitHinzufuegenHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
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

            unit.AddUnitToDB();

            this.UpdateListBoxUnitUebersicht();
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenHinzufuegen.IsEnabled = true;
            ConsoleUI.ConsoleUnit("Unit " + unit.Name + " wurde Hinzugefügt!");

            ClearTextBoxUnitHinzufügen();

        }

        private void btnUnitHinzufuegenUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            Units unit = new Units();
            Units selectedUnit = (Units)lBoxUnitUebersichtUnits.SelectedItem;
            unit = unit.GetSingleUnitFromDB(selectedUnit.ID);

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

            unit.UpdateSingleUnit(unit);

            UpdateListBoxUnitUebersicht();
            lBoxUnitUebersichtUnits.SelectedItem = null;
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenHinzufuegen.IsEnabled = true;

            ConsoleUI.ConsoleUnit("Unit: " + unit.Name + " Update erfolgreich!");

            ClearTextBoxUnitHinzufügen();
        }
        #endregion

        #region TEXTBOX
        private void ClearTextBoxUnitHinzufügen()
        {
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
        #endregion

        #endregion

        #region EVENT HINZUFÜGEN CONTENT

        #endregion

        #region AWAKE FARMEN CONTENT

        #endregion

        #region EVENT TIMER CONTENT

        #endregion

        #region CONSOLEUI HELPER FUNKTIONS
        private string TextfeldLeerConsole(string str)
        {
            if (str == "")
            {
                ConsoleUI.ConsoleUnit("Nicht alle Textfelder sind gefüllt!", Brushes.Yellow);
                return "";
            }
            else
            {
                return str;
            }
            
        }
        #endregion

        #region HELPER FUNKTIONS AND MEMBER
        private static readonly Regex onlyNumber = new Regex("[^0-9]"); //regex that matches disallowed text
        private void OnlyNumber(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsOnlyNumberAllowed(e.Text);
        }
        private static bool IsOnlyNumberAllowed(string text)
        {
            return !onlyNumber.IsMatch(text);
        }
        
        #endregion

        #region VIEW SELECTION
        private void ViewSelectUnitUebersicht()
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
        private void ViewSelectUnitHinzufuegen()
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
        private void ViewSelectEventHinzufuegen()
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
        private void ViewSelectAwakeFarmen()
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
        private void ViewSelectEventTimer()
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
        #endregion

        
    }
}
