using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class KlientForAllView
    {
        #region Properties
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Miejscowosc { get; set; }
        public string Firma { get; set; }
        #endregion
    }
}
