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
        public Stanowisko newItem;
        public bool isModified = false;

        public NoweStanowiskoViewModel(int id = -1, string displayname = "Nowe stanowisko") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Stanowisko.SingleOrDefault(item => item.idStanowiska == id);
                isModified = true;
                newItem = new Stanowisko();
            }
            else
            {
                Item = new Stanowisko();
            }
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
            if (isModified)
            {

                newItem.nazwaStanowiska = Item.nazwaStanowiska;
                newItem.zakresObowiazkow = Item.zakresObowiazkow;
                newItem.wymaganeDoswiadczenieLata = Item.wymaganeDoswiadczenieLata;
                newItem.czyAktywny = true;
                Db.Stanowisko.AddObject(newItem);
                Db.Stanowisko.SingleOrDefault(item => item.idStanowiska == Item.idStanowiska).czyAktywny = false;
                Db.SaveChanges();

            }
            else
            {
                Item.czyAktywny = true;
                Db.Stanowisko.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
