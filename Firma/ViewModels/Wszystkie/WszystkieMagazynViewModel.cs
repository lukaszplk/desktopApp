using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieMagazynViewModel : collectionViewModel<MagazynForAllView>
    {
        public WszystkieMagazynViewModel()
            : base("Magazyn")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<MagazynForAllView>
                (
                    from item in fakturaEntities.Magazyn
                    where item.czyAktywne == true
                    select new MagazynForAllView
                    {
                        Towar = item.Towar1.nazwa,
                        Ilosc = item.ilosc,
                        OstatnieZamowienie = item.Zamowienia.dataZamowienia,
                        Wartosc = item.wartoscTowaru
                    }

                );
        }
    }
}
