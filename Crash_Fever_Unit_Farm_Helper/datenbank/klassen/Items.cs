using System;
using System.Collections.Generic;
using System.Text;

namespace Crash_Fever_Manager.datenbank.klassen
{
    public class Items : ADatenbakenTabellen
    {
        public override void AddUnitToDB()
        {
            throw new NotImplementedException();
        }

        public override List<Units> GetAllUnitsFromDB()
        {
            throw new NotImplementedException();
        }

        public override Units GetSingleUnitFromDB(int unitID)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void UpdateChanges(List<Units> units)
        {
            throw new NotImplementedException();
        }

        public override void UpdateSingleUnit(Units unit)
        {
            throw new NotImplementedException();
        }
    }
}
