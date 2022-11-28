using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firma.ViewModels.Abstract;
using System.Threading.Tasks;
using Firma.Models.Entities;

namespace Firma.ViewModels.Jeden
{
    public class NowyAdresViewModel : JedenViewModel
    {
        public Adres Item;
        public NowyAdresViewModel()
            : base("Adres")
        {
            Item = new Adres();
        }

        public string ulica
        {
            get
            {
                return Item.ulica;
            }
            set
            {
                if (value != Item.ulica)
                {
                    Item.ulica = value;
                    base.OnPropertyChanged(() => ulica);
                }
            }
        }

        public string dom
        {
            get
            {
                return Item.dom;
            }
            set
            {
                if (value != Item.dom)
                {
                    Item.dom = value;
                    base.OnPropertyChanged(() => dom);
                }
            }
        }

        public string mieszkanie
        {
            get
            {
                return Item.mieszkanie;
            }
            set
            {
                if (value != Item.mieszkanie)
                {
                    Item.mieszkanie = value;
                    base.OnPropertyChanged(() => mieszkanie);
                }
            }
        }

        public string kodPocztowy
        {
            get
            {
                return Item.kodPocztowy;
            }
            set
            {
                if (value != Item.kodPocztowy)
                {
                    Item.kodPocztowy = value;
                    base.OnPropertyChanged(() => kodPocztowy);
                }
            }
        }

        public string miasto
        {
            get
            {
                return Item.miasto;
            }
            set
            {
                if (value != Item.miasto)
                {
                    Item.miasto = value;
                    base.OnPropertyChanged(() => miasto);
                }
            }
        }
        public override void Save()
        {
            Item.czyAktywny = true;
            Db.Adres.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
