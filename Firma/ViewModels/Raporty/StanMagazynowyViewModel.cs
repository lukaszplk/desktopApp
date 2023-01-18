using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Raporty
{
    internal class StanMagazynowyViewModel : RaportBaseViewModel
    {
        public StanMagazynowyViewModel():base("Stan magazynowy")
        {
            
        }

        public override decimal RunRaport()
        {
            throw new NotImplementedException();
        }
    }
}
