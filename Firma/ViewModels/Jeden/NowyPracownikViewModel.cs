using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowyPracownikViewModel : JedenViewModel
    {
        public Pracownik Item;
        public List<Adres> listaAdresow { get; set; }
        public List<Stanowisko> listaStanowisk { get; set; }
        public List<Pojazd> listaPojazdow { get; set; }
        #region Konstruktor
        public NowyPracownikViewModel() :
            base("Nowy pracownik")
        {
            Item = new Pracownik();
            listaAdresow = (from adres in Db.Adres
                            where adres.czyAktywny == true
                            select adres).ToList();
            listaStanowisk = (from stanowisko in Db.Stanowisko
                            where stanowisko.czyAktywny == true
                            select stanowisko).ToList();
            listaPojazdow = (from pojazd in Db.Pojazd
                            where pojazd.czyAktywny == true
                            select pojazd).ToList();
            listaPojazdow.Add(new Pojazd() { idPojazdu = -1, marka = "Brak" });
            dataZatrudnienia = DateTime.Now;
        }
        #endregion
        #region Properties
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
        public int adres
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
        public int stanowisko
        {
            get
            {
                return Item.stanowisko;
            }
            set
            {
                if (value != Item.stanowisko)
                {
                    Item.stanowisko = value;
                    base.OnPropertyChanged(() => stanowisko);
                }
            }
        }
        public DateTime dataZatrudnienia
        {
            get
            {
                return Item.dataZatrudnienia;
            }
            set
            {
                if (value != Item.dataZatrudnienia)
                {
                    Item.dataZatrudnienia = value;
                    base.OnPropertyChanged(() => dataZatrudnienia);
                }
            }
        }
        public int? pojazd
        {
            get
            {
                return Item.pojazd;
            }
            set
            {
                if (value != Item.pojazd && value>=0)
                {
                    Item.pojazd = value;
                    Item.czyKierowca = true;
                    base.OnPropertyChanged(() => pojazd);

                }
                else
                {
                    Item.pojazd = null;
                    Item.czyKierowca = false;
                }
            }
        }

        #endregion

        public override void Save()
        {
            Item.czyAktywny = true;
            Db.Pracownik.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
