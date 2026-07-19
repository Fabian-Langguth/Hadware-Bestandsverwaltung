using Hadware_Bestandsverwaltung.Klassen;
using Hadware_Bestandsverwaltung.Service_Center;
using Hadware_Bestandsverwaltung.Menü;
using Hadware_Bestandsverwaltung.Interface;


Hauptmenue.Show();
ServiceCenter serviceCenter = new ServiceCenter();

// Beim Start laden
serviceCenter.GeräteLaden();

while (true)
{
    if (int.TryParse(Console.ReadLine(), out int auswahl) == false)
    {
        Console.WriteLine("Ungültige Eingabe. Bitte erneut eine Zahl zwischen 1 und 7 eingeben.");
        continue;
    }
    switch (auswahl)
    {
        case 1:
            {
                Laptop? neuerLaptop = ServiceCenter.Laptophinzufügen();
                if (neuerLaptop != null)
                {
                    // Speichern des neuen Laptops im ServiceCenter
                    serviceCenter.GetAlleGeräte().Add(neuerLaptop);
                    serviceCenter.GeräteSpeichern();
                    Console.WriteLine("Laptop wurde gespeichert!");
                }
                Hauptmenue.Show();
                break;
            }
        case 2:
            {
                PC? neuerPC = ServiceCenter.PChinzufügen();
                if (neuerPC != null)
                {
                    // Speichern des neuen PCs im ServiceCenter
                    serviceCenter.GetAlleGeräte().Add(neuerPC);
                    serviceCenter.GeräteSpeichern();
                    Console.WriteLine("PC wurde gespeichert!");
                }
                Hauptmenue.Show();
                break;
            }

        case 3:
            {
                Server? neuerServer = ServiceCenter.Serverhinzufügen();
                if (neuerServer != null)
                {
                    // Speichern des neuen Servers im ServiceCenter
                    serviceCenter.GetAlleGeräte().Add(neuerServer);
                    serviceCenter.GeräteSpeichern();
                    Console.WriteLine("Server wurde gespeichert!");
                }
                Hauptmenue.Show();
                break;
            }
        case 4:
            {
                Tablet? neuerTablet = ServiceCenter.Tablethinzufügen();
                if (neuerTablet != null)
                {
                    // Speichern des neuen Tablets im ServiceCenter
                    serviceCenter.GetAlleGeräte().Add(neuerTablet);
                    serviceCenter.GeräteSpeichern();
                    Console.WriteLine("Tablet wurde gespeichert!");
                }
                Hauptmenue.Show();
                break;
            }
        case 5:
            {
                BearbeitenMenue.Show(serviceCenter.GetAlleGeräte(), serviceCenter); // serviceCenter übergeben
                break;
            }
        case 6:
            {
                
                serviceCenter.AlleGeräteAnzeigen();
                Hauptmenue.Show();
                break;
            }
        case 7:
            {
                Console.WriteLine("Programm wird beendet...");
                serviceCenter.GeräteSpeichern();
                Environment.Exit(0);
                break;
            }
    }
}
