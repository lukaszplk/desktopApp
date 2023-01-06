using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.EntitiesForView;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieZamowieniaViewModel: collectionViewModel<ZamowienieForAllView>
    {
        #region Konstruktor
        public WszystkieZamowieniaViewModel()
            : base("Wszystkie zamowienia")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj zamowienie");
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowienieForAllView>
                (
                    from item in fakturaEntities.Zamowienia
                    where item.czyAktywne == true
                    select new ZamowienieForAllView
                    {
                        Id = item.idZamowienia,
                        Towar = item.Towar1.nazwa,
                        Pracownik = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                        Data = item.dataZamowienia,
                        Wartosc = item.wartoscZamowienia
                    }

                );
        }
        #endregion
    }
}
