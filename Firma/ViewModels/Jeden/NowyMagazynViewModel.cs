﻿using Firma.Helpers;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Jeden
{
    public class NowyMagazynViewModel : JedenViewModel
    {
        public Magazyn Item;
        public Magazyn newItem;
        public bool isModified=false;
        public List<Towar> listaTowarow { get; set; }
        public List<Zamowienia> listaZamowien { get; set; }

        public NowyMagazynViewModel(int id = -1, string displayname = "Magazyn") : base(displayname)
        {
            if (id != -1)
            {
                Item = Db.Magazyn.SingleOrDefault(item => item.id == id);
                isModified = true;
                newItem = new Magazyn();
            }
            else
            {
                Item = new Magazyn();
            }
            listaTowarow = (from towar in Db.Towar
                                where towar.czyAktywny == true
                                select towar).ToList();
            listaZamowien = (from zamowienie in Db.Zamowienia
                             where zamowienie.czyAktywne == true
                             select zamowienie).ToList();
           
        }
        public int? towar
        {
            get
            {
                return Item.towar;
            }
            set
            {
                if (value != Item.towar)
                {
                    Item.towar = value;
                    base.OnPropertyChanged(() => towar);
                }
            }
        }
        public int? ilosc
        {
            get
            {
                return Item.ilosc;
            }
            set
            {
                if (value != Item.ilosc)
                {
                    Item.ilosc = value;
                    base.OnPropertyChanged(() => ilosc);
                }
            }
        }
        public int? zamowienie
        {
            get
            {
                return Item.ostatnieZamowienie;
            }
            set
            {
                if (value != Item.ostatnieZamowienie)
                {
                    Item.ostatnieZamowienie = value;
                    base.OnPropertyChanged(() => zamowienie);
                }
            }
        }
        public decimal? wartosc
        {
            get
            {
                return Item.wartoscTowaru;
            }
            set
            {
                if (value != Item.wartoscTowaru)
                {
                    Item.wartoscTowaru = value;
                    base.OnPropertyChanged(() => wartosc);
                }
            }
        }
        private BaseCommand _DodajTowar;
        public ICommand DodajTowar
        {
            get
            {
                if (_DodajTowar == null)
                {
                    _DodajTowar = new BaseCommand(() => Messenger.Default.Send("Dodaj towar"));
                }
                return _DodajTowar;
            }
        }
        public override void Save()
        {
            if (isModified)
            {

                newItem.towar = Item.towar;
                newItem.ilosc = Item.ilosc;
                newItem.ostatnieZamowienie = Item.ostatnieZamowienie;
                newItem.wartoscTowaru = Item.wartoscTowaru;
                newItem.czyAktywne = true;
                Db.Magazyn.AddObject(newItem);
                Db.Magazyn.SingleOrDefault(item => item.id == Item.id).czyAktywne = false;
                Db.SaveChanges();

            }
            else
            {
                Item.czyAktywne = true;
                Db.Magazyn.AddObject(Item);
                Db.SaveChanges();
            }
        }
    }
}
