using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class UrlopForAllView
    {
        #region Properties
            public int IdUrlopu { get; set; }
            public string Pracownik { get; set; }
            public string Zatwierdzajacy { get; set; }
            public DateTime DataRozpoczecia { get; set; }
            public DateTime? DataZakonczenia { get; set; }
            public string Uzasadnienie { get; set; }
            public bool CzyZatwierdzony { get; set; }
            public bool CzyPlatny { get; set; }
        #endregion
    }
}
