using Firma.Helpers;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Jeden
{
    public class NowyTowarViewModel : WorkspaceViewModel
    {
        #region Fields
        public projektEntities Db { get; set; }
        public Towar Item { get; set; }
        #endregion
        #region Konstruktor
        public NowyTowarViewModel()
        {
            base.DisplayName = "Towar"; 
            Db = new projektEntities();
            Item = new Towar();
        }
        public string Kod
        {
            get
            {
                return Item.kod;
            }
            set
            {
                if(value!=Item.kod)
                {
                    Item.kod = value;
                    base.OnPropertyChanged(() => Kod);                }
            }
        }
        public string Nazwa
        {
            get
            {
                return Item.nazwa;
            }
            set
            {
                if (value != Item.nazwa)
                {
                    Item.nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? StawkaVatSprzedazy
        {
            get
            {
                return Item.VatSprzedazy;
            }
            set
            {
                if (value != Item.VatSprzedazy)
                {
                    Item.VatSprzedazy = value;
                    base.OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public int? StawkaVatZakupu
        {
            get
            {
                return Item.VatZakupu;
            }
            set
            {
                if (value != Item.VatZakupu)
                {
                    Item.VatZakupu = value;
                    base.OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public int? Marza
        {
            get
            {
                return Item.marza;
            }
            set
            {
                if (value != Item.marza)
                {
                    Item.marza = value;
                    base.OnPropertyChanged(() => Marza);
                }
            }
        }
        public int Cena
        {
            get
            {
                return Item.cena;
            }
            set
            {
                if (value != Item.cena)
                {
                    Item.cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        #endregion
        #region Commands
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if(_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }
        #endregion
        #region Save
        public void Save()
        {
            Item.czyAktywny = true;
            Db.Towar.AddObject(Item);
            Db.SaveChanges();
        }
        private void SaveAndClose()
        {
            Save();
            base.OnRequestClose();
        }
        #endregion
    }
}
