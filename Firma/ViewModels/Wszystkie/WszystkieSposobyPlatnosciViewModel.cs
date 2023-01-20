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
    public class WszystkieSposobyPlatnosciViewModel : collectionViewModel<SposobPlatnosci>
    {
        public WszystkieSposobyPlatnosciViewModel()
            :base("Wszystkie sposoby platnosci")
        {

        }
        public override void Modify()
        {
            IDictionary<string, string> json = new Dictionary<string, string>();
            json.Add("Operation", "Modyfikuj sposob platnosci");
            json.Add("Id", Id.ToString());
            Messenger.Default.Send(json);
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj sposob platnosci");
        }

        public override void Load()
        {
            List = new ObservableCollection<SposobPlatnosci>
                (
                    from item in fakturaEntities.SposobPlatnosci
                    where item.czyAktywny == true
                    select item

                );
            ListCopy = new List<SposobPlatnosci>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Nazwa" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<SposobPlatnosci>
                        (descending ? List.OrderByDescending(item => item.nazwa) : List.OrderBy(item => item.nazwa));
                    break;

            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Nazwa" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwa":
                    List = new ObservableCollection<SposobPlatnosci>(ListCopy.Where(item => item.nazwa == SearchText));
                    break;
                
            }

        }

        public override void Usun()
        {
            fakturaEntities.SposobPlatnosci.SingleOrDefault(item => item.idSposobuPlatnosci == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
    }
}
