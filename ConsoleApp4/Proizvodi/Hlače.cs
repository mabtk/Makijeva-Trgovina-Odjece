using ConsoleApp4.CijenaProizvoda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Proizvodi
{
    public class Hlače : Proizvodi
    {
        public static int velicinaHlaca = 28;
        public Hlače(int idProizvoda, string imeProizvoda, string? opisProizvoda, Cijena cijenaProizvoda, TipProizvoda tipProizvoda, int kolicinaProizvoda) : base(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicinaProizvoda)
        {
        }
        public override void DugiOpisProizvoda()
        {
            base.DugiOpisProizvoda();
            Console.WriteLine($"Veličina hlača - {velicinaHlaca}");
        }
    }
}
