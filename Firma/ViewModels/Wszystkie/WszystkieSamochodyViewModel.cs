using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieSamochodyViewModel : collectionViewModel<Pojazd>
    {
        public WszystkieSamochodyViewModel()
            :base("Wszystkie samochody")
        {
        }

        public override void Modify()
        {
            IDictionary<string, string> json = new Dictionary<string, string>();
            json.Add("Operation", "Modyfikuj samochod");
            json.Add("Id", Id.ToString());
            Messenger.Default.Send(json);
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj samochod");
        }

        public override void Load()
        {
            List = new ObservableCollection<Pojazd>
                (
                    from item in fakturaEntities.Pojazd
                    where item.czyAktywny == true
                    select item

                ); 
            ListCopy = new List<Pojazd>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Marka","Rok","Przebieg","Aktualny przeglad", "Kolejny przeglad" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Marka":
                    List = new ObservableCollection<Pojazd>
                        (descending ? List.OrderByDescending(item => item.marka) : List.OrderBy(item => item.marka));
                    break;
                case "Rok":
                    List = new ObservableCollection<Pojazd>
                        (descending ? List.OrderByDescending(item => item.rok) : List.OrderBy(item => item.rok));
                    break;
                case "Przebieg":
                    List = new ObservableCollection<Pojazd>
                        (descending ? List.OrderByDescending(item => item.przebieg) : List.OrderBy(item => item.przebieg));
                    break;
                case "Aktualny przeglad":
                    List = new ObservableCollection<Pojazd>
                        (descending ? List.OrderByDescending(item => item.poprzedniPrzeglad) : List.OrderBy(item => item.poprzedniPrzeglad));
                    break;
                case "Kolejny przeglad":
                    List = new ObservableCollection<Pojazd>
                        (descending ? List.OrderByDescending(item => item.planowanyPrzeglad) : List.OrderBy(item => item.planowanyPrzeglad));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Marka", "Rok", "Przebieg"};


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Marka":
                    List = new ObservableCollection<Pojazd>(ListCopy.Where(item => item.marka == SearchText));
                    break;
                case "Rok":
                    List = new ObservableCollection<Pojazd>(ListCopy.Where(item => item.rok == Int32.Parse(SearchText)));
                    break;
                case "Przebieg":
                    List = new ObservableCollection<Pojazd>(ListCopy.Where(item => item.przebieg == Int32.Parse(SearchText)));
                    break;
            }

        }

        public override void Usun()
        {
            fakturaEntities.Pojazd.SingleOrDefault(item => item.idPojazdu == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
    }
}
