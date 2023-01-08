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
    public class WszystkieMagazynViewModel : collectionViewModel<MagazynForAllView>
    {
        public WszystkieMagazynViewModel()
            : base("Magazyn")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj magazyn");
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
            ListCopy = new List<MagazynForAllView>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Towar","Ilosc","Wartosc" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Towar":
                    List = new ObservableCollection<MagazynForAllView>
                        (descending ? List.OrderByDescending(item => item.Towar) : List.OrderBy(item => item.Towar));
                    break;
                case "Ilosc":
                    List = new ObservableCollection<MagazynForAllView>
                        (descending ? List.OrderByDescending(item => item.Ilosc) : List.OrderBy(item => item.Ilosc));
                    break;
                case "Wartosc":
                    List = new ObservableCollection<MagazynForAllView>
                        (descending ? List.OrderByDescending(item => item.Wartosc) : List.OrderBy(item => item.Wartosc));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Towar", "Ilosc", "Wartosc" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Towar":
                    List = new ObservableCollection<MagazynForAllView>(ListCopy.Where(item => item.Towar == SearchText));
                    break;
                case "Ilosc":
                    List = new ObservableCollection<MagazynForAllView>(ListCopy.Where(item => item.Ilosc == Int32.Parse(SearchText)));
                    break;
                case "Wartosc":
                    List = new ObservableCollection<MagazynForAllView>(ListCopy.Where(item => item.Wartosc == Int32.Parse(SearchText)));
                    break;
            }

        }
    }
}
