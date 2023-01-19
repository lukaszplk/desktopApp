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
    public class WszystkieAdresyViewModel : collectionViewModel<Adres>
    {
        public WszystkieAdresyViewModel()
            :base("Adresy")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj adres");
        }

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                    from adres in fakturaEntities.Adres
                    where adres.czyAktywny == true
                    select adres

                );
            ListCopy = new List<Adres>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Miasto", "Ulica" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Ulica":
                    List = new ObservableCollection<Adres>
                        (descending ? List.OrderByDescending(item => item.ulica) : List.OrderBy(item => item.ulica));
                    break;
                case "Miasto":
                    List = new ObservableCollection<Adres>
                        (descending ? List.OrderByDescending(item => item.miasto) : List.OrderBy(item => item.miasto));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Miasto", "Ulica" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Miasto":
                    List = new ObservableCollection<Adres>(ListCopy.Where(item => item.miasto == SearchText));
                    break;
                case "Ulica":
                    List = new ObservableCollection<Adres>(ListCopy.Where(item => item.ulica == SearchText));
                    break;
            }

        }

        public override void Usun()
        {
            fakturaEntities.Adres.SingleOrDefault(item => item.idAdresu == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
        #endregion
    }
}
