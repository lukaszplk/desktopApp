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
    public class WszystkieUrlopyViewModel : collectionViewModel<UrlopForAllView>
    {
        public WszystkieUrlopyViewModel()
            : base("Wszystkie urlopy")
        {

        }
        public override void Modify()
        {
            IDictionary<string, string> json = new Dictionary<string, string>();
            json.Add("Operation", "Modyfikuj urlop");
            json.Add("Id", Id.ToString());
            Messenger.Default.Send(json);
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj urlop");
        }

        public override void Load()
        {
            List = new ObservableCollection<UrlopForAllView>
                (
                    from item in fakturaEntities.Urlop
                    where item.czyAktywny == true
                    select new UrlopForAllView
                    {
                        IdUrlopu = item.idUrlopu,
                        Pracownik = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                        Zatwierdzajacy = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                        DataRozpoczecia = item.dataRozpoczecia,
                        DataZakonczenia = item.dataZakonczenia,
                        Uzasadnienie = item.uzasadnienie,
                        CzyZatwierdzony = item.czyZatwierdzony,
                        CzyPlatny = item.czyPlatny
                        
        
    }

                );
            
            ListCopy = new List<UrlopForAllView>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Pracownik","Data rozpoczecia", "Data zakonczenia" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Pracownik":
                    List = new ObservableCollection<UrlopForAllView>
                        (descending ? List.OrderByDescending(item => item.Pracownik) : List.OrderBy(item => item.Pracownik));
                    break;
                case "Data rozpoczecia":
                    List = new ObservableCollection<UrlopForAllView>
                        (descending ? List.OrderByDescending(item => item.DataRozpoczecia) : List.OrderBy(item => item.DataRozpoczecia));
                    break;
                case "Data zakonczenia":
                    List = new ObservableCollection<UrlopForAllView>
                        (descending ? List.OrderByDescending(item => item.DataZakonczenia) : List.OrderBy(item => item.DataZakonczenia));
                    break;
                
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Pracownik","Zatwierdzone" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Pracownik":
                    List = new ObservableCollection<UrlopForAllView>(ListCopy.Where(item => item.Pracownik == SearchText));
                    break;
                case "Zatwierdzone":
                    List = new ObservableCollection<UrlopForAllView>(ListCopy.Where(item => item.CzyZatwierdzony == true));
                    break;
                case "Nie zatwierdzone":
                    List = new ObservableCollection<UrlopForAllView>(ListCopy.Where(item => item.CzyZatwierdzony ==false));
                    break;

            }

        }

        public override void Usun()
        {
            fakturaEntities.Urlop.SingleOrDefault(item => item.idUrlopu == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
    }
}
