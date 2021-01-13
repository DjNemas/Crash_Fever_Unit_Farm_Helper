using Crash_Fever_Manager.log.klassen;
using Crash_Fever_Manager.tools.klassen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public static class Datenbank
    {
        private static Log _log = new Log();
        private static log.klassen.Console _console = new log.klassen.Console();
        private static bool _errorOrdner;
        private static bool _existOrdner;
        private static readonly string _aktuellesVerzeichniss = Environment.CurrentDirectory;
        private static readonly string _dbOrdnerVerzeichniss = "/datenbank/json/";

        public static void UpdateDatei(object unitsList, string datenbank)
        {
            if (!_existOrdner)
            {
                _errorOrdner = ErstelleOrdner();
            }

            if (!_errorOrdner)
            {
                string JSONresult = JsonConvert.SerializeObject(unitsList);
                StreamWriter sw = new StreamWriter(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json", false);
                sw.WriteLine(JSONresult);
                sw.Close();
            }
        }

        public static List<Units> GetUnitsDB(string datenbank, int? byID = null)
        {
            if (!_existOrdner)
            {
                _errorOrdner = ErstelleOrdner();
            }

            if (!File.Exists(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json"))
            {
                return null;
            }

            StreamReader sr = new StreamReader(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss + datenbank + ".json");
            List<Units> obj = JsonConvert.DeserializeObject<List<Units>>(sr.ReadToEnd());
            sr.Close();
            return obj;
        }

        private static bool ErstelleOrdner()
        {
            Tools tool = new Tools();
            _existOrdner = true;
            return tool.ErstelleOrdner(_aktuellesVerzeichniss + _dbOrdnerVerzeichniss, "/datenbank/json/");
        }

    }
}
