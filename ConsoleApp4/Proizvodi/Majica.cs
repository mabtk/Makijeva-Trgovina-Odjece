using ConsoleApp4.CijenaProizvoda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Proizvodi
{
<<<<<<< HEAD
    public class Majica : Proizvod
=======
    public class Majica : Proizvodi
>>>>>>> 7aeb7d6979d2cdf38f2459efe2b3a3860176b4c7
    {
        public static string velicinaMajice = "L";
        public Majica(int idProizvoda, string imeProizvoda, string? opisProizvoda, Cijena cijenaProizvoda, TipProizvoda tipProizvoda, int kolicinaProizvoda) : base(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicinaProizvoda)
        {
        }

        public override void DugiOpisProizvoda()
        {
            base.DugiOpisProizvoda();
            Console.WriteLine($"Veličina majice - {velicinaMajice}");
        }
    }
}
