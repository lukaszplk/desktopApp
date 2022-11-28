using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieSamochodyViewModel : collectionViewModel<Pojazd>
    {
        public WszystkieSamochodyViewModel()
            :base("Wszystkie samochody")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<Pojazd>
                (
                    from item in fakturaEntities.Pojazd
                    where item.czyAktywny == true
                    select item

                );
        }
    }
}
