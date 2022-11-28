using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class MagazynForAllView
    {
        #region Properties
        public string Towar { get; set; }
        public int? Ilosc { get; set; }
        public DateTime OstatnieZamowienie { get; set; }
        public decimal? Wartosc { get; set; }
        #endregion
    }
}
