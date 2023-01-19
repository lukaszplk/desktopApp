using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieFakturyViewModel : collectionViewModel<FakturaForAllView>
    {
        #region Konstruktor
        public WszystkieFakturyViewModel()
            :base("Wszystkie faktury")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj fakture");
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
            ListCopy = new List<FakturaForAllView>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Numer","Klient","Pracownik" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<FakturaForAllView>
                        (descending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
                case "Klient":
                    List = new ObservableCollection<FakturaForAllView>
                        (descending ? List.OrderByDescending(item => item.Klient) : List.OrderBy(item => item.Klient));
                    break;
                case "Pracownik":
                    List = new ObservableCollection<FakturaForAllView>
                        (descending ? List.OrderByDescending(item => item.Pracownik) : List.OrderBy(item => item.Pracownik));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Numer", "Klient", "Pracownik" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Numer":
                    List = new ObservableCollection<FakturaForAllView>(ListCopy.Where(item => item.Numer == Int32.Parse(SearchText)));
                    break;
                case "Klient":
                    List = new ObservableCollection<FakturaForAllView>(ListCopy.Where(item => item.Klient == SearchText));
                    break;
                case "Pracownik":
                    List = new ObservableCollection<FakturaForAllView>(ListCopy.Where(item => item.Pracownik == SearchText));
                    break;
            }

        }

        public override void Usun()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
