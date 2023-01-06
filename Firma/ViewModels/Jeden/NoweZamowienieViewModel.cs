using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NoweZamowienieViewModel : JedenViewModel
    {
        public NoweZamowienieViewModel() : base("Nowe zamowienie")
        {
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
