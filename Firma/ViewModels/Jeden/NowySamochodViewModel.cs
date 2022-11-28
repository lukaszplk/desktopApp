using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowySamochodViewModel : JedenViewModel
    {
        public Pojazd Item;
        public NowySamochodViewModel()
            :base("Dodaj samochod")
        {
            Item = new Pojazd();
        }

        public string marka
        {
            get
            {
                return Item.marka;
            }
            set
            {
                if (value != Item.marka)
                {
                    Item.marka = value;
                    base.OnPropertyChanged(() => marka);
                }
            }
        }

        public string kolor
        {
            get
            {
                return Item.kolor;
            }
            set
            {
                if (value != Item.kolor)
                {
                    Item.kolor = value;
                    base.OnPropertyChanged(() => kolor);
                }
            }
        }

        public int? rok
        {
            get
            {
                return Item.rok;
            }
            set
            {
                if (value != Item.rok)
                {
                    Item.rok = value;
                    base.OnPropertyChanged(() => rok);
                }
            }
        }

        public long? przebieg
        {
            get
            {
                return Item.przebieg;
            }
            set
            {
                if (value != Item.przebieg)
                {
                    Item.przebieg = value;
                    base.OnPropertyChanged(() => przebieg);
                }
            }
        }

        public DateTime poprzedniPrzeglad
        {
            get
            {
                return Item.poprzedniPrzeglad;
            }
            set
            {
                if (value != Item.poprzedniPrzeglad)
                {
                    Item.poprzedniPrzeglad = value;
                    base.OnPropertyChanged(() => poprzedniPrzeglad);
                }
            }
        }

        public override void Save()
        {
            Item.planowanyPrzeglad = poprzedniPrzeglad.AddYears(1);
            Item.czyAktywny = true;
            Db.Pojazd.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
