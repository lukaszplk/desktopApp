using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Jeden
{
    public class NowyUrlopViewModel : JedenViewModel
    {
        public Urlop Item;
        public List<Pracownik> listaPracownikow { get; set; }
        public NowyUrlopViewModel() : base("Nowy urlop")
        {
            Item = new Urlop();
            listaPracownikow = (from pracownik in Db.Pracownik
                                where pracownik.czyAktywny == true
                                select pracownik).ToList();
            Od = DateTime.Now;
            Do = DateTime.Now;
        }
        public int pracownik
        {
            get
            {
                return Item.pracownik;
            }
            set
            {
                if (value != Item.pracownik)
                {
                    Item.pracownik = value;
                    base.OnPropertyChanged(() => pracownik);
                }
            }
        }

        public int zatwierdzajacy
        {
            get
            {
                return Item.zatwierdzajacy;
            }
            set
            {
                if (value != Item.zatwierdzajacy)
                {
                    Item.zatwierdzajacy = value;
                    base.OnPropertyChanged(() => zatwierdzajacy);
                }
            }
        }
        public DateTime Od
        {
            get
            {
                return Item.dataRozpoczecia;
            }
            set
            {
                if (value != Item.dataRozpoczecia)
                {
                    Item.dataRozpoczecia = value;
                    base.OnPropertyChanged(() => Od);
                }
            }
        }
        public DateTime? Do
        {
            get
            {
                return Item.dataZakonczenia;
            }
            set
            {
                if (value != Item.dataZakonczenia)
                {
                    Item.dataZakonczenia = value;
                    base.OnPropertyChanged(() => Do);
                }
            }
        }
        public string uzasadnienie
        {
            get
            {
                return Item.uzasadnienie;
            }
            set
            {
                if (value != Item.uzasadnienie)
                {
                    Item.uzasadnienie = value;
                    base.OnPropertyChanged(() => uzasadnienie);
                }
            }
        }
        public bool czyPlatny
        {
            get
            {
                return Item.czyPlatny;
            }
            set
            {
                if (value != Item.czyPlatny)
                {
                    Item.czyPlatny = value;
                    base.OnPropertyChanged(() => czyPlatny);
                }
            }
        }

        public override void Save()
        {
            Item.czyAktywny = true;
            Item.czyZatwierdzony = true;
            Db.Urlop.AddObject(Item);
            Db.SaveChanges();
        }
    }
}
