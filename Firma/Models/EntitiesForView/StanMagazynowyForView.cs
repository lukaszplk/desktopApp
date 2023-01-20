using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.ViewModels;

namespace Firma.Models.EntitiesForView
{
    public class StanMagazynowyForView:BaseViewModel
    {
        public projektEntities db;
        private string _nazwa;
        public string Nazwa
        {
            
                get
            {
                    return _nazwa;
                }
                set
            {
                    if (value != _nazwa)
                    {
                        _nazwa = value;
                        base.OnPropertyChanged(() => Nazwa);
                    }
                }
            
        }
        private int? _ilosc;
        public int? Ilosc
        {

            get
            {
                return _ilosc;
            }
            set
            {
                if (value != _ilosc)
                {
                    _ilosc = value;
                    base.OnPropertyChanged(() => Ilosc);
                }
            }

        }
        private decimal? _wartosc;
        public decimal? Wartosc
        {

            get
            {
                return _wartosc;
            }
            set
            {
                if (value != _wartosc)
                {
                    _wartosc = value;
                    base.OnPropertyChanged(() => Wartosc);
                }
            }

        }
        public StanMagazynowyForView(projektEntities db)
        {
            this.db = db;
        }
        

        public bool Same(Magazyn obj)
        {
            string towar = (from item in this.db.Towar
                            where item.idTowaru == obj.towar
                            select item.nazwa).ToList().First();
            return this.Nazwa == towar;
        }
        public static StanMagazynowyForView Copy(Magazyn obj, projektEntities dbase)
        {
            StanMagazynowyForView tmp = new StanMagazynowyForView(dbase);

            tmp.Nazwa = (from item in dbase.Towar
                         where item.idTowaru == obj.towar
                         select item.nazwa).ToList().First();
            tmp.Ilosc = obj.ilosc;
            tmp.Wartosc = obj.wartoscTowaru;
            return tmp;

        }
        public void Add(Magazyn obj)
        {
            this.Ilosc += obj.ilosc;
            this.Wartosc += obj.wartoscTowaru;
        }
    }
}
