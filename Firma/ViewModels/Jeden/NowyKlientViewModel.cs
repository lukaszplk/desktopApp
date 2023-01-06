using Firma.ViewModels.Abstract;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowyKlientViewModel : JedenViewModel
    {
       public Klient Item;
        public List<Adres> listaAdresow { get; set; }
        public List<Firma_zew> listaFirm { get; set; }
        public List<Rabat> listaRabatow { get; set; }
        public List<Pracownik> listaPracownikow { get; set; }
        public NowyKlientViewModel() : base("Nowe zlecenie")
        {
            Item = new Klient();
            listaPracownikow = (from pracownik in Db.Pracownik
                            where pracownik.czyAktywny == true
                            select pracownik).ToList();
            listaRabatow = (from rabat in Db.Rabat
                             where rabat.czyAktywny == true
                             select rabat).ToList();
            listaAdresow = (from adres in Db.Adres
                            where adres.czyAktywny == true
                            select adres).ToList();
            listaFirm = (from firma in Db.Firma_zew
                             where firma.czyAktywny == true
                             select firma).ToList();
        }
        public string imie
        {
            get
            {
                return Item.imie;
            }
            set
            {
                if (value != Item.imie)
                {
                    Item.imie = value;
                    base.OnPropertyChanged(() => imie);
                }
            }
        }
        public string nazwisko
        {
            get
            {
                return Item.nazwisko;
            }
            set
            {
                if (value != Item.nazwisko)
                {
                    Item.nazwisko = value;
                    base.OnPropertyChanged(() => nazwisko);
                }
            }
        }
        public int? adres
        {
            get
            {
                return Item.adres;
            }
            set
            {
                if (value != Item.adres)
                {
                    Item.adres = value;
                    base.OnPropertyChanged(() => adres);
                }
            }
        }
        public int? firma_zew
        {
            get
            {
                return Item.firma_zew;
            }
            set
            {
                if (value != Item.firma_zew)
                {
                    Item.firma_zew = value;
                    base.OnPropertyChanged(() => firma_zew);
                }
            }
        }
        public int? rabat
        {
            get
            {
                return Item.rabat;
            }
            set
            {
                if (value != Item.rabat)
                {
                    Item.rabat = value;
                    base.OnPropertyChanged(() => rabat);
                }
            }
        }
        public int? pracownik
        {
            get
            {
                return Item.ktoUdzielilRabatu;
            }
            set
            {
                if (value != Item.ktoUdzielilRabatu)
                {
                    Item.ktoUdzielilRabatu = value;
                    base.OnPropertyChanged(() => pracownik);
                }
            }
        }


        public override void Save()
        {
            Item.czyAktywny = true;
            Db.Klient.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
