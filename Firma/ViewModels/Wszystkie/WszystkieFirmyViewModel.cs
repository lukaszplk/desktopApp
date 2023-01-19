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
    public class WszystkieFirmyViewModel : collectionViewModel<Firma_zew>
    {
        public WszystkieFirmyViewModel()
            :base("Wszystkie firmy")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj firme");
        }

        public override void Load()
        {
            List = new ObservableCollection<Firma_zew>
                (
                    from item in fakturaEntities.Firma_zew
                    where item.czyAktywny == true
                    select item

                );
            ListCopy = new List<Firma_zew>(List);
        }

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Nazwa","Dl wspolpracy","Liczba uslug" };


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Firma_zew>
                        (descending ? List.OrderByDescending(item => item.nazwa) : List.OrderBy(item => item.nazwa));
                    break;
                case "Dl wspolpracy":
                    List = new ObservableCollection<Firma_zew>
                        (descending ? List.OrderByDescending(item => item.dlugoscWspolpracyMiesiace) : List.OrderBy(item => item.dlugoscWspolpracyMiesiace));
                    break;
                case "Liczba uslug":
                    List = new ObservableCollection<Firma_zew>
                        (descending ? List.OrderByDescending(item => item.iloscNaszychUslug) : List.OrderBy(item => item.iloscNaszychUslug));
                    break;
            }
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Nazwa", "Dl wspolpracy", "Liczba uslug" };


        protected override void Search()
        {
            switch (SearchField)
            {
                case "Nazwa":
                    List = new ObservableCollection<Firma_zew>(ListCopy.Where(item => item.nazwa == SearchText));
                    break;
                case "Dl wspolpracy":
                    List = new ObservableCollection<Firma_zew>(ListCopy.Where(item => item.dlugoscWspolpracyMiesiace == Int32.Parse(SearchText)));
                    break;
                case "Liczba uslug":
                    List = new ObservableCollection<Firma_zew>(ListCopy.Where(item => item.iloscNaszychUslug == Int32.Parse(SearchText)));
                    break;
            }

        }

        public override void Usun()
        {
            fakturaEntities.Firma_zew.SingleOrDefault(item => item.idFirmy == Id).czyAktywny = false;
            fakturaEntities.SaveChanges();
        }
    }
}
