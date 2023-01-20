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
        public Pojazd newItem;
        public bool isModified = false;
        public NowySamochodViewModel(int id = -1, string displayname = "Nowy samochod") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Pojazd.SingleOrDefault(item => item.idPojazdu == id);
                isModified = true;
                newItem = new Pojazd();
            }
            else
            {
                Item = new Pojazd();
            }
            poprzedniPrzeglad = DateTime.Now;
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
            if (isModified)
            {

                newItem.marka = Item.marka;
                newItem.kolor = Item.kolor;
                newItem.rok = Item.rok;
                newItem.przebieg = Item.przebieg;
                newItem.poprzedniPrzeglad = Item.poprzedniPrzeglad;
                newItem.planowanyPrzeglad = newItem.poprzedniPrzeglad.AddYears(1);
                newItem.czyAktywny = true;
                Db.Pojazd.AddObject(newItem);
                Db.Pojazd.SingleOrDefault(item => item.idPojazdu == Item.idPojazdu).czyAktywny = false;
                Db.SaveChanges();

            }
            else
            {

                Item.planowanyPrzeglad = Item.poprzedniPrzeglad.AddYears(1);
                Item.czyAktywny = true;
                Db.Pojazd.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
