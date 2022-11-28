using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.EntitiesForView;
using System.Collections.ObjectModel;

namespace Firma.ViewModels.Wszystkie
{
        public class WszystkieZleceniaViewModel : collectionViewModel<ZlecenieForAllView>
        {
            public WszystkieZleceniaViewModel()
                : base("Wszystkie zlecenia")
            {

            }

            public override void Load()
            {
                List = new ObservableCollection<ZlecenieForAllView>
                    (
                        from item in fakturaEntities.Zlecenia
                        where item.czyAktywne == true
                        select new ZlecenieForAllView
                        {
                            Id = item.idZlecenia,
                            Pracownik = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                            Usluga = item.Usluga1.nazwaUslugi,
                            Adres = item.Adres1.kodPocztowy + ", " + item.Adres1.miasto,
                            Faktura = item.Faktura1.numer,
                            Data = item.dataZlecenia
                        }

                    );
            }
        }
    
}
