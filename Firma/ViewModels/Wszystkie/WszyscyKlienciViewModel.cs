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
    public class WszyscyKlienciViewModel : collectionViewModel<Klient>
    {
        public WszyscyKlienciViewModel()
            :base("Wszyscy klienci")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<Klient>
                (
                    from adres in fakturaEntities.Klient
                    where adres.czyAktywny == true
                    select adres

                );
        }
    }
}
