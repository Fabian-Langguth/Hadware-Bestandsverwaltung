using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hadware_Bestandsverwaltung.Klassen;
using Hadware_Bestandsverwaltung.Interface;

namespace Hadware_Bestandsverwaltung.Klassen
{
    public class Laptop : IGeraet
    {
        public int Id { get; init; }
        public string Marke { get; set; }
        public string Modell { get; set; }
        public string Prozessor { get; set; }
        public int RAM { get; set; } // in GB
        public int Speicherplatz { get; set; } // in GB
        public IGeraet.Status LaptopStatus { get; set; }

        public Laptop (int id, string marke, string modell, string prozessor, int ram, int speicherplatz)
        {
            Id = id;
            Marke = marke;
            Modell = modell;
            Prozessor = prozessor;
            RAM = ram;
            Speicherplatz = speicherplatz;
        
        }
        public void AnzeigenDetails()
        {
            Console.WriteLine($"Laptop ID: {Id}");
            Console.WriteLine($"Marke: {Marke}");
            Console.WriteLine($"Modell: {Modell}");
            Console.WriteLine($"Prozessor: {Prozessor}");
            Console.WriteLine($"RAM: {RAM} GB");
            Console.WriteLine($"Speicherplatz: {Speicherplatz} GB");
            Console.WriteLine($"Der Status des Gerätes ist: {LaptopStatus} ");
        }
    }
}
