using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class MagazynLogic : DatabaseClass
    {
        public List<StanMagazynowyForView> List;
        public List<Magazyn> ListMagazyn;
        private bool inStock;
        private projektEntities db;
        public MagazynLogic(projektEntities db) : base(db)
        {
            this.db = db;
            
            ListMagazyn = (from magazyn in this.db.Magazyn where magazyn.czyAktywne == true select magazyn).ToList();
            
            
        }

        public List<StanMagazynowyForView> StanMagazynowy()
        {
            List = new List<StanMagazynowyForView>();
            foreach (Magazyn towarMagazyn in ListMagazyn)
            {
                inStock = false;
                foreach (StanMagazynowyForView towarDisplay in List)
                {
                    Console.WriteLine("asd");
                    if (towarDisplay.Same(towarMagazyn))
                    {
                        towarDisplay.Add(towarMagazyn);
                        inStock = true;
                        break;
                    }
                }
                if (!inStock)
                {
                    List.Add(StanMagazynowyForView.Copy(towarMagazyn, this.db));
                }

            }
            return List;
        }
    }
}
