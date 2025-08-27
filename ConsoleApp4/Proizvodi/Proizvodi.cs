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
    public class Proizvod : IProdaja, IProizvodi
    {
        public int idProizvoda;
        public string imeProizvoda;
        public string? opisProizvoda;
        public Cijena cijenaProizvoda;
        public TipProizvoda tipProizvoda;
        public int kolicinaProizvoda;
        public static int maksimalnaKolicinaProizvoda = 50;
        public static int minimalnaKolicinaProizvoda = 10;
        public double ukupnaCijena;

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
        public double UkupnaCijena
        {
            get { return ukupnaCijena; }
            set { ukupnaCijena = value; }
        }
        public Proizvod() { }

        public Proizvod(int idProizvoda, string imeProizvoda, string? opisProizvoda, Cijena cijenaProizvoda, TipProizvoda tipProizvoda, int kolicinaProizvoda)
        {
            IdProizvoda = idProizvoda;
            ImeProizvoda = imeProizvoda;
            OpisProizvoda = opisProizvoda;
            CijenaProizvoda = cijenaProizvoda;
            TipProizvoda = tipProizvoda;
            KolicinaProizvoda = kolicinaProizvoda;
        }

        public virtual void KratkiOpisProizvoda()
        {
            Console.WriteLine($"Ime proizvoda - {imeProizvoda}\nKoličina proizvoda - {kolicinaProizvoda}\n");
            Console.WriteLine("-----------------------------------");
        }

        public virtual void DugiOpisProizvoda()
        {
            Proizvod proizvod = new();
            List<Proizvod> listaSvihProizvoda = proizvod.ForEachMetodaTest();

            foreach (var p in listaSvihProizvoda)
            {
                Console.WriteLine($"Ime proizvoda - {p.ImeProizvoda}");
                Console.WriteLine($"ID proizvoda - {p.IdProizvoda}");
                Console.WriteLine($"Opis proizvoda - {p.OpisProizvoda}");
                Console.WriteLine($"Tip proizvoda - {p.TipProizvoda}");
                Console.WriteLine($"Količina proizvoda - {p.KolicinaProizvoda}");
                Console.WriteLine($"Jedinična cijena - {p.CijenaProizvoda}");
                Console.WriteLine($"Maksimalna količina - {p.MaksimalnaKolicinaProizvoda}");
                Console.WriteLine($"Minimalna količina - {p.MinimalnaKolicinaProizvoda}");
                Console.WriteLine($"Ukupna cijena skladišta - {p.UkupnaCijena}");
                Console.WriteLine("-----------------------------------");
            }
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

        public static List<Proizvod> SortiranjeProizvoda()
        {
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvod> proizvodi = učitavanje.UčitajProizvode();
            proizvodi = (from proizvod in proizvodi
                         orderby proizvod.imeProizvoda
                         select proizvod).ToList();
            return proizvodi;

        }

        public static List<Proizvod> Filtriranje()
        {
            
            Console.WriteLine("Pretražite proizvod");
            string filter = Console.ReadLine();
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvod> proizvodi = učitavanje.UčitajProizvode();
            proizvodi = (from proizvod in proizvodi
                         where proizvod.imeProizvoda.ToLower().Contains(filter.ToLower())
                         select proizvod
                         ).Distinct().ToList();
            return proizvodi;
        }
        public static List<TipProizvoda> TipoviProizvoda()
        {
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvod> proizvodi = učitavanje.UčitajProizvode();
            List<TipProizvoda> tipoviProizvoda = (from proizvod in proizvodi
                                          select proizvod.tipProizvoda).Distinct().ToList();
            return tipoviProizvoda;
        }

        public static List<Proizvod[]> ChunkMetoda()
        {
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvod> proizvodi = učitavanje.UčitajProizvode();
            List<Proizvod[]> tipoviProizvoda = (from proizvod in proizvodi
                                                  select proizvod).Chunk(5).ToList();
            return tipoviProizvoda;
        }

        public static bool AllMetoda()
        {
            bool allMetoda = false;
            UčitavanjeProizvoda učitavanje = new UčitavanjeProizvoda();
            List<Proizvod> proizvodi = učitavanje.UčitajProizvode();
            allMetoda = (from proizvod in proizvodi select proizvod)
                        .All(proizvod => proizvod.kolicinaProizvoda > 1);
            return allMetoda;
        }

        public static List<int> IntersectMetoda()
        {
            List<int> lista1 = new List<int>() { 1, 2, 3, 4, 5};
            List<int> lista2 = new List<int>() { 4, 5, 1 };
            List<int> intersectLista;
            intersectLista = lista1.Intersect(lista2).ToList();
            return intersectLista;
        }

        public static List<int> UnionMetoda()
        {
            List<int> lista1 = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> lista2 = new List<int>() { 4, 5, 1 };
            List<int> unionLista;
            unionLista = lista1.Union(lista2).ToList();
            return unionLista;
        }
        public static List<int> ConcatMetoda()
        {
            List<int> lista1 = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> lista2 = new List<int>() { 4, 5, 1 };
            List<int> concatLista;
            concatLista = lista1.Concat(lista2).ToList();
            return concatLista;
        }

        public List<Proizvod> ForEachMetodaTest()
        {
            UčitavanjeProizvoda ucitavanjeProizvoda = new UčitavanjeProizvoda();
            List<Proizvod> listaSvihProizvoda = ucitavanjeProizvoda.UčitajProizvode();
            (from proizvod in listaSvihProizvoda 
             let tmp = proizvod.ukupnaCijena = proizvod.KolicinaProizvoda * proizvod.CijenaProizvoda.CijenaProizvoda
             select proizvod).ToList();
            return listaSvihProizvoda;
        }
    }
}