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
    public class WszystkieRabatyViewModel : collectionViewModel<RabatyForAllView>
    {
        public WszystkieRabatyViewModel()
           : base("Wszystkie rabaty")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj rabat");
        }

        public override void Load()
        {
            List = new ObservableCollection<RabatyForAllView>
                (
                    from item in fakturaEntities.Rabat
                    where item.czyAktywny == true
                    select new RabatyForAllView
                    {
                        Nazwa = item.nazwaRabatu,
                        DataUtworzenia = item.dataUtworzenia,
                        Kto = item.Pracownik.imie + " " + item.Pracownik.nazwisko,
                        Opis = item.zaCoNalezny,
                        Poziom = item.poziomRabatu
                    }

                );
            ListCopy = new List<RabatyForAllView>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Nazwa","Data","Tworca" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<RabatyForAllView>
                        (descending ? List.OrderByDescending(item => item.Nazwa) : List.OrderBy(item => item.Nazwa));
                    break;
                case "Data":
                    List = new ObservableCollection<RabatyForAllView>
                        (descending ? List.OrderByDescending(item => item.DataUtworzenia) : List.OrderBy(item => item.DataUtworzenia));
                    break;
                case "Tworca":
                    List = new ObservableCollection<RabatyForAllView>
                        (descending ? List.OrderByDescending(item => item.Kto) : List.OrderBy(item => item.Kto));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Nazwa", "Tworca", "Rabat" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwa":
                    List = new ObservableCollection<RabatyForAllView>(ListCopy.Where(item => item.Nazwa == SearchText));
                    break;
                case "Tworca":
                    List = new ObservableCollection<RabatyForAllView>(ListCopy.Where(item => item.Kto == SearchText));
                    break;
                case "Rabat":
                    List = new ObservableCollection<RabatyForAllView>(ListCopy.Where(item => item.Poziom == Int32.Parse(SearchText)));
                    break;
            }

        }

        public override void Usun()
        {
            throw new NotImplementedException();
        }
    }
}
