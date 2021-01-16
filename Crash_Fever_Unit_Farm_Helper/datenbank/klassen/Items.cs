using Crash_Fever_Manager.log.klassen;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using static Crash_Fever_Manager.datenbank.klassen.Datenbank;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public class Items : ADatenbakenTabellen<Items>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public override void AddToDB()
        {
            List<Items> items = GetItemsDB();
            int zähler = 1;
            if (items == null)
            {
                this.ID = zähler;
                items = new List<Items>();
                items.Add(this);
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.ID == zähler)
                    {
                        zähler++;
                    }
                }
                this.ID = zähler;
                items.Insert(this.ID - 1, this);
            }

            UpdateDatei(items, Datenbanken.Items);
        }

        public override List<Items> GetAllFromDB()
        {
            return GetItemsDB();
        }

        public override Items GetSingleFromDB(int itemID)
        {
            List<Items> resultDB = GetItemsDB();
            Items result = new Items();
            bool itemGefunden = false;
            foreach (var item in resultDB)
            {
                if (item.ID == itemID)
                {
                    itemGefunden = true;
                    result = item;
                    break;
                }
            }
            if (itemGefunden)
            {
                return result;
            }
            else
            {
                ConsoleUI.ConsoleItem("Unit konnte nicht gefunden werden", Brushes.Red);
                return null;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override void UpdateChanges(List<Items> items)
        {
            UpdateDatei(items, Datenbanken.Items);
        }

        public override void UpdateSingle(Items items)
        {
            List<Items> itemsDB = GetItemsDB();

            for (int i = 0; i < itemsDB.Count; i++)
            {
                if (itemsDB[i].ID == items.ID)
                {
                    itemsDB[i] = items;
                }
            }
            UpdateChanges(itemsDB);
        }

        public List<Items> SortByName(List<Items> list)
        {
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
            return list;
        }
    }
}
