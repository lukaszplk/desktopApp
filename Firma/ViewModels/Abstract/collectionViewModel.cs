using Firma.Helpers;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    public abstract class collectionViewModel<T> :WorkspaceViewModel
    {
        #region Fields
        protected readonly projektEntities fakturaEntities;
        private BaseCommand _LoadCommand;
        private ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Konstruktor
        public collectionViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.fakturaEntities = new projektEntities();
        }
        #endregion
        #region Helpers
        public abstract void Load();
        #endregion
    }
}
