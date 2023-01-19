using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class PracownikForAllView
    {
        #region Properties
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Stanowisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        #endregion
    }
}
