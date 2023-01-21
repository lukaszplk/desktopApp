using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    class ZamowieniaLogic : DatabaseClass
    {
        public List<ZamowieniaRaportForView> List;
        public List<Zamowienia> ListZamowienia;
        private bool inStock;
        private decimal? total;
        private projektEntities db;
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public ZamowieniaLogic(projektEntities db) : base(db)
        {
            this.db = db;
        }

        public Tuple<List<ZamowieniaRaportForView>, decimal?> RaportZamowien()
        {
            total = 0;
            ListZamowienia = (from zamowienie in this.db.Zamowienia
                              where zamowienie.czyAktywne == true
                              && zamowienie.dataZamowienia >= Od
                              && zamowienie.dataZamowienia <= Do
                              select zamowienie).ToList();
            List = new List<ZamowieniaRaportForView>();
            foreach (Zamowienia towarZamowienie in ListZamowienia)
            {
                inStock = false;
                foreach (ZamowieniaRaportForView towarDisplay in List)
                {
                    
                    if (towarDisplay.Same(towarZamowienie))
                    {
                        towarDisplay.Add(towarZamowienie);
                        inStock = true;
                        break;
                    }
                }
                if (!inStock)
                {
                    List.Add(ZamowieniaRaportForView.Copy(towarZamowienie, this.db));
                }
                total += towarZamowienie.wartoscZamowienia;

            }
            return Tuple.Create(List, total);
        }

    }
}
