using Firma.ViewModels.Abstract;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NoweZamowienieViewModel : JedenViewModel
    {
        public Zamowienia Item;
        public Zamowienia newItem;
        public bool isModified = false;
        public List<Pracownik> listaPracownikow { get; set; }
        public List<Towar> listaTowarow { get; set; }
        public NoweZamowienieViewModel(int id = -1, string displayname = "Nowe zamowienie") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Zamowienia.SingleOrDefault(item => item.idZamowienia == id);
                isModified = true;
                newItem = new Zamowienia();
            }
            else
            {
                Item = new Zamowienia();
            }
            listaPracownikow = (from pracownik in Db.Pracownik
                                where pracownik.czyAktywny == true
                                select pracownik).ToList();
            listaTowarow = (from towar in Db.Towar
                          where towar.czyAktywny == true
                          select towar).ToList();
        }
        public int pracownik
        {
            get
            {
                return Item.pracownik;
            }
            set
            {
                if (value != Item.pracownik)
                {
                    Item.pracownik = value;
                    base.OnPropertyChanged(() => pracownik);
                }
            }
        }
        public int? towar
        {
            get
            {
                return Item.towar;
            }
            set
            {
                if (value != Item.towar)
                {
                    Item.towar = value;
                    base.OnPropertyChanged(() => towar);
                }
            }
        }
        public decimal? wartosc
        {
            get
            {
                return Item.wartoscZamowienia;
            }
            set
            {
                if (value != Item.wartoscZamowienia)
                {
                    Item.wartoscZamowienia = value;
                    base.OnPropertyChanged(() => wartosc);
                }
            }
        }

        public override void Save()
        {
            if (isModified)
            {

                newItem.pracownik = Item.pracownik;
                newItem.towar = Item.towar;
                newItem.wartoscZamowienia = Item.wartoscZamowienia;
                newItem.dataZamowienia = Item.dataZamowienia;
                newItem.czyAktywne = true;
                Db.Zamowienia.AddObject(newItem);
                Db.Zamowienia.SingleOrDefault(item => item.idZamowienia == Item.idZamowienia).czyAktywne = false;
                Db.SaveChanges();

            }
            else
            {
                Item.dataZamowienia = DateTime.Now;
                Item.czyAktywne = true;
                Db.Zamowienia.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
