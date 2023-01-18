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
        public DateTime Od { get; set; } 
        public DateTime Do { get; set; }

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
