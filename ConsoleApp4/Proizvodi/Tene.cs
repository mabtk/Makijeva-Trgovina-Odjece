using ConsoleApp4.CijenaProizvoda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Proizvodi
{
<<<<<<< HEAD
    public class Tene : Proizvod
=======
    public class Tene : Proizvodi
>>>>>>> 7aeb7d6979d2cdf38f2459efe2b3a3860176b4c7
    {
        public Tene(int idProizvoda, string imeProizvoda, string? opisProizvoda, Cijena cijenaProizvoda, TipProizvoda tipProizvoda, int kolicinaProizvoda) : base(idProizvoda, imeProizvoda, opisProizvoda, cijenaProizvoda, tipProizvoda, kolicinaProizvoda)
        {
        }

        public static int velicinaTena = 42;

        public override void DugiOpisProizvoda()
        {
            base.DugiOpisProizvoda();
            Console.WriteLine($"Veličina tena - {velicinaTena}");
        }
    }
}
