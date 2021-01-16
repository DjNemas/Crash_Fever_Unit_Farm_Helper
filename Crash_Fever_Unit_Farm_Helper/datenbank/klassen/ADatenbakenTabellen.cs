using System;
using System.Collections.Generic;
using System.Text;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public abstract class ADatenbakenTabellen
    {
        public abstract void AddUnitToDB();
        public abstract void UpdateChanges(List<Units> units);
        public abstract List<Units> GetAllUnitsFromDB();
        public abstract Units GetSingleUnitFromDB(int unitID);
        public abstract void UpdateSingleUnit(Units unit);
        public abstract override string ToString();

    }
}
