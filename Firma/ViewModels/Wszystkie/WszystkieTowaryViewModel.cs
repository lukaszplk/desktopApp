using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Firma.Helpers;
using Firma.Models.Entities;
using System.Collections.ObjectModel;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieTowaryViewModel : collectionViewModel<Towar>
    {
        
        #region Konstruktor
        public WszystkieTowaryViewModel()
            :base("Towary")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj towar");
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Towar>
                (
                    from towar in fakturaEntities.Towar
                    where towar.czyAktywny == true
                    select towar
                    
                );
            ListCopy = new List<Towar>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Nazwa","Cena","Marza" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Towar>
                        (descending ? List.OrderByDescending(item => item.nazwa) : List.OrderBy(item => item.nazwa));
                    break;
                case "Cena":
                    List = new ObservableCollection<Towar>
                        (descending ? List.OrderByDescending(item => item.cena) : List.OrderBy(item => item.cena));
                    break;
                case "Marza":
                    List = new ObservableCollection<Towar>
                        (descending ? List.OrderByDescending(item => item.marza) : List.OrderBy(item => item.marza));
                    break;
                
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Nazwa","Kod" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Towar>(ListCopy.Where(item => item.nazwa == SearchText));
                    break;
                case "Kod":
                    List = new ObservableCollection<Towar>(ListCopy.Where(item => item.kod ==SearchText));
                    break;
                
            }

        }

        public override void Usun()
        {
            fakturaEntities.Towar.SingleOrDefault(item => item.idTowaru == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
        #endregion
    }
}
