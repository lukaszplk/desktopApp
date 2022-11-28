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
    public class WszystkieFakturyViewModel : collectionViewModel<FakturaForAllView>
    {
        #region Konstruktor
        public WszystkieFakturyViewModel()
            :base("Wszystkie faktury")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                    from item in fakturaEntities.Faktura
                    where item.czyAktywna == true
                    select new FakturaForAllView
                    {
                        Numer = item.numer,
                        TerminPlatnosci = item.terminPlatnosci,
                        Klient = item.Klient1.imie + " " + item.Klient1.nazwisko,
                        Pracownik = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                        Kwota = item.kwotaFaktury,
                        SposobPlatnosci = item.SposobPlatnosci1.nazwa
                    }

                );
        }
        #endregion
    }
}
