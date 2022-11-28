using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieUrlopyViewModel : collectionViewModel<UrlopForAllView>
    {
        public WszystkieUrlopyViewModel()
            : base("Wszystkie urlopy")
        {

        }

        public override void Load()
        {
            List = new ObservableCollection<UrlopForAllView>
                (
                    from item in fakturaEntities.Urlop
                    where item.czyAktywny == true
                    select new UrlopForAllView
                    {
                        IdUrlopu = item.idUrlopu,
                        Pracownik = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                        Zatwierdzajacy = item.Pracownik1.imie + " " + item.Pracownik1.nazwisko,
                        DataRozpoczecia = item.dataRozpoczecia,
                        DataZakonczenia = item.dataZakonczenia,
                        Uzasadnienie = item.uzasadnienie,
                        CzyZatwierdzony = item.czyZatwierdzony,
                        CzyPlatny = item.czyPlatny
                        
        
    }

                );
        }
    }
}
