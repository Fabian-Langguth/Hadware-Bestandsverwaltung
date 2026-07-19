using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hadware_Bestandsverwaltung.Klassen;
using Hadware_Bestandsverwaltung.Interface;

namespace Hadware_Bestandsverwaltung.Klassen
{
    public class Tablet : IGeraet
    {
        public int Id { get; init; }
        public string Marke { get; set; }
        public string Modell { get; set; }
        public string Prozessor { get; set; }
        public int Speicherplatz { get; set; } // in GB
        public int RAM { get; set; } // in GB
        public IGeraet.Status TabletStatus { get; set; }

        public Tablet(int id, string marke, string modell, string prozessor,  int speicherplatz, int ram)
        {
            Id = id;
            Marke = marke;
            Modell = modell;
            Prozessor = prozessor;
            Speicherplatz = speicherplatz;
            RAM = ram;
        }

       public void AnzeigenDetails()
        {
            Console.WriteLine($"Tablet ID: {Id}");
            Console.WriteLine($"Marke: {Marke}");
            Console.WriteLine($"Modell: {Modell}");
            Console.WriteLine($"Prozessor: {Prozessor}");
            Console.WriteLine($"Speicherplatz: {Speicherplatz} GB");
            Console.WriteLine($"Der Status des Gerätes ist: {TabletStatus} ");
        }
    }
}
