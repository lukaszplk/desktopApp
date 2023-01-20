using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowaUslugaViewModel : JedenViewModel
    {
        public Usluga Item;
        public Usluga newItem;
        public bool isModified = false;
        public NowaUslugaViewModel(int id = -1, string displayname = "Nowa usluga") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Usluga.SingleOrDefault(item => item.idUslugi == id);
                isModified = true;
                newItem = new Usluga();
            }
            else
            {
                Item = new Usluga();
            }
        }
        public string nazwaUslugi
        {
            get
            {
                return Item.nazwaUslugi;
            }
            set
            {
                if(Item.nazwaUslugi != value)
                {
                    Item.nazwaUslugi = value;
                    base.OnPropertyChanged(()=>nazwaUslugi);
                }
            }
        }

        public int koszt
        {
            get
            {
                return Item.koszt;
            }
            set
            {
                if (Item.koszt != value)
                {
                    Item.koszt = value;
                    base.OnPropertyChanged(() => koszt);
                }
            }
        }

        public string potrzebnyCzasDni
        {
            get
            {
                return Item.potrzebnyCzasDni;
            }
            set
            {
                if (Item.potrzebnyCzasDni != value)
                {
                    Item.potrzebnyCzasDni = value;
                    base.OnPropertyChanged(() => potrzebnyCzasDni);
                }
            }
        }


        public override void Save()
        {
            if (isModified)
            {

                newItem.nazwaUslugi = Item.nazwaUslugi;
                newItem.koszt = Item.koszt;
                newItem.potrzebnyCzasDni = Item.potrzebnyCzasDni;
                newItem.czyAktywna = true;
                Db.Usluga.AddObject(newItem);
                Db.Usluga.SingleOrDefault(item => item.idUslugi == Item.idUslugi).czyAktywna = false;
                Db.SaveChanges();

            }
            else
            {
                Item.czyAktywna = true;
                Db.Usluga.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
