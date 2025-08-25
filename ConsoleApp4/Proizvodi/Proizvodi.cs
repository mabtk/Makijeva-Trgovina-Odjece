using ConsoleApp4.Proizvodi;
using ConsoleApp4.CijenaProizvoda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp4.Ugovor;
using System.ComponentModel;

namespace ConsoleApp4.Proizvodi
{
    public class Proizvodi : IProdaja, IProizvodi
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

        public Proizvodi() { }

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
            }
            else
            {
                Console.WriteLine("Koliko proizvoda želite dodati?");
                int dodaniProizvodi = 0;
               
                if (!int.TryParse(Console.ReadLine(), out dodaniProizvodi))
                {
                    Console.WriteLine("Molimo upišite točnu vrijednost");
                }
                else
                {

                    kolicinaProizvoda += dodaniProizvodi;

                    if (kolicinaProizvoda > maksimalnaKolicinaProizvoda)
                    {
                        Console.WriteLine("Nadopunjena količina proizvoda je iznad maksimalne količine. Ne smijete dalje nadopunjavati vaš inventar vaš invetar.");
                    }
                    else
                    {
                        Console.WriteLine("Vaš je inventar uspješno nadopunjen.");
                    }
                }
            }
            return kolicinaProizvoda;

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

        public static List<Proizvodi> SortiranjeProizvoda()
        {
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvodi> proizvodi = učitavanje.UčitajProizvode();
            proizvodi = (from proizvod in proizvodi
                         orderby proizvod.imeProizvoda
                         select proizvod).ToList();
            return proizvodi;

        }

        public static List<Proizvodi> Filtriranje()
        {
            
            Console.WriteLine("Pretražite proizvod");
            string filter = Console.ReadLine();
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvodi> proizvodi = učitavanje.UčitajProizvode();
            proizvodi = (from proizvod in proizvodi
                         where proizvod.imeProizvoda.ToLower().Contains(filter.ToLower())
                         select proizvod
                         ).Distinct().ToList();
            return proizvodi;
        }
        public static List<TipProizvoda> TipoviProizvoda()
        {
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvodi> proizvodi = učitavanje.UčitajProizvode();
            List<TipProizvoda> tipoviProizvoda = (from proizvod in proizvodi
                                          select proizvod.tipProizvoda).Distinct().ToList();
            return tipoviProizvoda;
        }

        public static List<Proizvodi[]> ChunkMetoda()
        {
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvodi> proizvodi = učitavanje.UčitajProizvode();
            List<Proizvodi[]> tipoviProizvoda = (from proizvod in proizvodi
                                                  select proizvod).Chunk(5).ToList();
            return tipoviProizvoda;
        }

        public static bool AllMetoda()
        {
            bool allMetoda = false;
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvodi> proizvodi = učitavanje.UčitajProizvode();
            allMetoda = (from proizvod in proizvodi select proizvod)
                        .All(proizvod => proizvod.kolicinaProizvoda > 1);
            return allMetoda;
        }
    }
}