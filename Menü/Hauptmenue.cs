using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace Hadware_Bestandsverwaltung.Menü
{
     class Hauptmenue
    {
        public static void Show()
        {
            
            string format = "  "; // Zwei Leerzeichen für die Einrückung
            int spaltenBreite = 10; // Gesamtbreite der Spalte
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========");
            Console.WriteLine("HauptMenü ");
            Console.WriteLine("===========");
            Console.ResetColor();
            Console.WriteLine($"{format}1. {"Laptop".PadRight(spaltenBreite)}anlegen:");
            Console.WriteLine($"{format}2. {"PC".PadRight(spaltenBreite)}anlegen:");
            Console.WriteLine($"{format}3. {"Server".PadRight(spaltenBreite)}anlegen:");
            Console.WriteLine($"{format}4. {"Tablet".PadRight(spaltenBreite)}anlegen:");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"{format}5. BearbeitungsMenü öffnen");
            Console.WriteLine($"{format}6. Alle Geräte anzeigen");
            Console.WriteLine($"{format}7. Programm beenden\n");
            Console.Write("Geben sie bitte eine Zahl von 1 bis 7 ein und wählen sie aus was sie machen möchten: ");
            
        }
    }
}
