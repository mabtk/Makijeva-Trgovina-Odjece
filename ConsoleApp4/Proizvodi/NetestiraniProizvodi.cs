using ConsoleApp4.CijenaProizvoda;
using ConsoleApp4.Ugovor;
using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Proizvodi
{
    public class NetestiraniProizvodi : Proizvodi, IProizvodi, IProdaja
    {
        public override void TestProizvoda()
        {
            Console.WriteLine("Ovaj proizvod je ne testiran.");
        }
        public NetestiraniProizvodi(int idProizvoda, string imeProizvoda, string? opisProizvoda, Cijena cijenaProizvoda, TipProizvoda tipProizvoda, int kolicinaProizvoda) : base(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicinaProizvoda)
        {
        }
        
        public override int ProdajaProizvoda()
        {
            Console.WriteLine("Ne možete prodati ne testirane proizvode.");
            return 0;
        }
    }
}
