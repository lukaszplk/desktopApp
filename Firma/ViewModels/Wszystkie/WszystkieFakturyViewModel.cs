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
    public class WszystkieFakturyViewModel : collectionViewModel<Faktura>
    {
        #region Konstruktor
        public WszystkieFakturyViewModel()
            :base("Wszystkie faktury")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<Faktura>
                (
                    from item in fakturaEntities.Faktura
                    where item.czyAktywna == true
                    select item

                );
        }
        #endregion
    }
}
