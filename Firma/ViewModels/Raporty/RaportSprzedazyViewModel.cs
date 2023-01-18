using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Raporty
{
    public class RaportSprzedazyViewModel : RaportBaseViewModel
    {
        public RaportSprzedazyViewModel():base("Raport sprzedazy")
        {
            
        }

        public override decimal RunRaport()
        {
            throw new NotImplementedException();
        }
    }
}
