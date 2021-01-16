using Crash_Fever_Manager.log.klassen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using static Crash_Fever_Manager.datenbank.klassen.Datenbank;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public class Events : ADatenbakenTabellen<Events>
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Diff { get; set; }

        public Items Item { get; set; }

        public DateTime DatumBegin { get; set; }

        public DateTime UhrzeitBegin { get; set; }

        public DateTime DatumEnde { get; set; }

        public DateTime UhrzeitEnde { get; set; }


        public override void AddToDB()
        {
            List<Events> events = GetEventsDB();
            int zähler = 1;
            if (events == null)
            {
                this.ID = zähler;
                events = new List<Events>();
                events.Add(this);
            }
            else
            {
                foreach (var item in events)
                {
                    if (item.ID == zähler)
                    {
                        zähler++;
                    }
                }
                this.ID = zähler;
                events.Insert(this.ID - 1, this);
            }
            UpdateDatei(events, Datenbanken.Events);
        }

        public override List<Events> GetAllFromDB()
        {
            return GetEventsDB();
        }

        public override Events GetSingleFromDB(int eventID)
        {
            List<Events> resultDB = GetEventsDB();
            Events result = new Events();
            bool eventGefunden = false;
            foreach (var item in resultDB)
            {
                if (item.ID == eventID)
                {
                    eventGefunden = true;
                    result = item;
                    break;
                }
            }
            if (eventGefunden)
            {
                return result;
            }
            else
            {
                ConsoleUI.ConsoleEvent("Unit konnte nicht gefunden werden", Brushes.Red);
                return null;
            }
        }

        public override string ToString()
        {
            return this.Name + " Diff: " + this.Diff;
        }

        public override void UpdateChanges(List<Events> events)
        {
            UpdateDatei(events, Datenbanken.Events);
        }

        public override void UpdateSingle(Events events)
        {
            List<Events> eventsDB = GetEventsDB();

            for (int i = 0; i < eventsDB.Count; i++)
            {
                if (eventsDB[i].ID == events.ID)
                {
                    eventsDB[i] = events;
                }
            }
            UpdateChanges(eventsDB);
        }
    }
}
