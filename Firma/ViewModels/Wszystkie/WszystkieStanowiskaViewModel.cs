using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.ViewModels.Abstract;
using Firma.Models.Entities;
using System.Collections.ObjectModel;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieStanowiskaViewModel : collectionViewModel<Stanowisko>
    {
        public WszystkieStanowiskaViewModel()
            :base("Wszystkie stanowiska")
        {

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
