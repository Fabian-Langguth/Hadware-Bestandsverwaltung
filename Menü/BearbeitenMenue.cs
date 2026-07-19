using Hadware_Bestandsverwaltung.Interface;
using Hadware_Bestandsverwaltung.Klassen;
using Hadware_Bestandsverwaltung.Service_Center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadware_Bestandsverwaltung.Menü
// Bei Falscher Eingabe der ID fehlt eine Fehlermeldung mit der Aufforderung,
// es erneut zu versuchen. ohne das dass Programm abbricht (LaptopBearbeiten, PCBearbeiten, TabletBearbeiten, ServerBearbeiten)
{
    internal class BearbeitenMenue
    {
        public static void Show(List<IGeraet> geräteListe, ServiceCenter serviceCenter)
        {
            string[] gueltigeOptionen = { "Laptop", "PC", "Tablet", "Server", "Hauptmenü" };
            string eingabe;
            string format = "  "; // Zwei Leerzeichen für die Einrückung
            bool gueltigeEingabe = false;
            while(true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{format}================");
                Console.WriteLine($"{format}BearbeitungsMenü");
                Console.WriteLine($"{format}================\n");
                Console.ResetColor();
                Console.WriteLine("---------------------------");
                Console.WriteLine($"{format}Laptop");
                Console.WriteLine($"{format}PC");
                Console.WriteLine($"{format}Tablet");
                Console.WriteLine($"{format}Server");
                Console.WriteLine($"{format}Hauptmenü");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Welchen Artikel möchten sie bearbeiten? bitte geben sie den Namen ein:");
                Console.Write("Bitte schreiben sie den zu bearbeitenden Artikel: ");
                eingabe = Console.ReadLine()!;
                // Prüfung der Eingabe 
                gueltigeEingabe = gueltigeOptionen.Any(option => string.Equals(option, eingabe, StringComparison.OrdinalIgnoreCase));

                // Falls gefunden, normalisierung für Switch-Case
                if (gueltigeEingabe)
                {
                    eingabe = gueltigeOptionen.First(option =>  string.Equals(option, eingabe, StringComparison.OrdinalIgnoreCase));
                    break;
                }            
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
            } 
            switch (eingabe)
            {
                case "Laptop":
                    {
                        LaptopBearbeiten(geräteListe, serviceCenter);
                        break;
                    }
                case "PC":
                    {
                        PCBearbeiten(geräteListe, serviceCenter);
                        break;
                    }
                case "Tablet":
                    {
                        TabletBearbeiten(geräteListe, serviceCenter);
                        break;
                    }
                case "Server":
                    {
                        ServerBearbeiten(geräteListe, serviceCenter);
                        break;
                    }
                case "Hauptmenü":
                    {
                        Console.Clear();
                        Hauptmenue.Show();
                        break;
                    }
            }
        }

        private static void LaptopBearbeiten(List<IGeraet> geräteListe, ServiceCenter serviceCenter)
        {
            // Alle Laptops filtern
            var laptops = geräteListe.OfType<Laptop>().ToList();

            if (laptops.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine Laptops vorhanden!");
                Console.ResetColor();
                Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
                return;
            }

            // Laptops anzeigen
            Console.Clear();
            Console.WriteLine("=== Verfügbare Laptops ===\n");
            foreach (var laptop in laptops)
            {
                Console.WriteLine($"[ID: {laptop.Id}] {laptop.Marke} {laptop.Modell} - Status: {laptop.LaptopStatus}");
            }

            // ID eingeben
            Console.Write("\nGeben Sie die ID des zu bearbeitenden Laptops ein: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige ID!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Laptop finden
            var zuBearbeitenderLaptop = laptops.FirstOrDefault(l => l.Id == id);
            if (zuBearbeitenderLaptop == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Laptop mit dieser ID nicht gefunden!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Bearbeitungsmenü
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Laptop bearbeiten ===\n");
                zuBearbeitenderLaptop.AnzeigenDetails();
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("[1] Marke ändern");
                Console.WriteLine("[2] Modell ändern");
                Console.WriteLine("[3] Prozessor ändern");
                Console.WriteLine("[4] RAM ändern");
                Console.WriteLine("[5] Speicherplatz ändern");
                Console.WriteLine("[6] Status ändern");
                Console.WriteLine("[7] Zurück");
                Console.WriteLine("[8] Löschen");
                Console.WriteLine("---------------------------");
                Console.Write("Ihre Wahl: ");

                if (!int.TryParse(Console.ReadLine(), out int wahl))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }

                switch (wahl)
                {
                    case 1:
                        Console.Write("Neue Marke eingeben: ");
                        string neueMarke = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neueMarke))
                        {
                            zuBearbeitenderLaptop.Marke = neueMarke;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Marke erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Neues Modell eingeben: ");
                        string neuesModell = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuesModell))
                        {
                            zuBearbeitenderLaptop.Modell = neuesModell;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Modell erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Neuer Prozessor eingeben: ");
                        string neuerProzessor = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuerProzessor))
                        {
                            zuBearbeitenderLaptop.Prozessor = neuerProzessor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Prozessor erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Neuer RAM in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerRam) && neuerRam > 0)
                        {
                            zuBearbeitenderLaptop.RAM = neuerRam;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RAM erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Write("Neuer Speicherplatz in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerSpeicher) && neuerSpeicher > 0)
                        {
                            zuBearbeitenderLaptop.Speicherplatz = neuerSpeicher;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Speicherplatz erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\nNeuen Status wählen:");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Ihre Wahl: ");
                        if (int.TryParse(Console.ReadLine(), out int statusWahl) && statusWahl >= 1 && statusWahl <= 4)
                        {
                            zuBearbeitenderLaptop.LaptopStatus = statusWahl switch
                            {
                                1 => IGeraet.Status.Aktiv,
                                2 => IGeraet.Status.Inaktiv,
                                3 => IGeraet.Status.Defekt,
                                4 => IGeraet.Status.Bestand,
                                _ => zuBearbeitenderLaptop.LaptopStatus
                            };
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Status erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("Änderungen werden gespeichert...");
                        serviceCenter.GeräteSpeichern();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Erfolgreich gespeichert!");
                        Console.ResetColor();
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren...");
                        Console.ReadKey();
                        Console.Clear();
                        Hauptmenue.Show();
                        return;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nSind Sie sicher, dass Sie diesen Server löschen möchten? (J/N): ");
                        Console.ResetColor();
                        string bestaetigung = Console.ReadLine()?.ToUpper() ?? "";
                        if (bestaetigung == "J")
                        {
                            geräteListe.Remove(zuBearbeitenderLaptop);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Laptop erfolgreich gelöscht!");
                            Console.ResetColor();
                            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                            serviceCenter.GeräteSpeichern();
                            Hauptmenue.Show();
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Löschvorgang abgebrochen.");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Auswahl!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void PCBearbeiten(List<IGeraet> geräteListe, ServiceCenter serviceCenter)
        {
            // Alle PCs filtern
            var pcs = geräteListe.OfType<PC>().ToList();

            if (pcs.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine PCs vorhanden!");
                Console.ResetColor();
                Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
                return;
            }

            // PCs anzeigen
            Console.Clear();
            Console.WriteLine("=== Verfügbare PCs ===\n");
            foreach (var pc in pcs)
            {
                Console.WriteLine($"[ID: {pc.Id}] {pc.Marke} {pc.Modell} - Status: {pc.PcStatus}");
            }

            // ID eingeben
            Console.Write("\nGeben Sie die ID des zu bearbeitenden PCs ein: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige ID!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // PC finden
            var zuBearbeitenderPC = pcs.FirstOrDefault(p => p.Id == id);
            if (zuBearbeitenderPC == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PC mit dieser ID nicht gefunden!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Bearbeitungsmenü
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PC bearbeiten ===\n");
                zuBearbeitenderPC.AnzeigenDetails();
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("[1] Marke ändern");
                Console.WriteLine("[2] Modell ändern");
                Console.WriteLine("[3] Prozessor ändern");
                Console.WriteLine("[4] RAM ändern");
                Console.WriteLine("[5] Speicherplatz ändern");
                Console.WriteLine("[6] Status ändern");
                Console.WriteLine("[7] Zurück");
                Console.WriteLine("[8] Löschen");
                Console.WriteLine("---------------------------");
                Console.Write("Ihre Wahl: ");

                if (!int.TryParse(Console.ReadLine(), out int wahl))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }

                switch (wahl)
                {
                    case 1:
                        Console.Write("Neue Marke eingeben: ");
                        string neueMarke = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neueMarke))
                        {
                            zuBearbeitenderPC.Marke = neueMarke;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Marke erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Neues Modell eingeben: ");
                        string neuesModell = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuesModell))
                        {
                            zuBearbeitenderPC.Modell = neuesModell;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Modell erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Neuer Prozessor eingeben: ");
                        string neuerProzessor = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuerProzessor))
                        {
                            zuBearbeitenderPC.Prozessor = neuerProzessor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Prozessor erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Neuer RAM in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerRam) && neuerRam > 0)
                        {
                            zuBearbeitenderPC.RAM = neuerRam;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RAM erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Write("Neuer Speicherplatz in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerSpeicher) && neuerSpeicher > 0)
                        {
                            zuBearbeitenderPC.Speicherplatz = neuerSpeicher;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Speicherplatz erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\nNeuen Status wählen:");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Ihre Wahl: ");
                        if (int.TryParse(Console.ReadLine(), out int statusWahl) && statusWahl >= 1 && statusWahl <= 4)
                        {
                            zuBearbeitenderPC.PcStatus = statusWahl switch
                            {
                                1 => IGeraet.Status.Aktiv,
                                2 => IGeraet.Status.Inaktiv,
                                3 => IGeraet.Status.Defekt,
                                4 => IGeraet.Status.Bestand,
                                _ => zuBearbeitenderPC.PcStatus
                            };
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Status erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("Änderungen werden gespeichert...");
                        serviceCenter.GeräteSpeichern();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Erfolgreich gespeichert!");
                        Console.ResetColor();
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren...");
                        Console.ReadKey();
                        Console.Clear();
                        Hauptmenue.Show();
                        return;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nSind Sie sicher, dass Sie diesen Server löschen möchten? (J/N): ");
                        Console.ResetColor();
                        string bestaetigung = Console.ReadLine()?.ToUpper() ?? "";
                        if (bestaetigung == "Ja")
                        {
                            geräteListe.Remove(zuBearbeitenderPC);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("PC erfolgreich gelöscht!");
                            Console.ResetColor();
                            Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                            serviceCenter.GeräteSpeichern();
                            Console.ReadKey();
                            Hauptmenue.Show();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Löschvorgang abgebrochen.");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Auswahl!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void TabletBearbeiten(List<IGeraet> geräteListe, ServiceCenter serviceCenter)
        {
            // Alle Tablets filtern
            var tablets = geräteListe.OfType<Tablet>().ToList();

            if (tablets.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine Tablets vorhanden!");
                Console.ResetColor();
                Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
                return;
            }

            // Tablets anzeigen
            Console.Clear();
            Console.WriteLine("=== Verfügbare Tablets ===\n");
            foreach (var tablet in tablets)
            {
                Console.WriteLine($"[ID: {tablet.Id}] {tablet.Marke} {tablet.Modell} - Status: {tablet.TabletStatus}");
            }

            // ID eingeben
            Console.Write("\nGeben Sie die ID des zu bearbeitenden Tablets ein: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige ID!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Tablet finden
            var zuBearbeitendesTablet = tablets.FirstOrDefault(t => t.Id == id);
            if (zuBearbeitendesTablet == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tablet mit dieser ID nicht gefunden!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Bearbeitungsmenü
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Tablet bearbeiten ===\n");
                zuBearbeitendesTablet.AnzeigenDetails();
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("[1] Marke ändern");
                Console.WriteLine("[2] Modell ändern");
                Console.WriteLine("[3] Prozessor ändern");
                Console.WriteLine("[4] RAM ändern");
                Console.WriteLine("[5] Speicherplatz ändern");
                Console.WriteLine("[6] Status ändern");
                Console.WriteLine("[7] Zurück");
                Console.WriteLine("[8] Löschen");
                Console.WriteLine("---------------------------");
                Console.Write("Ihre Wahl: ");

                if (!int.TryParse(Console.ReadLine(), out int wahl))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }

                switch (wahl)
                {
                    case 1:
                        Console.Write("Neue Marke eingeben: ");
                        string neueMarke = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neueMarke))
                        {
                            zuBearbeitendesTablet.Marke = neueMarke;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Marke erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Neues Modell eingeben: ");
                        string neuesModell = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuesModell))
                        {
                            zuBearbeitendesTablet.Modell = neuesModell;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Modell erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Neuer Prozessor eingeben: ");
                        string neuerProzessor = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuerProzessor))
                        {
                            zuBearbeitendesTablet.Prozessor = neuerProzessor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Prozessor erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Neuer RAM in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerRam) && neuerRam > 0)
                        {
                            zuBearbeitendesTablet.RAM = neuerRam;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RAM erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Write("Neuer Speicherplatz in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerSpeicher) && neuerSpeicher > 0)
                        {
                            zuBearbeitendesTablet.Speicherplatz = neuerSpeicher;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Speicherplatz erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\nNeuen Status wählen:");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Ihre Wahl: ");
                        if (int.TryParse(Console.ReadLine(), out int statusWahl) && statusWahl >= 1 && statusWahl <= 4)
                        {
                            zuBearbeitendesTablet.TabletStatus = statusWahl switch
                            {
                                1 => IGeraet.Status.Aktiv,
                                2 => IGeraet.Status.Inaktiv,
                                3 => IGeraet.Status.Defekt,
                                4 => IGeraet.Status.Bestand,
                                _ => zuBearbeitendesTablet.TabletStatus
                            };
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Status erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("Änderungen werden gespeichert...");
                        serviceCenter.GeräteSpeichern();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Erfolgreich gespeichert!");
                        Console.ResetColor();
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren...");
                        Console.ReadKey();
                        Console.Clear();
                        Hauptmenue.Show();
                        return;
                    case 8:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("\nSind Sie sicher, dass Sie diesen Server löschen möchten? (J/N): ");
                            Console.ResetColor();
                            string bestaetigung = Console.ReadLine()?.ToUpper() ?? "";
                            if (bestaetigung == "Ja")
                            {
                                geräteListe.Remove(zuBearbeitendesTablet);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Tablet erfolgreich gelöscht!");
                                Console.ResetColor();
                                Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                                serviceCenter.GeräteSpeichern();
                                Console.ReadKey();
                                Hauptmenue.Show();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Löschvorgang abgebrochen.");
                                Console.ReadKey();
                            } break;
                        }

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Auswahl!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ServerBearbeiten(List<IGeraet> geräteListe, ServiceCenter serviceCenter)
        {
            // Alle Server filtern
            var servers = geräteListe.OfType<Server>().ToList();

            if (servers.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine Server vorhanden!");
                Console.ResetColor();
                Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
                return;
            }

            // Server anzeigen
            Console.Clear();
            Console.WriteLine("=== Verfügbare Server ===\n");
            foreach (var server in servers)
            {
                Console.WriteLine($"[ID: {server.Id}] {server.Marke} {server.Modell} - Status: {server.ServerStatus}");
            }

            // ID eingeben
            Console.Write("\nGeben Sie die ID des zu bearbeitenden Servers ein: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige ID!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Server finden
            var zuBearbeitenderServer = servers.FirstOrDefault(s => s.Id == id);
            if (zuBearbeitenderServer == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Server mit dieser ID nicht gefunden!");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            // Bearbeitungsmenü
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Server bearbeiten ===\n");
                zuBearbeitenderServer.AnzeigenDetails();
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("[1] Marke ändern");
                Console.WriteLine("[2] Modell ändern");
                Console.WriteLine("[3] Prozessor ändern");
                Console.WriteLine("[4] RAM ändern");
                Console.WriteLine("[5] Speicherplatz ändern");
                Console.WriteLine("[6] Status ändern");
                Console.WriteLine("[7] Zurück");
                Console.WriteLine("[8] Löschen");
                Console.WriteLine("---------------------------");
                Console.Write("Ihre Wahl: ");

                if (!int.TryParse(Console.ReadLine(), out int wahl))
                {
                    Console.WriteLine("Ungültige Eingabe!");
                    Console.ReadKey();
                    continue;
                }

                switch (wahl)
                {
                    case 1:
                        Console.Write("Neue Marke eingeben: ");
                        string neueMarke = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neueMarke))
                        {
                            zuBearbeitenderServer.Marke = neueMarke;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Marke erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Neues Modell eingeben: ");
                        string neuesModell = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuesModell))
                        {
                            zuBearbeitenderServer.Modell = neuesModell;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Modell erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Neuer Prozessor eingeben: ");
                        string neuerProzessor = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(neuerProzessor))
                        {
                            zuBearbeitenderServer.Prozessor = neuerProzessor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Prozessor erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Neuer RAM in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerRam) && neuerRam > 0)
                        {
                            zuBearbeitenderServer.RAM = neuerRam;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RAM erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Write("Neuer Speicherplatz in GB eingeben: ");
                        if (int.TryParse(Console.ReadLine(), out int neuerSpeicher) && neuerSpeicher > 0)
                        {
                            zuBearbeitenderServer.Speicherplatz = neuerSpeicher;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Speicherplatz erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\nNeuen Status wählen:");
                        Console.WriteLine("[1] Aktiv");
                        Console.WriteLine("[2] Inaktiv");
                        Console.WriteLine("[3] Defekt");
                        Console.WriteLine("[4] Bestand");
                        Console.Write("Ihre Wahl: ");
                        if (int.TryParse(Console.ReadLine(), out int statusWahl) && statusWahl >= 1 && statusWahl <= 4)
                        {
                            zuBearbeitenderServer.ServerStatus = statusWahl switch
                            {
                                1 => IGeraet.Status.Aktiv,
                                2 => IGeraet.Status.Inaktiv,
                                3 => IGeraet.Status.Defekt,
                                4 => IGeraet.Status.Bestand,
                                _ => zuBearbeitenderServer.ServerStatus
                            };
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Status erfolgreich geändert!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe!");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("Änderungen werden gespeichert...");
                        serviceCenter.GeräteSpeichern();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Erfolgreich gespeichert!");
                        Console.ResetColor();
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um zum Hauptmenü zurückzukehren...");
                        Console.ReadKey();
                        Console.Clear();
                        Hauptmenue.Show();
                        return;
                      
                            case 8:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nSind Sie sicher, dass Sie diesen Server löschen möchten? (J/N): ");
                                Console.ResetColor();
                                string bestaetigung = Console.ReadLine()?.ToUpper() ?? "";
                                if (bestaetigung == "Ja")
                                {
                                    geräteListe.Remove(zuBearbeitenderServer);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Server erfolgreich gelöscht!");
                                    Console.ResetColor();
                                    Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                                    serviceCenter.GeräteSpeichern();
                                    Console.ReadKey();
                                    Hauptmenue.Show();
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Löschvorgang abgebrochen.");
                                    Console.ReadKey();
                                }
                                break;
                            

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Auswahl!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
