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
    public class WszyscyKlienciViewModel : collectionViewModel<KlientForAllView>
    {
        
        public WszyscyKlienciViewModel()
            :base("Wszyscy klienci")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<KlientForAllView>
                (
                    from klient in fakturaEntities.Klient
                    where klient.czyAktywny == true
                    select new KlientForAllView
                    {
                        Imie = klient.imie,
                        Nazwisko = klient.nazwisko,
                        Miejscowosc = klient.Adres1.miasto + ", " + klient.Adres1.kodPocztowy,
                        Firma = klient.Firma_zew1.nazwa
                    }

                );
            ListCopy = new List<KlientForAllView>(List);
        }
        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj klienta");
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Imie", "Nazwisko" };
       

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwisko":
                    List = new ObservableCollection<KlientForAllView>
                        (descending?List.OrderByDescending(item => item.Nazwisko): List.OrderBy(item => item.Nazwisko));
                    break;
                case "Imie":
                    List = new ObservableCollection<KlientForAllView>
                        (descending ? List.OrderByDescending(item => item.Imie) : List.OrderBy(item => item.Imie));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Imie", "Nazwisko" };
       

        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwisko":
                    List = new ObservableCollection<KlientForAllView>(ListCopy.Where(item => item.Nazwisko == SearchText));
                    break;
                case "Imie":
                    List = new ObservableCollection<KlientForAllView>(ListCopy.Where(item => item.Imie == SearchText));
                    break;
            }
            
        }
    }
}
