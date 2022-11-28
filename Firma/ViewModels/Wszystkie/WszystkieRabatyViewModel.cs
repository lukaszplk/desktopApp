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
    public class WszystkieRabatyViewModel : collectionViewModel<RabatyForAllView>
    {
        public WszystkieRabatyViewModel()
           : base("Wszystkie rabaty")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<RabatyForAllView>
                (
                    from item in fakturaEntities.Rabat
                    where item.czyAktywny == true
                    select new RabatyForAllView
                    {
                        Nazwa = item.nazwaRabatu,
                        DataUtworzenia = item.dataUtworzenia,
                        Kto = item.Pracownik.imie + " " + item.Pracownik.nazwisko,
                        Opis = item.zaCoNalezny,
                        Poziom = item.poziomRabatu
                    }

                );
        }
    }
}
