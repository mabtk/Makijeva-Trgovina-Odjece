using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Naručivanje
{
    internal class Narudžba
    {
        public int idNarudžbe { get; private set; }
        public DateTime datumNarudžbe { get; private set; }
        public List<NaručeneStvari> naručeneStvari { get; private set; }

        public void NarudžbaRobe()
        {
            idNarudžbe = new Random().Next(1000, 9999);
            datumNarudžbe = DateTime.Now;
            naručeneStvari = new List<NaručeneStvari>();
        }

    }
}
