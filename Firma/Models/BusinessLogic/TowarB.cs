using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class TowarB:DatabaseClass
    {
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public Towar towar { get; set; }

        public TowarB(projektEntities db):base(db)
        {

        }

        public decimal ObliczUtarg()
        {
            return Db.Magazyn.Where(item=> item.towar==towar.idTowaru && item.ostatnieZamowienie<=1).
                Sum(item=>(item.wartoscTowaru??0)+(item.wartoscTowaru??0));
        }
    }
}
