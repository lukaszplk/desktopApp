using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class FakturaForAllView
    {
        #region Properties
        public int? Numer { get; set; }
        public DateTime TerminPlatnosci { get; set; }
        public string Klient { get; set; }
        public string Pracownik { get; set; }
        public int Kwota { get; set; }
        public string SposobPlatnosci { get; set; }
        #endregion
    }
}
