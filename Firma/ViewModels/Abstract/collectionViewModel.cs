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
        public List<string> SortComboBoxItems { get; set; }
        public List<string> SearchComboBoxItems { get; set; }
        public List<T> ListCopy { get; set; }
        public bool descending { get; set; }
        public string SortField { get; set; }
        public string SearchField { get; set; }
        private ICommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if(_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new BaseCommand(() => Search());
                }
                return _SearchCommand;
            }
        }
        private ICommand _ReloadCommand;
        public ICommand ReloadCommand
        {
            get
            {
                if (_ReloadCommand == null)
                {
                    _ReloadCommand = new BaseCommand(() => Load());
                }
                return _ReloadCommand;
            }
        }
        private ICommand _UsunCommand;
        public ICommand UsunCommand
        {
            get
            {
                if (_UsunCommand == null)
                {
                    _UsunCommand = new BaseCommand(() => Usun());
                }
                return _UsunCommand;
            }
        }
        public string SearchText { get; set; }
        #endregion
        #region Konstruktor
        public collectionViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.fakturaEntities = new projektEntities();
            SortComboBoxItems = GetSortComboBoxItems();
            SearchComboBoxItems = GetSearchComboBoxItems();
            //SearchField = SearchComboBoxItems.First();
            //SortField = SortComboBoxItems.First();
        }
        #endregion
        #region Helpers
        public abstract void Load();
        public abstract void Dodaj();
        public abstract void Usun();
        abstract protected List<string> GetSortComboBoxItems();
        abstract protected void Sort();
        abstract protected List<string> GetSearchComboBoxItems();
        abstract protected void Search();

        #endregion
        #region Commands
        private BaseCommand _DodajCommand;
        public ICommand DodajCommand
        {
            get
            {
                if (_DodajCommand == null)
                {
                    _DodajCommand = new BaseCommand(() => Dodaj());
                }
                return _DodajCommand;
            }
        }

        #endregion
    }
}
