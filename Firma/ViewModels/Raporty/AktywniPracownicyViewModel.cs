using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.BusinessLogic;
using Firma.Models.Entities;

namespace Firma.ViewModels.Raporty
{
    public class AktywniPracownicyViewModel: RaportBaseViewModel
    {
        public projektEntities Db { get; set; }
        private PracownikLogic logic;
        public AktywniPracownicyViewModel():base("Aktywni pracownicy")
        {
            
            logic = new PracownikLogic(new projektEntities());
            
        }

        public override decimal RunRaport()
        {
            logic.Od = Od;
            logic.Do = Do;
            Result = logic.AktywniPracownicy();
            return Result;
        }
    }
}
