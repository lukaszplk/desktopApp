using Firma.Models.Entities;
using Firma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class ZamowieniaRaportForView : BaseViewModel
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
        public ZamowieniaRaportForView(projektEntities db)
        {
            this.db = db;
        }


        public bool Same(Zamowienia obj)
        {
            string towar = (from item in this.db.Towar
                            where item.idTowaru == obj.towar
                            select item.nazwa).ToList().First();
            return this.Nazwa == towar;
        }
        public static ZamowieniaRaportForView Copy(Zamowienia obj, projektEntities dbase)
        {
            ZamowieniaRaportForView tmp = new ZamowieniaRaportForView(dbase);

            tmp.Nazwa = (from item in dbase.Towar
                         where item.idTowaru == obj.towar
                         select item.nazwa).ToList().First();
            tmp.Wartosc = obj.wartoscZamowienia;
            return tmp;

        }
        public void Add(Zamowienia obj)
        {
            this.Wartosc += obj.wartoscZamowienia;
        }
    }
}
