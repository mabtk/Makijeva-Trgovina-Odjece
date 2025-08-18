using ConsoleApp4.Proizvodi;
using ConsoleApp4.CijenaProizvoda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp4.Ugovor;

namespace ConsoleApp4.Proizvodi
{
    public abstract class Proizvodi : IProdaja, IProizvodi
    {
        private int idProizvoda;
        private string imeProizvoda;
        private string? opisProizvoda;
        private Cijena cijenaProizvoda;
        private TipProizvoda tipProizvoda;
        public int kolicinaProizvoda;
        private static int maksimalnaKolicinaProizvoda = 50;
        private static int minimalnaKolicinaProizvoda = 10;

        public int IdProizvoda
        {
            get { return idProizvoda; }
            set { idProizvoda = value; }
        }
        public string ImeProizvoda
        {
            get { return imeProizvoda; }
            set { imeProizvoda = value; }
        }
        public string? OpisProizvoda
        {
            get { return opisProizvoda; }
            set { opisProizvoda = value; }
        }
        public Cijena CijenaProizvoda { get; set; }
        public TipProizvoda TipProizvoda
        {
            get { return tipProizvoda; }
            set { tipProizvoda = value; }
        }
        public int KolicinaProizvoda
        {
            get { return kolicinaProizvoda; }
            set { kolicinaProizvoda = value; }
        }
        public int MaksimalnaKolicinaProizvoda
        {
            get { return maksimalnaKolicinaProizvoda; }
            set { maksimalnaKolicinaProizvoda = value; }
        }
        public int MinimalnaKolicinaProizvoda
        {
            get { return minimalnaKolicinaProizvoda; }
            set { minimalnaKolicinaProizvoda = value; }
        }

        public Proizvodi(int idProizvoda, string imeProizvoda, string? opisProizvoda, Cijena cijenaProizvoda, TipProizvoda tipProizvoda, int kolicinaProizvoda)
        {
            this.idProizvoda = idProizvoda;
            this.imeProizvoda = imeProizvoda;
            this.opisProizvoda = opisProizvoda;
            this.cijenaProizvoda = cijenaProizvoda;
            this.tipProizvoda = tipProizvoda;
            this.kolicinaProizvoda = kolicinaProizvoda;
        }

        public virtual void KratkiOpisProizvoda()
        {
            Console.WriteLine($"Ime proizvoda - {imeProizvoda}\nKoličina proizvoda - {kolicinaProizvoda}\n");
            Console.WriteLine("-----------------------------------");
        }

        public virtual void DugiOpisProizvoda()
        {
            Console.WriteLine($"Ime proizvoda - {imeProizvoda}\nID proizvoda - {idProizvoda}\nOpis proizvoda - {opisProizvoda}\nTip proizvoda - {tipProizvoda}\nKoličina proizvoda - {kolicinaProizvoda}\nCijena proizvoda - {cijenaProizvoda}\nMaksimalan broj proizvoda - {maksimalnaKolicinaProizvoda}\nMinimialan broj proizvoda - {minimalnaKolicinaProizvoda}");
            Console.WriteLine("-----------------------------------");
        }

        public virtual void TestProizvoda()
        {
            Console.WriteLine("Ovaj proizvod je testiran");
        }
        public int NadopunaProizvoda()
        {
            if (kolicinaProizvoda >= maksimalnaKolicinaProizvoda)
            {
                Console.WriteLine("Količina proizvoda je već na maksimalnoj količini. Ne možete nadopunjavati vaš inventar.");
                return kolicinaProizvoda;
            }
            else
            {
                Console.WriteLine("Koliko proizvoda želite dodati?");
                int dodaniProizvodi = int.Parse(Console.ReadLine());
                kolicinaProizvoda += dodaniProizvodi;

                if (kolicinaProizvoda > maksimalnaKolicinaProizvoda)
                {
                    Console.WriteLine("Nadopunjena količina proizvoda je iznad maksimalne količine. Ne smijete dalje nadopunjavati vaš inventar vaš invetar.");
                    return kolicinaProizvoda;
                }
                else
                {
                    Console.WriteLine("Vaš je inventar uspješno nadopunjen.");
                    return kolicinaProizvoda;
                }
            }

        }

        public virtual int ProdajaProizvoda()
        {
            if (kolicinaProizvoda <= minimalnaKolicinaProizvoda)
            {
                Console.WriteLine("Količina proizvoda je ispod minimalne količine. Ne možete prodavati vaš inventar.");
                return kolicinaProizvoda;
            }
            else
            {
                Console.WriteLine("Koliko ste proizvoda prodali?");
                int prodaniProizvodi = int.Parse(Console.ReadLine());

                if (kolicinaProizvoda < minimalnaKolicinaProizvoda)
                {
                    Console.WriteLine("Količina proizvoda je ispod minimalne količine. Ne smijete dalje trošiti vaš inventar.");
                }
                kolicinaProizvoda -= prodaniProizvodi;
                return kolicinaProizvoda;
            }
        }
    }
}