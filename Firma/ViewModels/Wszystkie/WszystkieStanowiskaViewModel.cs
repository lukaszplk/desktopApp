using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.ViewModels.Abstract;
using Firma.Models.Entities;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieStanowiskaViewModel : collectionViewModel<Stanowisko>
    {
        public WszystkieStanowiskaViewModel()
            :base("Wszystkie stanowiska")
        {

        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj stanowisko");
        }

        public override void Load()
        {
            List = new ObservableCollection<Stanowisko>
                (
                    from item in fakturaEntities.Stanowisko
                    where item.czyAktywny == true
                    select item

                );
            ListCopy = new List<Stanowisko>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Nazwa", "Doswiadczenie" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Stanowisko>
                        (descending ? List.OrderByDescending(item => item.nazwaStanowiska) : List.OrderBy(item => item.nazwaStanowiska));
                    break;
                case "Doswiadczenie":
                    List = new ObservableCollection<Stanowisko>
                        (descending ? List.OrderByDescending(item => item.wymaganeDoswiadczenieLata) : List.OrderBy(item => item.wymaganeDoswiadczenieLata));
                    break;
                
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Nazwa"};


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Stanowisko>(ListCopy.Where(item => item.nazwaStanowiska == SearchText));
                    break;
                
            }

        }

        public override void Usun()
        {
            fakturaEntities.Stanowisko.SingleOrDefault(item => item.idStanowiska == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
    }
}
