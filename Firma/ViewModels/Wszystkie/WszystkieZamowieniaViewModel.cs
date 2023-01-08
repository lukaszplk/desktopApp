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
            ListCopy = new List<ZamowienieForAllView>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Towar","Pracownik","Data","Wartosc" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Towar":
                    List = new ObservableCollection<ZamowienieForAllView>
                        (descending ? List.OrderByDescending(item => item.Towar) : List.OrderBy(item => item.Towar));
                    break;
                case "Pracownik":
                    List = new ObservableCollection<ZamowienieForAllView>
                        (descending ? List.OrderByDescending(item => item.Pracownik) : List.OrderBy(item => item.Pracownik));
                    break;
                case "Data":
                    List = new ObservableCollection<ZamowienieForAllView>
                        (descending ? List.OrderByDescending(item => item.Data) : List.OrderBy(item => item.Data));
                    break;
                case "Wartosc":
                    List = new ObservableCollection<ZamowienieForAllView>
                        (descending ? List.OrderByDescending(item => item.Wartosc) : List.OrderBy(item => item.Wartosc));
                    break;
                
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Id","Pracownik","Towar" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Id":
                    List = new ObservableCollection<ZamowienieForAllView>(ListCopy.Where(item => item.Id == Int32.Parse(SearchText)));
                    break;
                case "Pracownik":
                    List = new ObservableCollection<ZamowienieForAllView>(ListCopy.Where(item => item.Pracownik == SearchText));
                    break;
                case "Towar":
                    List = new ObservableCollection<ZamowienieForAllView>(ListCopy.Where(item => item.Towar == SearchText));
                    break;
            }

        }
        #endregion
    }
}
