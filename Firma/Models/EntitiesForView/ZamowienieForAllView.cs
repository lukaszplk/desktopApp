using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class ZamowienieForAllView
    {
        public int Id { get; set; }
        public string Towar { get; set; }
        public string Pracownik { get; set; }
        public DateTime Data { get; set; }
        public decimal? Wartosc { get; set; }
    }
}
