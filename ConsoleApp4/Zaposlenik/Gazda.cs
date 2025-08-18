using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Zaposlenik
{
    public sealed class Gazda : Zaposlenik
    {
        public Gazda(string imeZaposlenika, string prezimeZaposlenika, int godineZaposlenika, PolozajiRadnika polozajRadnika) : base(imeZaposlenika, prezimeZaposlenika, godineZaposlenika, polozajRadnika)
        {
        }
    }
}
