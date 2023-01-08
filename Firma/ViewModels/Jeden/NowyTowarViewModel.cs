using Firma.Helpers;
using Firma.Models.Entities;
using Firma.Models.Validatory;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Jeden
{
    public class NowyTowarViewModel : JedenViewModel, IDataErrorInfo
    {
        #region Fields
       
        public Towar towar { get; set; }
        #endregion
        #region Konstruktor
        public NowyTowarViewModel():base("Towar")
        {
            
            Db = new projektEntities();
            towar = new Towar();
        }
        public string Kod
        {
            get
            {
                return towar.kod;
            }
            set
            {
                if(value!=towar.kod)
                {
                    towar.kod = value;
                    base.OnPropertyChanged(() => Kod);                }
            }
        }
        public string Nazwa
        {
            get
            {
                return towar.nazwa;
            }
            set
            {
                if (value != towar.nazwa)
                {
                    towar.nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? StawkaVatSprzedazy
        {
            get
            {
                return towar.VatSprzedazy;
            }
            set
            {
                if (value != towar.VatSprzedazy)
                {
                    towar.VatSprzedazy = value;
                    base.OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public int? StawkaVatZakupu
        {
            get
            {
                return towar.VatZakupu;
            }
            set
            {
                if (value != towar.VatZakupu)
                {
                    towar.VatZakupu = value;
                    base.OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public int? Marza
        {
            get
            {
                return towar.marza;
            }
            set
            {
                if (value != towar.marza)
                {
                    towar.marza = value;
                    base.OnPropertyChanged(() => Marza);
                }
            }
        }
        public int Cena
        {
            get
            {
                return towar.cena;
            }
            set
            {
                if (value != towar.cena)
                {
                    towar.cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Cena):
                        return DecimalValidator.CzyWiekszyOdZera(Cena);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion
        #region Commands

        #endregion
        #region Save
        public override void Save()
        {
            towar.czyAktywny = true;
            Db.Towar.AddObject(towar);
            Db.SaveChanges();
        }
        protected override bool IsValid()
        {
            return this[nameof(Cena)] != string.Empty
                && this[nameof(StawkaVatSprzedazy)] != string.Empty
                && this[nameof(StawkaVatZakupu)] != string.Empty;
        }
        #endregion
    }
}
