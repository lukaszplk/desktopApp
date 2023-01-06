﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.ViewModels.Abstract;
using Firma.Models.Entities;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieUslugiViewModel : collectionViewModel<Usluga>
    {
        public WszystkieUslugiViewModel()
            :base("Wszystkie Uslugi")
        {

        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj usluge");
        }

        public override void Load()
        {
            List = new ObservableCollection<Usluga>
                (
                    from item in fakturaEntities.Usluga
                    where item.czyAktywna == true
                    select item

                );
        }
    }
}
