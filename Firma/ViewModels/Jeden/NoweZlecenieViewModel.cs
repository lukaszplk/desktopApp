﻿using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;

namespace Firma.ViewModels.Jeden
{
    public class NoweZlecenieViewModel : JedenViewModel
    {
        public Zlecenia Item;
        public Zlecenia newItem;
        public bool isModified = false;
        public List<Pracownik> listaPracownikow { get; set; }
        public List<Usluga> listaUslug { get; set; }
        public List<Adres> listaAdresow { get; set; }
        public List<Faktura> listaFaktur { get; set; }
        public NoweZlecenieViewModel(int id = -1, string displayname = "Nowe zlecenie") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Zlecenia.SingleOrDefault(item => item.idZlecenia == id);
                isModified = true;
                newItem = new Zlecenia();
            }
            else
            {
                Item = new Zlecenia();
            }
            listaPracownikow = (from pracownik in Db.Pracownik
                            where pracownik.czyAktywny == true
                            select pracownik).ToList();
            listaUslug = (from usluga in Db.Usluga
                             where usluga.czyAktywna == true
                             select usluga).ToList();
            listaAdresow = (from adres in Db.Adres
                            where adres.czyAktywny == true
                            select adres).ToList();
            listaFaktur = (from faktura in Db.Faktura
                             where faktura.czyAktywna == true
                             select faktura).ToList();
            dataZlecenia = DateTime.Now;
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
        public int usluga
        {
            get
            {
                return Item.usluga;
            }
            set
            {
                if (value != Item.usluga)
                {
                    Item.usluga = value;
                    base.OnPropertyChanged(() => usluga);
                }
            }
        }
        public int? adres
        {
            get
            {
                return Item.adres;
            }
            set
            {
                if (value != Item.adres)
                {
                    Item.adres = value;
                    base.OnPropertyChanged(() => adres);
                }
            }
        }
        public int? faktura
        {
            get
            {
                return Item.faktura;
            }
            set
            {
                if (value != Item.faktura)
                {
                    Item.faktura = value;
                    base.OnPropertyChanged(() => faktura);
                }
            }
        }
        public DateTime dataZlecenia
        {
            get
            {
                return Item.dataZlecenia;
            }
            set
            {
                if (value != Item.dataZlecenia)
                {
                    Item.dataZlecenia = value;
                    base.OnPropertyChanged(() => dataZlecenia);
                }
            }
        }

        public override void Save()
        {
            if (isModified)
            {

                newItem.pracownik = Item.pracownik;
                newItem.usluga = Item.usluga;
                newItem.adres = Item.adres;
                newItem.faktura = Item.faktura;
                newItem.dataZlecenia = Item.dataZlecenia;
                newItem.czyAktywne = true;
                Db.Zlecenia.AddObject(newItem);
                Db.Zlecenia.SingleOrDefault(item => item.idZlecenia == Item.idZlecenia).czyAktywne = false;
                Db.SaveChanges();

            }
            else
            {
                Item.czyAktywne = true;
                Db.Zlecenia.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
