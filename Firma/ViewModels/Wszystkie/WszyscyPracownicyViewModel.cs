using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;

namespace Firma.ViewModels.Wszystkie
{
    public class WszyscyPracownicyViewModel : collectionViewModel<PracownikForAllView>
    {
        public WszyscyPracownicyViewModel()
            :base("Wszyscy pracownicy")
        {

        }

        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                    from item in fakturaEntities.Pracownik
                    where item.czyAktywny == true
                    select new PracownikForAllView
                    {
                        Imie = item.imie,
                        Nazwisko = item.nazwisko,
                        Stanowisko = item.Stanowisko1.nazwaStanowiska,
                        Adres = item.Adres1.ulica + " " + item.Adres1.dom + "\n"
                        + item.Adres1.kodPocztowy + ", " + item.Adres1.miasto,
                        DataZatrudnienia = item.dataZatrudnienia

                    }

                );
        }
    }
}
