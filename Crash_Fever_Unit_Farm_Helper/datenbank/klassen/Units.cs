using Crash_Fever_Manager.log.klassen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using static Crash_Fever_Manager.datenbank.klassen.Datenbank;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public class Units : ADatenbakenTabellen<Units>
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
        public Items Item1 { get; set; }
        public Items Item2 { get; set; }
        public Items Item3 { get; set; }
        public Items Item4 { get; set; }
        public Items Item5 { get; set; }
        public int Item1AnzahlHaben { get; set; }
        public int Item1AnzahlBrauchen { get; set; }
        public int Item2AnzahlHaben { get; set; }
        public int Item2AnzahlBrauchen { get; set; }
        public int Item3AnzahlHaben { get; set; }
        public int Item3AnzahlBrauchen { get; set; }
        public int Item4AnzahlHaben { get; set; }
        public int Item4AnzahlBrauchen { get; set; }
        public int Item5AnzahlHaben { get; set; }
        public int Item5AnzahlBrauchen { get; set; }

        public override void AddToDB()
        {
            List<Units> units = GetUnitsDB();
            int zähler = 1;
            if (units == null)
            {
                this.ID = zähler;
                units = new List<Units>();
                units.Add(this);
            }
            else
            {
                foreach (var item in units)
                {
                    if (item.ID == zähler)
                    {
                        zähler++;
                    }
                }
                this.ID = zähler;
                units.Insert(this.ID - 1, this);
            }
            
            UpdateDatei(units, Datenbanken.Units);
        }

        public override void UpdateChanges(List<Units> units)
        {
            UpdateDatei(units, Datenbanken.Units);
        }

        public override List<Units> GetAllFromDB()
        {
            return GetUnitsDB();
        }

        public override void UpdateSingle(Units unit)
        {
            List<Units> unitsDB = GetUnitsDB();

            for (int i = 0; i < unitsDB.Count; i++)
            {
                if (unitsDB[i].ID == unit.ID)
                {
                    unitsDB[i] = unit;
                }
            }
            UpdateChanges(unitsDB);
        }

        public override Units GetSingleFromDB(int unitID)
        {
            List<Units> resultDB = GetUnitsDB();
            Units result = new Units();
            bool unitGefunden = false;
            foreach (var item in resultDB)
            {
                if (item.ID == unitID)
                {
                    unitGefunden = true;
                    result = item;
                    break;
                }
            }
            if (unitGefunden)
            {
                return result;
            }
            else
            {
                ConsoleUI.ConsoleUnit("Unit konnte nicht gefunden werden", Brushes.Red);
                return null;
            }
        }

        public override string ToString()
        {
            return this.Name + " Stars " + this.Stars + " Costs " + this.Costs;
        }

        public List<Units> SortByName(List<Units> list)
        {
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
            return list;
        }

        public List<Units> SortByStars(List<Units> list)
        {
            list.Sort((x,y) => x.Stars.CompareTo(y.Stars));
            return list;
        }

        public List<Units> SortByCosts(List<Units> list)
        {
            list.Sort((x, y) => x.Costs.CompareTo(y.Costs));
            return list;
        }

        public void UpdateItem(List<Units> units, Items item)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Item1 != null && units[i].Item1.ID == item.ID)
                {
                    units[i].Item1 = item;
                    UpdateSingle(units[i]);
                }
                if (units[i].Item2 != null && units[i].Item2.ID == item.ID)
                {
                    units[i].Item2 = item;
                    UpdateSingle(units[i]);
                }
                if (units[i].Item3 != null && units[i].Item3.ID == item.ID)
                {
                    units[i].Item3 = item;
                    UpdateSingle(units[i]);
                }
                if (units[i].Item4 != null && units[i].Item4.ID == item.ID)
                {
                    units[i].Item4 = item;
                    UpdateSingle(units[i]);
                }
                if (units[i].Item5 != null && units[i].Item5.ID == item.ID)
                {
                    units[i].Item5 = item;
                    UpdateSingle(units[i]);
                }
            }
        }
    }
}
