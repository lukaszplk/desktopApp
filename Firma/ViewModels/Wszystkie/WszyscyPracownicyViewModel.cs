using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszyscyPracownicyViewModel : collectionViewModel<PracownikForAllView>
    {
        
        public WszyscyPracownicyViewModel()
            :base("Wszyscy pracownicy")
        {

        }
        public override void Modify()
        {
            IDictionary<string, string> json = new Dictionary<string, string>();
            json.Add("Operation", "Modyfikuj pracownika");
            json.Add("Id", Id.ToString());
            Messenger.Default.Send(json);
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj pracownika");
        }

        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                    from item in fakturaEntities.Pracownik
                    where item.czyAktywny == true
                    select new PracownikForAllView
                    {
                        Id = item.idPracownika,
                        Imie = item.imie,
                        Nazwisko = item.nazwisko,
                        Stanowisko = item.Stanowisko1.nazwaStanowiska,
                        Adres = item.Adres1.ulica + " " + item.Adres1.dom + "\n"
                        + item.Adres1.kodPocztowy + ", " + item.Adres1.miasto,
                        DataZatrudnienia = item.dataZatrudnienia

                    }

                );
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Imie", "Nazwisko" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwisko":
                    List = new ObservableCollection<PracownikForAllView>
                        (descending ? List.OrderByDescending(item => item.Nazwisko) : List.OrderBy(item => item.Nazwisko));
                    break;
                case "Imie":
                    List = new ObservableCollection<PracownikForAllView>
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
                    List = new ObservableCollection<PracownikForAllView>(ListCopy.Where(item => item.Nazwisko == SearchText));
                    break;
                case "Imie":
                    List = new ObservableCollection<PracownikForAllView>(ListCopy.Where(item => item.Imie == SearchText));
                    break;
            }

        }

        public override void Usun()
        {
            fakturaEntities.Pracownik.SingleOrDefault(item => item.idPracownika == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
    }
}
