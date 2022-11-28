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
    public class WszystkieFirmyViewModel : collectionViewModel<Firma_zew>
    {
        public WszystkieFirmyViewModel()
            :base("Wszystkie firmy")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<Firma_zew>
                (
                    from item in fakturaEntities.Firma_zew
                    where item.czyAktywny == true
                    select item

                );
        }
    }
}
