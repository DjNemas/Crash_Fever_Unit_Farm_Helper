using Crash_Fever_Manager.log.klassen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public class Units
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Costs { get; set; }
        public int Stars { get; set; }
        public string Element { get; set; }
        public int Level { get; set; }
        public int Bugs { get; set; }
        public int LimitBreak { get; set; }
        public int LimitBreakBugs { get; set; }
        public int SkillLevel { get; set; }
        public int SkillLevelMax { get; set; }
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public Item Item4 { get; set; }
        public Item Item5 { get; set; }

        [NonSerialized]
        public static List<Units> unitDB;

        [NonSerialized]
        private static bool ListLoaded = false;

        public Units() 
        {
            if (!ListLoaded)
            {
                ListLoaded = true;
                unitDB = new List<Units>();
                unitDB = Datenbank.GetUnitsDB("unit");
            }
        }

        public Units AddUnitToList()
        {
            var units = Datenbank.GetUnitsDB("unit");
            int zähler = 1;
            foreach (var item in units)
            {
                if (item.ID == zähler)
                {
                    zähler++;
                }
            }
            this.ID = zähler;
            unitDB.Insert(this.ID - 1, this);
            return this;
        }

        public void UpdateUnits()
        {
            Datenbank.UpdateDatei(unitDB, "unit");
        }

        public List<Units> GetUnits(int? unitID = null)
        {
            if (unitID == null)
            {
                return Datenbank.GetUnitsDB("unit");
            }
            else if(unitID > 0)
            {
                var result = Datenbank.GetUnitsDB("unit");
                bool unitGefunden = false;
                foreach (var item in result)
                {
                    if (item.ID == unitID)
                    {
                        unitGefunden = true;
                        result = new List<Units>();
                        result.Add(item);
                        break;
                    }
                }
                if (unitGefunden)
                {
                    return result;
                }
                else
                {
                    log.klassen.Console console = new log.klassen.Console();
                    console.ConsoleUnit("Unit konnte nicht gefunden werden", Brushes.Red);
                    return null;
                }
            }
            else
            {
                Log log = new Log();
                log.LogMain("Unit konnte nicht aus der Datenbank gezogen werden! ID muss größer als 0 sein.", Log.ErrorLevel.Error);
                return null;
            }
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public override string ToString()
        {
            return this.Name + " Stars " + this.Stars + " Costs " + this.Costs;
        }
    }
}
