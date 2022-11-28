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
        public NowySposobPlatnosciViewModel() 
            : base("Sposob platnosci")
        {
            Item = new SposobPlatnosci();
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
            Item.czyAktywny = true;
            Db.SposobPlatnosci.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
