using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Firma.Helpers;
using Firma.Models.Entities;
using System.Collections.ObjectModel;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;

namespace Firma.ViewModels.Wszystkie
{
    public class WszystkieTowaryViewModel : collectionViewModel<Towar>
    {
        
        #region Konstruktor
        public WszystkieTowaryViewModel()
            :base("Towary")
        {
        }

        public override void Dodaj()
        {
            Messenger.Default.Send("Dodaj towar");
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Towar>
                (
                    from towar in fakturaEntities.Towar
                    where towar.czyAktywny == true
                    select towar
                    
                );
        }
        #endregion
    }
}
