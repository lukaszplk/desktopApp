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
        public NowaUslugaViewModel() : base("Nowa Usluga")
        {
            Item = new Usluga();
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
            Item.czyAktywna = true;
            Db.Usluga.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
