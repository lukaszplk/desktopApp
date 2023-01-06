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
        public List<Pracownik> listaPracownikow { get; set; }
        public List<Towar> listaTowarow { get; set; }
        public NoweZamowienieViewModel() : base("Nowe zamowienie")
        {
            Item = new Zamowienia();
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
            Item.czyAktywne = true;
            Item.dataZamowienia = DateTime.Now;
            Db.Zamowienia.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
