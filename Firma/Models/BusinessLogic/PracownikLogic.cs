using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class PracownikLogic:DatabaseClass
    {
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        

        public PracownikLogic(projektEntities db) : base(db)
        {

        }

        public int AktywniPracownicy()
        {
            return Db.Pracownik.Where(item => item.czyAktywny == true 
                && item.dataZatrudnienia >= Od
                && item.dataZatrudnienia <= Do)
                .Count();
                //Sum(item => (item.wartoscTowaru ?? 0) + (item.wartoscTowaru ?? 0));
        }
    }
}
