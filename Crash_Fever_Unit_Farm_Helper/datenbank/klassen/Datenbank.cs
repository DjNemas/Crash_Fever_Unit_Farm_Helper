using Crash_Fever_Manager.log.klassen;
using Crash_Fever_Manager.tools.klassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public static class Datenbank
    {
        private static readonly string _aktuellesVerzeichniss = Environment.CurrentDirectory;
        private static readonly string _dbOrdnerVerzeichniss = "/datenbank/json/";
        // DB File Names
        private static string units = "units";
        private static string items = "items";
        private static string events = "events";

        public static void UpdateDatei(object unitsList, Datenbanken dbs)
        {
            string datenbank = GetEnumDB(dbs);
            string JSONresult = JsonConvert.SerializeObject(unitsList);
            StreamWriter sw = new StreamWriter(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json", false);
            sw.WriteLine(JSONresult);
            sw.Close();
            
        }

        public static List<Units> GetUnitsDB(int? byID = null)
        {
            string datenbank = GetEnumDB(Datenbanken.Units);
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json");
            }
            catch (Exception e)
            {
                Log.LogMain("Kann Datenbank Datei nicht lesen.\n" + e, Log.ErrorLevel.Error);
            }
            
            List<Units> obj = JsonConvert.DeserializeObject<List<Units>>(sr.ReadToEnd());
            sr.Close();
            return obj;
        }

        public static List<Items> GetItemsDB(int? byID = null)
        {
            string datenbank = GetEnumDB(Datenbanken.Items);
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json");
            }
            catch (Exception e)
            {
                Log.LogMain("Kann Datenbank Datei nicht lesen.\n" + e, Log.ErrorLevel.Error);
            }

            List<Items> obj = JsonConvert.DeserializeObject<List<Items>>(sr.ReadToEnd());
            sr.Close();
            return obj;
        }

        public static List<Events> GetEventsDB(int? byID = null)
        {
            string datenbank = GetEnumDB(Datenbanken.Events);
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json");
            }
            catch (Exception e)
            {
                Log.LogMain("Kann Datenbank Datei nicht lesen.\n" + e, Log.ErrorLevel.Error);
            }

            List<Events> obj = JsonConvert.DeserializeObject<List<Events>>(sr.ReadToEnd());
            sr.Close();
            return obj;
        }

        private static void ErstelleJsonDBDateien()
        {
            string[] datenbankListe = new string[] { units, items, events };

            foreach (var item in datenbankListe)
            {
                if (!File.Exists(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + item + ".json"))
                {
                    
                    FileStream file = File.Create(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + item + ".json");
                    file.Close();
                }
            }
        }

        private static void ErstelleOrdner()
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss))
                {
                    Log.LogMain($"Der DB Ordner Existiert bereits", Log.ErrorLevel.Log);
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss);
                    Log.LogMain($"Der DB Ordner wurde Erfolgreich um {Directory.GetCreationTime(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss)} erstellt.", Log.ErrorLevel.Dev);
                }

            }
            catch (Exception e)
            {
                Log.LogMain($"Beim erstellen vom DB Ordner ist ein Fehler aufgetretten Fehler:\n{e}", Log.ErrorLevel.Error);
            }
        }

        public static void Init()
        {
            ErstelleOrdner();
            ErstelleJsonDBDateien();
        }

        private static string GetEnumDB(Datenbanken dbs)
        {
            string str = "";
            switch (dbs)
            {
                case Datenbanken.Units:
                    str = units;
                    break;
                case Datenbanken.Items:
                    str = items;
                    break;
                case Datenbanken.Events:
                    str = events;
                    break;
            }
            return str;
        }
        public enum Datenbanken
        {
            Units,
            Items,
            Events

        }

    }
}
