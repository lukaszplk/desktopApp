using Firma.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Raporty
{
    public abstract class RaportBaseViewModel : WorkspaceViewModel
    {
        private DateTime _od;
        public DateTime Od
        {
            get
            {
                return _od;
            }
            set
            {
                if (value != _od)
                {
                    _od = value;
                    base.OnPropertyChanged(() => Od);
                }
            }
        }
        private DateTime _do;
        public DateTime Do
        {
            get
            {
                return _do;
            }
            set
            {
                if (value != _do)
                {
                    _do = value;
                    base.OnPropertyChanged(() => Do);
                }
            }
        }

        private decimal _result;
        public decimal Result {
            get
            {
                return _result;
            }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    base.OnPropertyChanged(() => Result);
                }
            }
        }
        public RaportBaseViewModel(string name)
        {
            this.DisplayName = name;
            Od = DateTime.Now;
            Do = DateTime.Now;
            
        }

        private BaseCommand _RunRaportCommand;
        public ICommand RunRaportCommand
        {
            get
            {
                if (_RunRaportCommand == null)
                {
                    _RunRaportCommand=new BaseCommand(() => RunRaport());
                }
                return _RunRaportCommand;
            }
            set
            {
                if (_RunRaportCommand != value)
                {
                    _RunRaportCommand = (BaseCommand)value;
                }
            }
        }
        public abstract decimal RunRaport();

    }
}
