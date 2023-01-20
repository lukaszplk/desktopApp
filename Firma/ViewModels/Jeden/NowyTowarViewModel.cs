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

        public Towar oldItem;
        public Towar newItem;
        public bool isModified = false;
        #endregion
        #region Konstruktor
        public NowyTowarViewModel(int id = -1, string displayname = "Nowy towar") : base(displayname)
        {
            if (id != -1)
            {
                oldItem = Db.Towar.SingleOrDefault(item => item.idTowaru == id);
                isModified = true;
                newItem = new Towar();
            }
            else
            {
                oldItem = new Towar();
            }
        }
        public string Kod
        {
            get
            {
                return oldItem.kod;
            }
            set
            {
                if(value != oldItem.kod)
                {
                    oldItem.kod = value;
                    base.OnPropertyChanged(() => Kod);                }
            }
        }
        public string Nazwa
        {
            get
            {
                return oldItem.nazwa;
            }
            set
            {
                if (value != oldItem.nazwa)
                {
                    oldItem.nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? StawkaVatSprzedazy
        {
            get
            {
                return oldItem.VatSprzedazy;
            }
            set
            {
                if (value != oldItem.VatSprzedazy)
                {
                    oldItem.VatSprzedazy = value;
                    base.OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public int? StawkaVatZakupu
        {
            get
            {
                return oldItem.VatZakupu;
            }
            set
            {
                if (value != oldItem.VatZakupu)
                {
                    oldItem.VatZakupu = value;
                    base.OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public int? Marza
        {
            get
            {
                return oldItem.marza;
            }
            set
            {
                if (value != oldItem.marza)
                {
                    oldItem.marza = value;
                    base.OnPropertyChanged(() => Marza);
                }
            }
        }
        public int Cena
        {
            get
            {
                return oldItem.cena;
            }
            set
            {
                if (value != oldItem.cena)
                {
                    oldItem.cena = value;
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
                    case nameof(StawkaVatSprzedazy):
                        return DecimalValidator.CzyProcent(StawkaVatSprzedazy);
                    case nameof(StawkaVatZakupu):
                        return DecimalValidator.CzyProcent(StawkaVatZakupu);
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
            if (isModified)
            {

                newItem.kod = oldItem.kod;
                newItem.nazwa = oldItem.nazwa;
                newItem.VatZakupu = oldItem.VatZakupu;
                newItem.VatSprzedazy = oldItem.VatSprzedazy;
                newItem.marza = oldItem.marza;
                newItem.cena = oldItem.cena;
                newItem.czyAktywny = true;
                Db.Towar.AddObject(newItem);
                Db.Towar.SingleOrDefault(item => item.idTowaru == oldItem.idTowaru).czyAktywny = false;
                Db.SaveChanges();

            }
            else
            {
                oldItem.czyAktywny = true;
                Db.Towar.AddObject(oldItem);
                Db.SaveChanges();
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Cena)] != String.Empty
                && this[nameof(StawkaVatSprzedazy)] != String.Empty
                && this[nameof(StawkaVatZakupu)] != String.Empty;
        }
        #endregion
    }
}
