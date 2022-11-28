using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class ZlecenieForAllView
    {
        public int Id { get; set; }
        public string Pracownik { get; set; }
        public string Usluga { get; set; }
        public string Adres { get; set; }
        public int? Faktura { get; set; }
        public DateTime Data { get; set; }
    }
}
