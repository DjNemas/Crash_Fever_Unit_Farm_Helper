using Crash_Fever_Manager.log.klassen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crash_Fever_Manager.datenbank.klassen
{
    class Datenbank
    {
        private Log _log;
        private log.klassen.Console _console;

        public Datenbank()
        {
            this._log = new Log();
            this._console = new log.klassen.Console();
        }
    }
}
