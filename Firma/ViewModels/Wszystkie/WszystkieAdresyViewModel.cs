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
    public class WszystkieAdresyViewModel : collectionViewModel<Adres>
    {
        public WszystkieAdresyViewModel()
            :base("Adresy")
        {
        }

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                    from adres in fakturaEntities.Adres
                    where adres.czyAktywny == true
                    select adres

                );
        }
        #endregion
    }
}
