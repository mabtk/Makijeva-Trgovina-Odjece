using ConsoleApp4.CijenaProizvoda;
using ConsoleApp4.Proizvodi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4.Zaposlenik
{
    public class UčitavanjeRadnika
    {
        string putanja = "C:\\Users\\Marko Rakic\\Desktop\\SpisakRadnika.txt";
        bool postoji = File.Exists("C:\\Users\\Marko Rakic\\Desktop\\SpisakRadnika.txt");
        List<Zaposlenik> spisakRadnika = new List<Zaposlenik>();
        public List<Zaposlenik> UčitajRadnike()
        {
            spisakRadnika.Clear();
            if (postoji)
            {
                string[] linije = File.ReadAllLines(putanja);
                foreach (string linija in linije)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(linija))
                        {
                            continue;
                        }

                        string[] dijelovi = linija.Split(';');

                        if (dijelovi.Length != 4)
                        {
                            Console.WriteLine($"Neispravan format linije: {linija}");
                            continue;
                        }

                        string imeZaposlenika = dijelovi[0];
                        string prezimeZaposlenika = dijelovi[1];
                        int godineZaposlenika = int.Parse(dijelovi[2]);

                        if (!Enum.TryParse(dijelovi[3], out PolozajiRadnika polozajZaposlenika))
                        {
                            Console.WriteLine($"Neispravna vrijednost cijene u liniji: {linija}");
                            continue;
                        }

                        Zaposlenik zaposlenik;

                        switch (polozajZaposlenika)
                        {
                            case PolozajiRadnika.Radnik:
                                zaposlenik = new Radnik(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, polozajZaposlenika);
                                break;
                            case PolozajiRadnika.Menadžer:
                                zaposlenik = new Menadžer(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, polozajZaposlenika);
                                break;
                            default:
                                zaposlenik = new Gazda(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, polozajZaposlenika);
                                break;
                        }

                        spisakRadnika.Add(zaposlenik);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Greška pri čitanju linije: {linija}. Detalji: {ex.Message}");
                    }
                }
            }
            else
            {
                using FileStream fs = File.Create(putanja);
                Console.WriteLine("Kreirana je nova datoteka jer prethodna nije postojala.");
            }
            return spisakRadnika;
        }

        public void LogIn()
        {
            bool b = true;
            Console.WriteLine("Unesite vaše ime");
            string loginIme = Console.ReadLine();

            //Potrebno znanje iz LINQ za ovo. Ucitavanje radnika iz filea, te logiranje prema infomacijama koje se nalaze u tom fileu.
        }
    }
}
