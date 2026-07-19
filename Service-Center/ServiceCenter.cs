using Hadware_Bestandsverwaltung.Interface;
using Hadware_Bestandsverwaltung.Klassen;
using Hadware_Bestandsverwaltung.Menü;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Hadware_Bestandsverwaltung.Service_Center
{
    public class ServiceCenter


    {
        List<IGeraet> alleGeräte = new List<IGeraet>();
        private static IDGenerator meinGenerator = new IDGenerator();
        private static IDGenerator.IdScope meinScope = new IDGenerator.IdScope();

        public static PC? PChinzufügen() // Kann null zurückgeben
        {
            string Marke = string.Empty;
            string Modell = string.Empty;
            string Prozessor = string.Empty;
            int RAM = 0;
            int Speicherplatz = 0;
            IGeraet.Status PcStatus = IGeraet.Status.Bestand;

            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Neuen PC hinzufügen ===\n");

                        Console.Write("Geben Sie die Marke des PC ein: ");
                        Marke = Console.ReadLine() ?? string.Empty;
                        if (Marke == null || string.IsNullOrWhiteSpace(Marke))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Die Marke darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }

                    while (true)
                    {
                        Console.Write("Geben Sie das Modell ein: ");
                        Modell = Console.ReadLine() ?? string.Empty;
                        if (Modell == null || string.IsNullOrWhiteSpace(Modell))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Das Modell darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }

                    while (true)
                    {
                        Console.Write("Geben Sie den Prozessor ein: ");
                        Prozessor = Console.ReadLine() ?? string.Empty;
                        if (Prozessor == null || string.IsNullOrWhiteSpace(Prozessor))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Der Prozessor darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }

                    while (true)
                    {
                        Console.Write("Geben Sie den RAM in GB ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int ram) || ram <= 0)
                        {
                            Console.WriteLine("Ungültige RAM-Eingabe! Bitte eine positive Zahl eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        RAM = ram;
                        break;
                    }

                    while (true)
                    {
                        Console.Write("Geben Sie den Speicherplatz in GB ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int speicherplatz) || speicherplatz <= 0)
                        {
                            Console.WriteLine("Ungültige Speicherplatz-Eingabe! Bitte eine positive Zahl eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        Speicherplatz = speicherplatz;
                        break;
                    }

                    while (true)
                    {
                        Console.WriteLine("Welchen Status hat der PC?");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Geben Sie die Zahl für den Status ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int statusAuswahl) || statusAuswahl < 1 || statusAuswahl > 4)
                        {
                            Console.WriteLine("Ungültige Status-Eingabe! Bitte eine Zahl zwischen 1 und 4 eingeben.");
                            Console.ReadKey();
                            continue;
                        }

                        switch (statusAuswahl)
                        {
                            case 1:
                                PcStatus = IGeraet.Status.Aktiv;
                                break;
                            case 2:
                                PcStatus = IGeraet.Status.Inaktiv;
                                break;
                            case 3:
                                PcStatus = IGeraet.Status.Defekt;
                                break;
                            case 4:
                                PcStatus = IGeraet.Status.Bestand;
                                break;
                        }
                        break;
                    }

                    //  PC-Objekt erstellen
                    int neueId = meinGenerator.GeneriereEindeutigeID(meinScope.PcScope);

                    PC neuerPC = new PC(neueId, Marke, Modell, Prozessor, RAM, Speicherplatz)
                    {
                        PcStatus = PcStatus
                    };

                    Console.WriteLine("\nPC erfolgreich hinzugefügt!");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();

                    return neuerPC; // PC-Objekt zurückgeben
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();
                }
            }


        }
        public static Tablet? Tablethinzufügen()
        {
            string Marke = string.Empty;
            string Modell = string.Empty;
            string Prozessor = string.Empty;
            int Speicherplatz = 0;
            int RAM = 0;
            IGeraet.Status TabletStatus = IGeraet.Status.Bestand;
            while (true)
            {

                try
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Neuen Tablet hinzufügen ===\n");
                        Console.Write("Geben Sie die Marke des Tablets ein: ");
                        Marke = Console.ReadLine() ?? string.Empty;
                        if (Marke == null || string.IsNullOrWhiteSpace(Marke))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Die Marke darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }

                        while (true)
                        {
                            Console.Write("Geben Sie das Modell ein: ");
                            Modell = Console.ReadLine() ?? string.Empty;
                            if (Modell == null || string.IsNullOrWhiteSpace(Modell))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Das Modell darf nicht leer sein!");
                                Console.ResetColor();
                                Console.ReadKey();
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            Console.Write("Geben Sie den Prozessor ein: ");
                            Prozessor = Console.ReadLine() ?? string.Empty;
                            if (Prozessor == null || string.IsNullOrWhiteSpace(Prozessor))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Der Prozessor darf nicht leer sein!");
                                Console.ResetColor();
                                Console.ReadKey();
                                continue;
                            }
                            break;

                        }

                        while (true)
                        {
                            Console.Write("Geben Sie den Speicherplatz in GB ein: ");
                            if (!int.TryParse(Console.ReadLine(), out int speicherplatz) || speicherplatz <= 0)
                            {
                                Console.WriteLine("Ungültige Speicherplatz-Eingabe! Bitte eine positive Zahl eingeben.");
                                Console.ReadKey();
                                continue;
                            }
                            Speicherplatz = speicherplatz;
                            break;
                        }

                        while (true)
                        {
                            Console.Write("Geben Sie den RAM in GB ein: ");
                            if (!int.TryParse(Console.ReadLine(), out int ram) || ram <= 0)
                            {
                                Console.WriteLine("Ungültige RAM-Eingabe! Bitte eine positive Zahl eingeben.");
                                Console.ReadKey();
                                continue;
                            }
                            RAM = ram;
                            break;
                        }


                        while (true)
                        {
                            Console.WriteLine("Welchen Status hat der Server?");
                            Console.WriteLine("[1] Aktiv");
                            Console.WriteLine("[2] Inaktiv");
                            Console.WriteLine("[3] Defekt");
                            Console.WriteLine("[4] Bestand");
                            Console.Write("Geben Sie die Zahl für den Status ein: ");
                            if (!int.TryParse(Console.ReadLine(), out int statusAuswahl) || statusAuswahl < 1 || statusAuswahl > 4)
                            {
                                Console.WriteLine("Ungültige Status-Eingabe! Bitte eine Zahl zwischen 1 und 4 eingeben.");
                                Console.ReadKey();
                                continue;
                            }
                            switch (statusAuswahl)
                            {
                                case 1:
                                    TabletStatus = IGeraet.Status.Aktiv;
                                    break;
                                case 2:
                                    TabletStatus = IGeraet.Status.Inaktiv;
                                    break;
                                case 3:
                                    TabletStatus = IGeraet.Status.Defekt;
                                    break;
                                case 4:
                                    TabletStatus = IGeraet.Status.Bestand;
                                    break;
                            }
                            break;



                        }

                        int neueId = meinGenerator.GeneriereEindeutigeID(meinScope.TabletScope);
                        Tablet neuerTablet = new Tablet(neueId, Marke, Modell, Prozessor, Speicherplatz, RAM)
                        {
                            TabletStatus = TabletStatus
                        };
                        Console.WriteLine("\nTablet erfolgreich hinzugefügt!");
                        Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                        Console.ReadKey();
                        return neuerTablet; // Tablet-Objekt zurückgeben






                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();
                }


                Console.WriteLine("\nTablet erfolgreich hinzugefügt!");
                Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
                Hauptmenue.Show();




            }


        }
        public static Server? Serverhinzufügen()
        {
            string Marke = string.Empty;
            string Modell = string.Empty;
            string Prozessor = string.Empty;
            int RAM = 0;
            int Speicherplatz = 0;
            IGeraet.Status ServerStatus = IGeraet.Status.Bestand;

            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Neuen Server hinzufügen ===\n");
                        Console.Write("Geben Sie die Marke des Servers ein: ");
                        Marke = Console.ReadLine() ?? string.Empty;
                        if (Marke == null || string.IsNullOrWhiteSpace(Marke))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Die Marke darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;

                    }
                    while (true)
                    {
                        Console.Write("Geben Sie das Modell ein: ");
                        Modell = Console.ReadLine() ?? string.Empty;
                        if (Modell == null || string.IsNullOrWhiteSpace(Modell))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Das Modell darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }

                    while (true)
                    {
                        Console.Write("Geben Sie den Prozessor ein: ");
                        Prozessor = Console.ReadLine() ?? string.Empty;
                        if (Prozessor == null || string.IsNullOrWhiteSpace(Prozessor))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Der Prozessor darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.Write("Geben Sie den RAM in GB ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int ram) || ram <= 0)
                        {
                            Console.WriteLine("Ungültige RAM-Eingabe! Bitte eine positive Zahl eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        RAM = ram;
                        break;
                    }
                    while (true)
                    {
                        Console.Write("Geben Sie den Speicherplatz in GB ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int speicherplatz) || speicherplatz <= 0)
                        {
                            Console.WriteLine("Ungültige Speicherplatz-Eingabe! Bitte eine positive Zahl eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        Speicherplatz = speicherplatz;
                        break;
                    }

                    while (true)
                    {
                        Console.WriteLine("Welchen Status hat der Server?");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Geben Sie die Zahl für den Status ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int statusAuswahl) || statusAuswahl < 1 || statusAuswahl > 4)
                        {
                            Console.WriteLine("Ungültige Status-Eingabe! Bitte eine Zahl zwischen 1 und 4 eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        switch (statusAuswahl)
                        {
                            case 1:
                                ServerStatus = IGeraet.Status.Aktiv;
                                break;
                            case 2:
                                ServerStatus = IGeraet.Status.Inaktiv;
                                break;
                            case 3:
                                ServerStatus = IGeraet.Status.Defekt;
                                break;
                            case 4:
                                ServerStatus = IGeraet.Status.Bestand;
                                break;
                        }
                        break;
                    }

                    // Server-Objekt erstellen
                    int neueId = meinGenerator.GeneriereEindeutigeID(meinScope.ServerScope);
                    Server neuerServer = new Server(neueId, Marke, Modell, Prozessor, RAM, Speicherplatz)
                    {
                        ServerStatus = ServerStatus
                    };
                    Console.WriteLine("\nServer erfolgreich hinzugefügt!");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();
                    return neuerServer;
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();
                }
            }
        }
        public static Laptop? Laptophinzufügen()
        {
            string Marke = string.Empty;
            string Modell = string.Empty;
            string Prozessor = string.Empty;
            int RAM = 0;
            int Speicherplatz = 0;
            IGeraet.Status LaptopStatus = IGeraet.Status.Bestand;



            while (true)
            {
                try
                {

                    while (true)
                    {


                        Console.Clear();
                        Console.WriteLine("=== Neuen Laptop hinzufügen ===\n");
                        Console.Write("Geben Sie die Marke des Laptops ein: ");
                        Marke = Console.ReadLine() ?? string.Empty;
                        if (Marke == null || string.IsNullOrWhiteSpace(Marke))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Die Marke darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }
                    


                    while (true)
                    {
                        Console.Write("Geben Sie das Modell ein: ");
                        Modell = Console.ReadLine() ?? string.Empty;
                        if (Modell == null || string.IsNullOrWhiteSpace(Modell))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Das Modell darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }

                    while (true)
                    {
                        Console.Write("Geben Sie den Prozessor ein: ");
                        Prozessor = Console.ReadLine() ?? string.Empty;
                        if (Prozessor == null || string.IsNullOrWhiteSpace(Prozessor))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Der Prozessor darf nicht leer sein!");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.Write("Geben Sie den RAM in GB ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int ram) || ram <= 0)
                        {
                            Console.WriteLine("Ungültige RAM-Eingabe! Bitte eine positive Zahl eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        RAM = ram;
                        break;
                    }
                    while (true)
                    {
                        Console.Write("Geben Sie den Speicherplatz in GB ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int speicherplatz) || speicherplatz <= 0)
                        {
                            Console.WriteLine("Ungültige Speicherplatz-Eingabe! Bitte eine positive Zahl eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        Speicherplatz = speicherplatz;
                        break;
                    }

                    while (true)
                    {
                        Console.WriteLine("Welchen Status hat der Laptop?");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Geben Sie die Zahl für den Status ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int statusAuswahl) || statusAuswahl < 1 || statusAuswahl > 4)
                        {
                            Console.WriteLine("Ungültige Status-Eingabe! Bitte eine Zahl zwischen 1 und 4 eingeben.");
                            Console.ReadKey();
                            continue;
                        }
                        switch (statusAuswahl)
                        {
                            case 1:
                                LaptopStatus = IGeraet.Status.Aktiv;
                                break;
                            case 2:
                                LaptopStatus = IGeraet.Status.Inaktiv;
                                break;
                            case 3:
                                LaptopStatus = IGeraet.Status.Defekt;
                                break;
                            case 4:
                                LaptopStatus = IGeraet.Status.Bestand;
                                break;
                        }
                        break;
                    }
                    // Laptop-Objekt erstellen
                    int neueId = meinGenerator.GeneriereEindeutigeID(meinScope.LaptopScope);
                    Laptop neuerLaptop = new Laptop(neueId, Marke, Modell, Prozessor, RAM, Speicherplatz)
                    {
                        LaptopStatus = LaptopStatus
                    };
                    Console.WriteLine("\nLaptop erfolgreich hinzugefügt!");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();

                    return neuerLaptop;


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}");
                    Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();
                }



            }
        }
        private static string OrdnerErstellen()
        {
            string OrdnerName = "GeräteDaten";
            string basisPfad = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string ordnerPfad = Path.Combine(basisPfad, OrdnerName);
            Directory.CreateDirectory(ordnerPfad);

            return ordnerPfad;
        }
        public void GeräteSpeichern() // mit dem .this werden alle Objekte der Liste hinzugefügt
        {
            string hauptPfad = OrdnerErstellen();

            // Server speichern
            var nurServer = this.alleGeräte.OfType<Server>().ToList();
            if (nurServer.Any()) // Any prüft, ob die Liste Elemente von Typ der Variable enthält
            {
                string serverOrdner = Path.Combine(hauptPfad, "ServerDaten");
                Directory.CreateDirectory(serverOrdner); // Unterordner erstellen
                string dateiPfad = Path.Combine(serverOrdner, "ServerDaten.sv");
                string jsonServer = JsonConvert.SerializeObject(nurServer, Formatting.Indented);
                File.WriteAllText(dateiPfad, jsonServer);
                Console.WriteLine($"Server gespeichert unter: {dateiPfad}");
            }

            // PC speichern
            var nurPC = this.alleGeräte.OfType<PC>().ToList();
            if (nurPC.Any())
            {
                string pcOrdner = Path.Combine(hauptPfad, "PCDaten");
                Directory.CreateDirectory(pcOrdner); // Unterordner erstellen
                string dateiPfad = Path.Combine(pcOrdner, "PCDaten.pc");
                string jsonPC = JsonConvert.SerializeObject(nurPC, Formatting.Indented);
                File.WriteAllText(dateiPfad, jsonPC);
                Console.WriteLine($"PC gespeichert unter: {dateiPfad}");
            }

            // Laptop speichern
            var nurLaptop = this.alleGeräte.OfType<Laptop>().ToList();
            if (nurLaptop.Any())
            {
                string laptopOrdner = Path.Combine(hauptPfad, "LaptopDaten");
                Directory.CreateDirectory(laptopOrdner); // Unterordner erstellen
                string dateiPfad = Path.Combine(laptopOrdner, "LaptopDaten.lt");
                string jsonLaptop = JsonConvert.SerializeObject(nurLaptop, Formatting.Indented);
                File.WriteAllText(dateiPfad, jsonLaptop);
                Console.WriteLine($"Laptop gespeichert unter: {dateiPfad}");
            }

            // Tablet speichern
            var nurTablet = this.alleGeräte.OfType<Tablet>().ToList();
            if (nurTablet.Any())
            {
                string tabletOrdner = Path.Combine(hauptPfad, "TabletDaten");
                Directory.CreateDirectory(tabletOrdner); // Unterordner erstellen
                string dateiPfad = Path.Combine(tabletOrdner, "TabletDaten.ta");
                string jsonTablet = JsonConvert.SerializeObject(nurTablet, Formatting.Indented);
                File.WriteAllText(dateiPfad, jsonTablet);
                Console.WriteLine($"Tablet gespeichert unter: {dateiPfad}");
            }
        }

        public void GeräteLaden()
        {
            // Es werden Temporäre Listen für jeden Gerätetyp erstellt und dann zur Hauptliste hinzugefügt
            alleGeräte.Clear(); // Liste vor dem Laden leeren
            string hauptPfad = OrdnerErstellen();

            string serverPfad = Path.Combine(hauptPfad, "ServerDaten", "ServerDaten.sv");
            if (File.Exists(serverPfad)) // Überprüfen, ob die Datei existiert
            {
                string json = File.ReadAllText(serverPfad);
                List<Server> geladeneServer = JsonConvert.DeserializeObject<List<Server>>(json) ?? new List<Server>();
                alleGeräte.AddRange(geladeneServer.Cast<IGeraet>());

                //  IDs registrieren
                foreach (var server in geladeneServer)
                {
                    meinScope.ServerScope.VergebeneIDs.Add(server.Id);
                }
            }

            string pcPfad = Path.Combine(hauptPfad, "PCDaten", "PCDaten.pc");
            if (File.Exists(pcPfad))
            {
                string json = File.ReadAllText(pcPfad);
                List<PC> geladenerPc = JsonConvert.DeserializeObject<List<PC>>(json) ?? new List<PC>();
                alleGeräte.AddRange(geladenerPc.Cast<IGeraet>());

                //  IDs registrieren
                foreach (var pc in geladenerPc)
                {
                    meinScope.PcScope.VergebeneIDs.Add(pc.Id);
                }
            }

            string laptopPfad = Path.Combine(hauptPfad, "LaptopDaten", "LaptopDaten.lt");
            if (File.Exists(laptopPfad))
            {
                string json = File.ReadAllText(laptopPfad);
                List<Laptop> geladenerLaptop = JsonConvert.DeserializeObject<List<Laptop>>(json) ?? new List<Laptop>();
                alleGeräte.AddRange(geladenerLaptop.Cast<IGeraet>());

                //  IDs registrieren
                foreach (var laptop in geladenerLaptop)
                {
                    meinScope.LaptopScope.VergebeneIDs.Add(laptop.Id);
                }
            }

            string tabletPfad = Path.Combine(hauptPfad, "TabletDaten", "TabletDaten.ta");
            if (File.Exists(tabletPfad))
            {
                string json = File.ReadAllText(tabletPfad);
                List<Tablet> geladenerTablet = JsonConvert.DeserializeObject<List<Tablet>>(json) ?? new List<Tablet>();
                alleGeräte.AddRange(geladenerTablet.Cast<IGeraet>());

                //  IDs registrieren
                foreach (var tablet in geladenerTablet)
                {
                    meinScope.TabletScope.VergebeneIDs.Add(tablet.Id);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[INFO] {alleGeräte.Count} Geräte erfolgreich geladen.");
            Console.ResetColor();
        }

        public void AlleGeräteAnzeigen()
        {
            Console.Clear();
            Console.WriteLine("=== Alle geladenen Geräte ===\n");

            if (alleGeräte.Count == 0)
            {
                Console.WriteLine("Keine Geräte vorhanden.");
            }
            else
            {
                Console.WriteLine($"Anzahl der Geräte: {alleGeräte.Count}\n");

                foreach (var gerät in alleGeräte)
                {
                    Console.WriteLine($"Typ: {gerät.GetType().Name}");
                    gerät.AnzeigenDetails();
                    Console.WriteLine("-----------------------------------");
                }
            }

            Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
            Console.ReadKey();

        }

        public List<IGeraet> GetAlleGeräte() // gibt die Liste aller Geräte zurück
        {
            return alleGeräte;
        }
    }

}
