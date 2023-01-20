using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowyRabatViewModel : JedenViewModel
    {
        public Rabat Item;
        public Rabat newItem;
        public bool isModified = false;
        public List<Pracownik> listaPracownikow { get; set; }
        public NowyRabatViewModel(int id = -1, string displayname = "Nowy rabat") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Rabat.SingleOrDefault(item => item.idRabatu == id);
                isModified = true;
                newItem = new Rabat();
            }
            else
            {
                Item = new Rabat();
            }
            listaPracownikow = (from pracownik in Db.Pracownik
                                where pracownik.czyAktywny == true
                                select pracownik).ToList();
        }
        public string nazwa
        {
            get
            {
                return Item.nazwaRabatu;
            }
            set
            {
                if (value != Item.nazwaRabatu)
                {
                    Item.nazwaRabatu = value;
                    base.OnPropertyChanged(() => nazwa);
                }
            }
        }
        public int ktoUtworzyl
        {
            get
            {
                return Item.ktoUtworzyl;
            }
            set
            {
                if (value != Item.ktoUtworzyl)
                {
                    Item.ktoUtworzyl = value;
                    base.OnPropertyChanged(() => ktoUtworzyl);
                }
            }
        }
        public string opis
        {
            get
            {
                return Item.zaCoNalezny;
            }
            set
            {
                if (value != Item.zaCoNalezny)
                {
                    Item.zaCoNalezny = value;
                    base.OnPropertyChanged(() => opis);
                }
            }
        }
        public int rabat
        {
            get
            {
                return Item.poziomRabatu;
            }
            set
            {
                if (value != Item.poziomRabatu)
                {
                    Item.poziomRabatu = value;
                    base.OnPropertyChanged(() => rabat);
                }
            }
        }
        public override void Save()
        {
            if (isModified)
            {

                newItem.nazwaRabatu = Item.nazwaRabatu;
                newItem.ktoUtworzyl = Item.ktoUtworzyl;
                newItem.zaCoNalezny = Item.zaCoNalezny;
                newItem.poziomRabatu = Item.poziomRabatu;
                newItem.dataUtworzenia = DateTime.Now;
                newItem.czyAktywny = true;
                Db.Rabat.AddObject(newItem);
                Db.Rabat.SingleOrDefault(item => item.idRabatu == Item.idRabatu).czyAktywny = false;
                Db.SaveChanges();

            }
            else
            {
                Item.czyAktywny = true;
                Item.dataUtworzenia = DateTime.Now;
                Db.Rabat.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
