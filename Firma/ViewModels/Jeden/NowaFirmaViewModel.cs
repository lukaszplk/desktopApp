using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowaFirmaViewModel : JedenViewModel
    {
        public Firma_zew Item;
        public NowaFirmaViewModel() : base("Nowa firma")
        {
            Item = new Firma_zew();
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

        public int? iloscPracownikow
        {
            get
            {
                return Item.iloscPracownikow;
            }
            set
            {
                if (Item.iloscPracownikow != value)
                {
                    Item.iloscPracownikow = value;
                    base.OnPropertyChanged(() => iloscPracownikow);
                }
            }
        }

        public int iloscNaszychUslug
        {
            get
            {
                return Item.iloscNaszychUslug;
            }
            set
            {
                if (Item.iloscNaszychUslug != value)
                {
                    Item.iloscNaszychUslug = value;
                    base.OnPropertyChanged(() => iloscNaszychUslug);
                }
            }
        }

        public int dlugoscWspolpracyMiesiace
        {
            get
            {
                return Item.dlugoscWspolpracyMiesiace;
            }
            set
            {
                if (Item.dlugoscWspolpracyMiesiace != value)
                {
                    Item.dlugoscWspolpracyMiesiace = value;
                    base.OnPropertyChanged(() => dlugoscWspolpracyMiesiace);
                }
            }
        }

        public override void Save()
        {
            Item.czyAktywny = true;
            Db.Firma_zew.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
