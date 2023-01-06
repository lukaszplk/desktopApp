using System;
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
    public class WszystkieStanowiskaViewModel : collectionViewModel<Stanowisko>
    {
        public WszystkieStanowiskaViewModel()
            :base("Wszystkie stanowiska")
        {

        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj stanowisko");
        }

        public override void Load()
        {
            List = new ObservableCollection<Stanowisko>
                (
                    from item in fakturaEntities.Stanowisko
                    where item.czyAktywny == true
                    select item

                );
        }
    }
}
