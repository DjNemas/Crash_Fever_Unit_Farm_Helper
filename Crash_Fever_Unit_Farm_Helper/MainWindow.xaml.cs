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


            // Init Units for ListBox
            Units units = new Units();
            List<Units> unitsList = units.GetAllFromDB();
            if (unitsList != null)
            {
                unitsList = units.SortByName(unitsList);
            }
            // Init UnitDBToList
            lBoxUnitUebersichtUnits.ItemsSource = unitsList;


            // Init Items for ComboBox
            Items items = new Items();
            List<Items> itemsList = items.GetAllFromDB();
            if (itemsList != null)
            {
                itemsList = items.SortByName(itemsList);
            }
            cbItemHinzufügenItems.ItemsSource = itemsList;
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

        private void btnItemHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            tBoxItemHinzufuegenName.Text = "";
            btnItemHinzufuegenAbwaehlen.IsEnabled = false;
            btnItemHinzufuegenUpdate.IsEnabled = false;
            btnItemHinzufuegenHinzufuegen.IsEnabled = true;
            btnItemHinzufuegenAbwaehlen.Visibility = Visibility.Hidden;
            btnItemHinzufuegenHinzufuegen.Visibility = Visibility.Visible;

            ConsoleUI.ConsoleItem("Neues Item kann hinzugefügt werden.");
            ViewSelectItemHinzufuegen();
        }

        private void btnEventHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            
            dpEventHinzufuegenDatumBegin.SelectedDate = DateTime.Now;
            dpEventHinzufuegenDatumEnde.SelectedDate = DateTime.Now;
            tpEventHinzufuegenBeginVon.Value = DateTime.Now;
            tpEventHinzufuegenBeginBis.Value = DateTime.Now;
            tpEventHinzufuegenEndeVon.Value = DateTime.Now;
            tpEventHinzufuegenEndeBis.Value = DateTime.Now;
            btnEventHinzufuegenUpdate.IsEnabled = false;
            btnEventHinzufuegenAbwaehlen.IsEnabled = false;
            btnEventHinzufuegenHinzufuegen.IsEnabled = true;
            btnEventHinzufuegenAbwaehlen.Visibility = Visibility.Hidden;
            btnEventHinzufuegenHinzufuegen: Visibility = Visibility.Visible;
            ConsoleUI.ConsoleUnit("Neue Unit kann hinzugefügt werden.");
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
            if (lBoxUnitUebersichtUnits.SelectedItem == null) return;

            btnUnitHinzufuegenUnitUpdate.IsEnabled = true;
            btnUnitHinzufuegenHinzufuegen.IsEnabled = false;
            Units selectedUnit = (Units)lBoxUnitUebersichtUnits.SelectedItem;
            ConsoleUI.ConsoleUnit("Ausgewählte Unit: " + selectedUnit.Name);
            ViewSelectUnitHinzufuegen();
        }

        private void btnUnitUebersichtName_Click(object sender, RoutedEventArgs e)
        {
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            Units unit = new Units();
            List<Units> unitList = unit.GetAllFromDB();
            unitList = unit.SortByName(unitList);
            lBoxUnitUebersichtUnits.ItemsSource = null;
            lBoxUnitUebersichtUnits.ItemsSource = unitList;
        }

        private void btnUnitUebersichtStars_Click(object sender, RoutedEventArgs e)
        {
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            Units unit = new Units();
            List<Units> unitList = unit.GetAllFromDB();
            unitList = unit.SortByStars(unitList);
            lBoxUnitUebersichtUnits.ItemsSource = null;
            lBoxUnitUebersichtUnits.ItemsSource = unitList;
        }

        private void btnUnitUebersichtCosts_Click(object sender, RoutedEventArgs e)
        {
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            Units unit = new Units();
            List<Units> unitList = unit.GetAllFromDB();
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
            lBoxUnitUebersichtUnits.ItemsSource = unit.GetAllFromDB();
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

            unit.AddToDB();

            this.UpdateListBoxUnitUebersicht();
            btnUnitUebersichtZuUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenUnitUpdate.IsEnabled = false;
            btnUnitHinzufuegenHinzufuegen.IsEnabled = true;
            ConsoleUI.ConsoleUnit("Unit " + unit.Name + " wurde Hinzugefügt!");

            ClearTextBoxUnitHinzufügen();

        }

        private void btnUnitHinzufuegenUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenName.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenCosts.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenStars.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenElement.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenLevel.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenLimitBreak.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenLimitBreakBugs.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenSkillLevel.Text).Equals("")) return;
            if (TextfeldLeerConsole(tBoxUnitHinzufuegenSkillLevelMax.Text).Equals("")) return;

            Units unit = new Units();
            Units selectedUnit = (Units)lBoxUnitUebersichtUnits.SelectedItem;
            unit = unit.GetSingleFromDB(selectedUnit.ID);
            
            unit.Name = tBoxUnitHinzufuegenName.Text;
            unit.Costs = Convert.ToInt32(tBoxUnitHinzufuegenCosts.Text);
            unit.Stars = Convert.ToInt32(tBoxUnitHinzufuegenStars.Text);
            unit.Element = tBoxUnitHinzufuegenElement.Text;
            unit.Level = Convert.ToInt32(tBoxUnitHinzufuegenLevel.Text);
            unit.Bugs = Convert.ToInt32(tBoxUnitHinzufuegenBugs.Text);
            unit.LimitBreak = Convert.ToInt32(tBoxUnitHinzufuegenLimitBreak.Text);
            unit.LimitBreakBugs = Convert.ToInt32(tBoxUnitHinzufuegenLimitBreakBugs.Text);
            unit.SkillLevel = Convert.ToInt32(tBoxUnitHinzufuegenSkillLevel.Text);
            unit.SkillLevelMax = Convert.ToInt32(tBoxUnitHinzufuegenSkillLevelMax.Text);

            unit.UpdateSingle(unit);

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

        #region ITEM HINZUFÜGEN

        #region BUTTONS
        private void btnItemHinzufuegenHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            Items items = new Items();

            if (TextfeldLeerConsole(tBoxItemHinzufuegenName.Text).Equals("")) return;
            items.Name = tBoxItemHinzufuegenName.Text;

            items.AddToDB();

            List<Items> itemsList = items.GetAllFromDB();
            itemsList = items.SortByName(itemsList);

            cbItemHinzufügenItems.ItemsSource = itemsList;

            btnItemHinzufuegenAbwaehlen.IsEnabled = false;
            btnItemHinzufuegenAbwaehlen.Visibility = Visibility.Hidden;

            btnItemHinzufuegenUpdate.IsEnabled = false;

            btnItemHinzufuegenHinzufuegen.IsEnabled = true;
            btnItemHinzufuegenHinzufuegen.Visibility = Visibility.Visible;

            tBoxItemHinzufuegenName.Text = "";

            ConsoleUI.ConsoleItem("Item " + items.Name + " hinzugefügt");
        }

        private void btnItemHinzufuegenAbwaehlen_Click(object sender, RoutedEventArgs e)
        {
            Items item = (Items)cbItemHinzufügenItems.SelectedItem;
            ConsoleUI.ConsoleItem("Item " + item.Name + " wurde abgewählt");
            cbItemHinzufügenItems.SelectedItem = null;
            tBoxItemHinzufuegenName.Text = "";

            btnItemHinzufuegenAbwaehlen.IsEnabled = false;
            btnItemHinzufuegenAbwaehlen.Visibility = Visibility.Hidden;

            btnItemHinzufuegenUpdate.IsEnabled = false;

            btnItemHinzufuegenHinzufuegen.IsEnabled = true;
            btnItemHinzufuegenHinzufuegen.Visibility = Visibility.Visible;

        }

        private void btnItemHinzufuegenUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cbItemHinzufügenItems.SelectedItem == null) return;
            if (TextfeldLeerConsole(tBoxItemHinzufuegenName.Text).Equals("")) return;

            Items item = new Items();
            Items selectedItem = (Items)cbItemHinzufügenItems.SelectedItem;
            item = item.GetSingleFromDB(selectedItem.ID);
            item.Name = tBoxItemHinzufuegenName.Text;
            item.UpdateSingle(item);

            List<Items> itemsList = item.GetAllFromDB();
            itemsList = item.SortByName(itemsList);

            cbItemHinzufügenItems.ItemsSource = itemsList;

            btnItemHinzufuegenAbwaehlen.IsEnabled = false;
            btnItemHinzufuegenAbwaehlen.Visibility = Visibility.Hidden;

            btnItemHinzufuegenUpdate.IsEnabled = false;

            btnItemHinzufuegenHinzufuegen.IsEnabled = true;
            btnItemHinzufuegenHinzufuegen.Visibility = Visibility.Visible;

            tBoxItemHinzufuegenName.Text = "";

            ConsoleUI.ConsoleItem("Item: " + item.Name + " Update erfolgreich!");
        }
        #endregion

        #region ComboBox
        private void cbItemHinzufügenItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbItemHinzufügenItems.SelectedItem == null) return;

            btnItemHinzufuegenHinzufuegen.IsEnabled = false;
            btnItemHinzufuegenHinzufuegen.Visibility = Visibility.Hidden;

            btnItemHinzufuegenAbwaehlen.IsEnabled = true;
            btnItemHinzufuegenAbwaehlen.Visibility = Visibility.Visible;

            btnItemHinzufuegenUpdate.IsEnabled = true;

            Items item = (Items)cbItemHinzufügenItems.SelectedItem;
            tBoxItemHinzufuegenName.Text = item.Name;

            ConsoleUI.ConsoleItem("Item " + item.Name + " wurde ausgewählt");

        }
        #endregion

        #endregion

        #region EVENT HINZUFÜGEN CONTENT

        private void btnEventHinzufuegenHinzufuegen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEventHinzufuegenUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEventHinzufuegenAbwaehlen_Click(object sender, RoutedEventArgs e)
        {

        }

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
            grdItemHinzufuegen.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnItemHinzufuegen.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnUnitUebersicht.Background = Brushes.LightBlue;
            grdUnitUebersicht.Visibility = Visibility.Visible;
        }
        private void ViewSelectUnitHinzufuegen()
        {
            grdItemHinzufuegen.Visibility = Visibility.Hidden;
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnItemHinzufuegen.Background = Brushes.LightGray;
            btnUnitUebersicht.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnUnitHinzufuegen.Background = Brushes.LightBlue;
            grdUnitHinzufuegen.Visibility = Visibility.Visible;
        }
        private void ViewSelectItemHinzufuegen()
        {
            grdEventTimer.Visibility = Visibility.Hidden;
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;

            btnEventTimer.Background = Brushes.LightGray;
            btnUnitUebersicht.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;

            grdItemHinzufuegen.Visibility = Visibility.Visible;
            btnItemHinzufuegen.Background = Brushes.LightBlue;

        }
        private void ViewSelectEventHinzufuegen()
        {
            grdItemHinzufuegen.Visibility = Visibility.Hidden;
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnItemHinzufuegen.Background = Brushes.LightGray;
            btnUnitUebersicht.Background = Brushes.LightGray;
            btnAwakeFarmen.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnEventHinzufuegen.Background = Brushes.LightBlue;
            grdEventHinzufuegen.Visibility = Visibility.Visible;
        }
        private void ViewSelectAwakeFarmen()
        {
            grdItemHinzufuegen.Visibility = Visibility.Hidden;
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdEventTimer.Visibility = Visibility.Hidden;

            btnItemHinzufuegen.Background = Brushes.LightGray;
            btnUnitUebersicht.Background = Brushes.LightGray;
            btnUnitHinzufuegen.Background = Brushes.LightGray;
            btnEventHinzufuegen.Background = Brushes.LightGray;
            btnEventTimer.Background = Brushes.LightGray;

            btnAwakeFarmen.Background = Brushes.LightBlue;
            grdAwakeFarmen.Visibility = Visibility.Visible;
        }
        private void ViewSelectEventTimer()
        {
            grdItemHinzufuegen.Visibility = Visibility.Hidden;
            grdUnitUebersicht.Visibility = Visibility.Hidden;
            grdUnitHinzufuegen.Visibility = Visibility.Hidden;
            grdEventHinzufuegen.Visibility = Visibility.Hidden;
            grdAwakeFarmen.Visibility = Visibility.Hidden;

            btnItemHinzufuegen.Background = Brushes.LightGray;
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
