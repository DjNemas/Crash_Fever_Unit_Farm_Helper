using System;
using System.Collections.Generic;
using System.Text;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public abstract class ADatenbakenTabellen<T>
    {
        public abstract void AddToDB();
        public abstract void UpdateChanges(List<T> units);
        public abstract List<T> GetAllFromDB();
        public abstract T GetSingleFromDB(int unitID);
        public abstract void UpdateSingle(T unit);
        public abstract override string ToString();

    }
}
