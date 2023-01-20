using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowySposobPlatnosciViewModel : JedenViewModel
    {
        public SposobPlatnosci Item;
        public SposobPlatnosci newItem;
        public bool isModified = false;
        public NowySposobPlatnosciViewModel(int id = -1, string displayname = "Nowy sposob platnosci") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.SposobPlatnosci.SingleOrDefault(item => item.idSposobuPlatnosci == id);
                isModified = true;
                newItem = new SposobPlatnosci();
            }
            else
            {
                Item = new SposobPlatnosci();
            }
        }

        public string nazwa
        {
            get
            {
                return Item.nazwa;
            }
            set
            {
                if(Item.nazwa != value)
                {
                    Item.nazwa = value;
                    base.OnPropertyChanged(() => nazwa);
                }
            }
        }

        public string opis
        {
            get
            {
                return Item.opis;
            }
            set
            {
                if (Item.opis != value)
                {
                    Item.opis = value;
                    base.OnPropertyChanged(() => opis);
                }
            }
        }

        public override void Save()
        {
            if (isModified)
            {

                newItem.nazwa = Item.nazwa;
                newItem.opis = Item.opis;
                newItem.czyAktywny = true;
                Db.SposobPlatnosci.AddObject(newItem);
                Db.SposobPlatnosci.SingleOrDefault(item => item.idSposobuPlatnosci == Item.idSposobuPlatnosci).czyAktywny = false;
                Db.SaveChanges();

            }
            else
            {
                Item.czyAktywny = true;
                Db.SposobPlatnosci.AddObject(Item);
                Db.SaveChanges();
            }
        }
        
    }
}
