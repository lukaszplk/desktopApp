using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieSposobyPlatnosciViewModel : collectionViewModel<SposobPlatnosci>
    {
        public WszystkieSposobyPlatnosciViewModel()
            :base("Wszystkie sposoby platnosci")
        {

        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj sposob platnosci");
        }

        public override void Load()
        {
            List = new ObservableCollection<SposobPlatnosci>
                (
                    from item in fakturaEntities.SposobPlatnosci
                    where item.czyAktywny == true
                    select item

                );
        }
    }
}
