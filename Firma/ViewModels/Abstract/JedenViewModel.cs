using Firma.Helpers;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    public abstract class JedenViewModel : WorkspaceViewModel
    {
        #region Fields
        public projektEntities Db { get; set; }
        #endregion
        #region Konstruktor
        public JedenViewModel(string name)
        {
            base.DisplayName = name;
            Db = new projektEntities();
        }
       
        #endregion
        #region Commands
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }
        #endregion
        #region Save
        public abstract void Save();
        
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();
        }
        #endregion
    }
}

