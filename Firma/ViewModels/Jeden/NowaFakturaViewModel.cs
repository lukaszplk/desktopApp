using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowaFakturaViewModel : JedenViewModel 
    {
        public Faktura Item;
        public List<Klient> listaKlientow { get; set; }
        public List<Pracownik> listaPracownikow { get; set; }
        public List<SposobPlatnosci> listaSposobowPlatnosci { get; set; }
        #region Konstruktor
        public NowaFakturaViewModel():base("Faktura")
        {
            Item = new Faktura();
            listaKlientow = (from klient in Db.Klient
                            where klient.czyAktywny == true
                            select klient).ToList();
            listaPracownikow = (from pracownik in Db.Pracownik
                            where pracownik.czyAktywny == true
                            select pracownik).ToList();
            listaSposobowPlatnosci = (from platnosci in Db.SposobPlatnosci
                            where platnosci.czyAktywny == true
                            select platnosci).ToList();
            terminPlatnosci = DateTime.Now;
        }


        #endregion
        public int? numer
        {
            get
            {
                return Item.numer;
            }
            set
            {
                if (Item.numer != value)
                {
                    Item.numer = value;
                    base.OnPropertyChanged(() => numer);
                }
            }
        }
        public DateTime? dataWystawienia
        {
            get
            {
                return Item.dataWystawienia;
            }
            set
            {
                if (Item.dataWystawienia != value)
                {
                    Item.dataWystawienia = value;
                    base.OnPropertyChanged(() => dataWystawienia);
                }
            }
        }
        public DateTime terminPlatnosci
        {
            get
            {
                return Item.terminPlatnosci;
            }
            set
            {
                if (Item.terminPlatnosci != value)
                {
                    Item.terminPlatnosci = value;
                    base.OnPropertyChanged(() => terminPlatnosci);
                }
            }
        }
        public int? klient
        {
            get
            {
                return Item.klient;
            }
            set
            {
                if (Item.klient != value)
                {
                    Item.klient = value;
                    base.OnPropertyChanged(() => klient);
                }
            }
        }
        public int? pracownik
        {
            get
            {
                return Item.pracownik;
            }
            set
            {
                if (Item.pracownik != value)
                {
                    Item.pracownik = value;
                    base.OnPropertyChanged(() => pracownik);
                }
            }
        }
        public int? sposobPlatnosci
        {
            get
            {
                return Item.sposobPlatnosci;
            }
            set
            {
                if (Item.sposobPlatnosci != value)
                {
                    Item.sposobPlatnosci = value;
                    base.OnPropertyChanged(() => sposobPlatnosci);
                }
            }
        }
        public int kwotaFaktury
        {
            get
            {
                return Item.kwotaFaktury;
            }
            set
            {
                if (Item.kwotaFaktury != value)
                {
                    Item.kwotaFaktury = value;
                    base.OnPropertyChanged(() => kwotaFaktury);
                }
            }
        }
        public bool czyZatwierdzona
        {
            get
            {
                return Item.czyZatwierdzona;
            }
            set
            {
                if (Item.czyZatwierdzona != value)
                {
                    Item.czyZatwierdzona = value;
                    base.OnPropertyChanged(() => czyZatwierdzona);
                }
            }
        }
        public override void Save()
        {
            Item.czyAktywna = true;
            Db.Faktura.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
