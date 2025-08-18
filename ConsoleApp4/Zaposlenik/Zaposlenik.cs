using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Zaposlenik
{
    public abstract class Zaposlenik
    {
        public string imeZaposlenika;
        public string prezimeZaposlenika;
        public int godineZaposlenika;
        PolozajiRadnika polozajRadnika;

        public Zaposlenik(string imeZaposlenika, string prezimeZaposlenika, int godineZaposlenika, PolozajiRadnika polozajRadnika)
        {
            this.imeZaposlenika = imeZaposlenika;
            this.polozajRadnika = polozajRadnika;
            this.godineZaposlenika = godineZaposlenika;
            this.polozajRadnika = polozajRadnika;
        }
    }
}
