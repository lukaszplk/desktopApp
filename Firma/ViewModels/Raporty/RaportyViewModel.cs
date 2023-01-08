using Firma.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Raporty
{
    public class RaportyViewModel : WorkspaceViewModel
    {
        public RaportyViewModel()
        {
            this.DisplayName = "Raporty";
        }

        private BaseCommand _RaportSprzedazyCommand;
        public ICommand RaportSprzedazyCommand
        {
            get
            {
                if (_RaportSprzedazyCommand == null)
                {
                    _RaportSprzedazyCommand = new BaseCommand(() => Messenger.Default.Send("Raport sprzedazy"));
                }
                return _RaportSprzedazyCommand;
            }
        }
        private BaseCommand _StanMagazynowyCommand;
        public ICommand StanMagazynowyCommand
        {
            get
            {
                if (_StanMagazynowyCommand == null)
                {
                    _StanMagazynowyCommand = new BaseCommand(() => Messenger.Default.Send("Stan magazynowy"));
                }
                return _StanMagazynowyCommand;
            }
        }
        private BaseCommand _AktywniPracCommand;
        public ICommand AktywniPracCommand
        {
            get
            {
                if (_AktywniPracCommand == null)
                {
                    _AktywniPracCommand = new BaseCommand(() => Messenger.Default.Send("Aktywni pracownicy"));
                }
                return _AktywniPracCommand;
            }
        }

    }
}
