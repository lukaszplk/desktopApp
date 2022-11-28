using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class RabatyForAllView
    {
        #region Properties
        public string Nazwa { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public string Kto { get; set; }
        public string Opis { get; set; }
        public int Poziom { get; set; }
        #endregion
    }
}
