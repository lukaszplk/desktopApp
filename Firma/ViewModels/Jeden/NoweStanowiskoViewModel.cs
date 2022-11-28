using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NoweStanowiskoViewModel : JedenViewModel
    {
        public Stanowisko Item;

        public NoweStanowiskoViewModel()
            :base("Dodaj stanowisko")
        {
            Item = new Stanowisko();
        }
       

        public string nazwaStanowiska
        {
            get
            {
                return Item.nazwaStanowiska;
            }
            set
            {
                if (value != Item.nazwaStanowiska)
                {
                    Item.nazwaStanowiska = value;
                    base.OnPropertyChanged(() => nazwaStanowiska);
                }
            }
        }

        public string zakresObowiazkow
        {
            get
            {
                return Item.zakresObowiazkow;
            }
            set
            {
                if (value != Item.zakresObowiazkow)
                {
                    Item.zakresObowiazkow = value;
                    base.OnPropertyChanged(() => zakresObowiazkow);
                }
            }
        }

        public int? wymaganeDoswiadczenieLata
        {
            get
            {
                return Item.wymaganeDoswiadczenieLata;
            }
            set
            {
                if (value != Item.wymaganeDoswiadczenieLata)
                {
                    Item.wymaganeDoswiadczenieLata = value;
                    base.OnPropertyChanged(() => wymaganeDoswiadczenieLata);
                }
            }
        }

        public override void Save()
        {
            Item.czyAktywny = true;
            Item.dataUtworzenia = DateTime.Now;
            Db.Stanowisko.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
