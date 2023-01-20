using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.EntitiesForView;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
        public class WszystkieZleceniaViewModel : collectionViewModel<ZlecenieForAllView>
        {
            public WszystkieZleceniaViewModel()
                : base("Wszystkie zlecenia")
            {

            }
        public override void Modify()
        {
            IDictionary<string, string> json = new Dictionary<string, string>();
            json.Add("Operation", "Modyfikuj zlecenie");
            json.Add("Id", Id.ToString());
            Messenger.Default.Send(json);
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj zlecenie");
        }

        public override void Load()
            {
                List = new ObservableCollection<ZlecenieForAllView>
                    (
                        from item in fakturaEntities.Zlecenia
                        where item.czyAktywne == true
                        select new ZlecenieForAllView
                        {
                            Id = item.idZlecenia,
                            Pracownik = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                            Usluga = item.Usluga1.nazwaUslugi,
                            Adres = item.Adres1.kodPocztowy + ", " + item.Adres1.miasto,
                            Faktura = item.Faktura1.numer,
                            Data = item.dataZlecenia
                        }

                    );
            ListCopy = new List<ZlecenieForAllView>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Usluga","Faktura","Data"};


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Usluga":
                    List = new ObservableCollection<ZlecenieForAllView>
                        (descending ? List.OrderByDescending(item => item.Usluga) : List.OrderBy(item => item.Usluga));
                    break;
                case "Faktura":
                    List = new ObservableCollection<ZlecenieForAllView>
                        (descending ? List.OrderByDescending(item => item.Faktura) : List.OrderBy(item => item.Faktura));
                    break;
                case "Data":
                    List = new ObservableCollection<ZlecenieForAllView>
                        (descending ? List.OrderByDescending(item => item.Data) : List.OrderBy(item => item.Data));
                    break;
                
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Id","Usluga","Pracownik","Adres" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Id":
                    List = new ObservableCollection<ZlecenieForAllView>(ListCopy.Where(item => item.Id == Int32.Parse(SearchText)));
                    break;
                case "Usluga":
                    List = new ObservableCollection<ZlecenieForAllView>(ListCopy.Where(item => item.Usluga == SearchText));
                    break;
                case "Pracownik":
                    List = new ObservableCollection<ZlecenieForAllView>(ListCopy.Where(item => item.Pracownik == SearchText));
                    break;
                case "Adres":
                    List = new ObservableCollection<ZlecenieForAllView>(ListCopy.Where(item => item.Adres == SearchText));
                    break;
            }

        }

        public override void Usun()
        {
            fakturaEntities.Zlecenia.SingleOrDefault(item => item.idZlecenia == Id).czyAktywne = false;
            fakturaEntities.SaveChanges();
        }
    }
    
}
