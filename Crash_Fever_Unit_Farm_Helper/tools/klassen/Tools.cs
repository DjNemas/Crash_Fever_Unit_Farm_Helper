
using Crash_Fever_Manager.log.klassen;
using System;
using System.IO;
using System.Windows.Media;

namespace Crash_Fever_Manager.tools.klassen
{
    public class Tools
    {
        private static Log log;

        public bool ErstelleOrdner(string ordnerVerzeichniss, string ordnerName)
        {
            log = new Log();
            log.klassen.Console console = new log.klassen.Console();
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(ordnerVerzeichniss))
                {
                    log.LogMain($"Der {ordnerName} Ordner Existiert bereits", Log.ErrorLevel.Log);
                    return false;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(ordnerVerzeichniss);
                log.LogMain($"Der {ordnerName} Ordner wurde Erfolgreich um {Directory.GetCreationTime(ordnerVerzeichniss)} erstellt.", Log.ErrorLevel.Log);
                return false;
            }
            catch (Exception e)
            {
                log.LogMain($"Erstelle {ordnerName} Ordner Fehler:\n{e}", Log.ErrorLevel.Error);
                console.ConsoleAll($"Erstelle {ordnerName} Ordner Fehler:\n{e}", Brushes.Yellow);
                return true;
            }
            finally { }
        }
    }
}
