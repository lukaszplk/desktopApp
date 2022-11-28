using Firma.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Firma.ViewModels.Wszystkie;
using Firma.ViewModels.Jeden;

namespace Firma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        
        #region Komendy menu i paska narzędzi
        public ICommand NowyTowarCommand 
        {
            get
            {
                return new BaseCommand(() => createView(new NowyTowarViewModel())); 
            }
        }
        

        public ICommand TowaryCommand
        {
            get
            {
                return new BaseCommand(showAllTowar);
            }
        }

        public ICommand NowaFakturaCommand 
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFakturaViewModel()));
            }
        }

        public ICommand FakturyCommand
        {
            get
            {
                return new BaseCommand(showAllFaktury);
            }
        }

        public ICommand SamochodyCommand
        {
            get
            {
                return new BaseCommand(showAllSamochody);
            }
        }

        public ICommand KlienciCommand
        {
            get
            {
                return new BaseCommand(showAllKlienci);
            }
        }

        public ICommand SamochodCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowySamochodViewModel()));
            }
        }

        public ICommand KlientCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyKlientViewModel()));
            }
        }

        //public ICommand UsunKlientCommand
        //{
        //    get
        //    {
        //        return new BaseCommand(() => createView(new UsuwanieKlientaViewModel()));
        //    }
        //}

        //public ICommand UsunTowarCommand
        //{
        //    get
        //    {
        //        return new BaseCommand(() => createView(new UsuwanieTowaruViewModel()));
        //    }
        //}

        //public ICommand UsunSamochodCommand
        //{
        //    get
        //    {
        //        return new BaseCommand(() => createView(new UsuwanieSamochodyViewModel()));
        //    }
        //}

        //public ICommand UsunFakturaCommand
        //{
        //    get
        //    {
        //        return new BaseCommand(() => createView(new UsuwanieFakturyViewModel()));
        //    }
        //}

        public ICommand CloseAllCommand
        {
            get
            {
                return new BaseCommand(closeAll);
            }
        }
        #endregion

        
        #region Przyciski w menu z lewej strony
        private ReadOnlyCollection<CommandViewModel> _Commands; 
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get 
            { 
                if (_Commands == null) 
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands; 
            }
        }

        private List<CommandViewModel> CreateCommands() 
        {
            return new List<CommandViewModel>
            {
                //new CommandViewModel("Towar", new BaseCommand(() => createView(new NowyTowarViewModel()))),
                //new CommandViewModel("Towary", new BaseCommand(showAllTowar)), 
                //new CommandViewModel("Faktura", new BaseCommand(() => createView(new NowaFakturaViewModel()))),
                new CommandViewModel("Faktury", new BaseCommand(showAllFaktury)),
                //new CommandViewModel("Samochod", new BaseCommand(() => createView(new NowySamochodViewModel()))),
                //new CommandViewModel("Samochody", new BaseCommand(showAllSamochody)),
                //new CommandViewModel("Klient", new BaseCommand(() => createView(new NowyKlientViewModel()))),
                new CommandViewModel("Klienci", new BaseCommand(showAllKlienci)),
                new CommandViewModel("Pracownicy", new BaseCommand(showAllPracownicy)),
                new CommandViewModel("Urlopy", new BaseCommand(showAllUrlopy)),
                new CommandViewModel("Rabaty", new BaseCommand(showAllRabaty)),
                //new CommandViewModel("dodaj adres", new BaseCommand(() => createView(new NowyAdresViewModel()))),
                //new CommandViewModel("dodaj auto", new BaseCommand(() => createView(new NowySamochodViewModel()))),
                //new CommandViewModel("dodaj stanowisko", new BaseCommand(() => createView(new NoweStanowiskoViewModel()))),
                //new CommandViewModel("dodaj firme", new BaseCommand(() => createView(new NowaFirmaViewModel()))),
                //new CommandViewModel("dodaj towar", new BaseCommand(() => createView(new NowyTowarViewModel()))),
                //new CommandViewModel("dodaj platnosc", new BaseCommand(() => createView(new NowySposobPlatnosciViewModel()))),
                //new CommandViewModel("dodaj usluge", new BaseCommand(() => createView(new NowaUslugaViewModel()))),
                new CommandViewModel("Towary", new BaseCommand(showAllTowar)),
                new CommandViewModel("Adresy", new BaseCommand(showAllAdresy)),
                new CommandViewModel("Pojazdy", new BaseCommand(showAllSamochody)),
                new CommandViewModel("Stanowiska", new BaseCommand(showAllStanowiska)),
                new CommandViewModel("Firmy", new BaseCommand(showAllFirmy)),
                new CommandViewModel("Sposoby platnosci", new BaseCommand(showAllSposobyPlatnosci)),
                new CommandViewModel("Uslugi", new BaseCommand(showAllUslugi))
            };
        }
        #endregion

        #region Zakładki
        private ObservableCollection<WorkspaceViewModel> _Workspaces; 
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }

        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e) 
        { 
            if (e.NewItems != null && e.NewItems.Count != 0) 
                foreach (WorkspaceViewModel workspace in e.NewItems) 
                    workspace.RequestClose += this.onWorkspaceRequestClose; 
            
            if (e.OldItems != null && e.OldItems.Count != 0) 
                foreach (WorkspaceViewModel workspace in e.OldItems) 
                    workspace.RequestClose -= this.onWorkspaceRequestClose; 
        }

        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel; 
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Funkcje pomocnicze
        

        private void setActiveWorkspace(WorkspaceViewModel workspace) 
        {
            Debug.Assert(this.Workspaces.Contains(workspace)); 
            
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces); 
            if (collectionView != null) 
                collectionView.MoveCurrentTo(workspace); 
        }

        private void createView(WorkspaceViewModel workspace)
        {
            Trace.WriteLine("Create view");
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }



        private void showAllTowar()
        {
            
            WszystkieTowaryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
            
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }
            
            this.setActiveWorkspace(workspace);

        }
        private void showAllRabaty()
        {

            WszystkieRabatyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieRabatyViewModel) as WszystkieRabatyViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieRabatyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);

        }
        private void showAllPracownicy()
        {

            WszyscyPracownicyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel) as WszyscyPracownicyViewModel;

            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);

        }
        private void showAllUrlopy()
        {

            WszystkieUrlopyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieUrlopyViewModel) as WszystkieUrlopyViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieUrlopyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);

        }
        private void showAllFaktury()
        {
            
            WszystkieFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKlienci()
        {
            WszyscyKlienciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyKlienciViewModel) as WszyscyKlienciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKlienciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }

        private void showAllSamochody()
        {
            WszystkieSamochodyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSamochodyViewModel) as WszystkieSamochodyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSamochodyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }
        private void showAllAdresy()
        {
            WszystkieAdresyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel) as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }
        private void showAllStanowiska()
        {
            WszystkieStanowiskaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieStanowiskaViewModel) as WszystkieStanowiskaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStanowiskaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }

        private void showAllFirmy()
        {
            WszystkieFirmyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFirmyViewModel) as WszystkieFirmyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFirmyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }

        private void showAllSposobyPlatnosci()
        {
            WszystkieSposobyPlatnosciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSposobyPlatnosciViewModel) as WszystkieSposobyPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSposobyPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }

        private void showAllUslugi()
        {
            WszystkieUslugiViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieUslugiViewModel) as WszystkieUslugiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUslugiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }

        //private void showAll<T>()
        //{
        //    WorkspaceViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is T);
        //    if (workspace == null)
        //    {
        //        T workspace = new T();
        //        this.Workspaces.Add(workspace);
        //    }
        //    this.setActiveWorkspace(workspace);
        //}


        //private void showAll(Type type)
        //{
        //    WorkspaceViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is type);
        //    if (workspace == null)
        //    {
        //        workspace = new type();
        //        this.Workspaces.Add(workspace);
        //    }
        //    this.setActiveWorkspace(workspace);
        //}

        private void closeAll()
        {
            this.Workspaces.Clear();
        }

        #endregion

        #region Konstruktor
        public MainWindowViewModel()
        {
            
        }
        #endregion
    }
}
