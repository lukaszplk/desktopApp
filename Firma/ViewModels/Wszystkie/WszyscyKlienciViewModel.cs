using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszyscyKlienciViewModel : collectionViewModel<KlientForAllView>
    {
        public WszyscyKlienciViewModel()
            :base("Wszyscy klienci")
        {
        }

        public override void Load()
        {
            List = new ObservableCollection<KlientForAllView>
                (
                    from klient in fakturaEntities.Klient
                    where klient.czyAktywny == true
                    select new KlientForAllView
                    {
                        Imie = klient.imie,
                        Nazwisko = klient.nazwisko,
                        Miejscowosc = klient.Adres1.miasto + ", " + klient.Adres1.kodPocztowy,
                        Firma = klient.Firma_zew1.nazwa
                    }

                );
        }
        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj klienta");
        }
    }
}
