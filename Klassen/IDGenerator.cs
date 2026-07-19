using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadware_Bestandsverwaltung.Klassen
{
    internal class IDGenerator // unvollständig KI generiert
    {


        public class IDManager
        {
            public string? Name { get; set; }
            public int StartWert { get; set; }
            public int maxWert { get; set; }
            public HashSet<int> VergebeneIDs { get; init; } = new HashSet<int>();
        }

        public class IdScope
        {
            public IDManager ServerScope { get; } = new IDManager() { Name = "Server", StartWert = 1000, maxWert = 1999 };
            public IDManager PcScope { get; } = new IDManager() { Name = "PC", StartWert = 2000, maxWert = 2999 };
            public IDManager TabletScope { get; } = new IDManager() { Name = "Tablet", StartWert = 3000, maxWert = 3999 };
            public IDManager LaptopScope { get; } = new IDManager() { Name = "Laptop", StartWert = 4000, maxWert = 4999  };
        }



        public int GeneriereEindeutigeID(IDManager scope)
        {
            int neueID = scope.StartWert;
            // Suche nach der nächsten verfügbaren ID
            while (scope.VergebeneIDs.Contains(neueID))
            {
                neueID++;
                if (neueID > scope.maxWert)
                {
                    throw new InvalidOperationException($"Keine verfügbaren IDs im Bereich für {scope.Name}.");
                }
            }
            // Füge die neue ID zu den vergebenen IDs hinzu
            scope.VergebeneIDs.Add(neueID);
            return neueID;
        }
    }
}

      
