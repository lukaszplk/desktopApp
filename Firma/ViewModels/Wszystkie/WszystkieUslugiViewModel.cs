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
    public class WszystkieUslugiViewModel : collectionViewModel<Usluga>
    {
        public WszystkieUslugiViewModel()
            :base("Wszystkie Uslugi")
        {

        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj usluge");
        }

        public override void Load()
        {
            List = new ObservableCollection<Usluga>
                (
                    from item in fakturaEntities.Usluga
                    where item.czyAktywna == true
                    select item

                );
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Nazwa", "Koszt", "Czas" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Usluga>
                        (descending ? List.OrderByDescending(item => item.nazwaUslugi) : List.OrderBy(item => item.nazwaUslugi));
                    break;
                case "Koszt":
                    List = new ObservableCollection<Usluga>
                        (descending ? List.OrderByDescending(item => item.koszt) : List.OrderBy(item => item.koszt));
                    break;
                case "Czas":
                    List = new ObservableCollection<Usluga>
                        (descending ? List.OrderByDescending(item => item.potrzebnyCzasDni) : List.OrderBy(item => item.potrzebnyCzasDni));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Nazwa" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Usluga>(ListCopy.Where(item => item.nazwaUslugi == SearchText));
                    break;
                
            }

        }

        public override void Usun()
        {
            throw new NotImplementedException();
        }
    }
}
