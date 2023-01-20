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
using Firma.ViewModels.Raporty;
using GalaSoft.MvvmLight.Messaging;


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
            Messenger.Default.Register<string>(this, open);
            Messenger.Default.Register<IDictionary<string, string>>(this, modify);
            return new List<CommandViewModel>
            {
                //new CommandViewModel("Towar", new BaseCommand(() => createView(new NowyTowarViewModel()))),
                //new CommandViewModel("Nowy pracownik", new BaseCommand(() => createView(new NowyPracownikViewModel()))),
                //new CommandViewModel("Faktura", new BaseCommand(() => createView(new NowaFakturaViewModel()))),
                //new CommandViewModel("Samochod", new BaseCommand(() => createView(new NowySamochodViewModel()))),
                //new CommandViewModel("Klient", new BaseCommand(() => createView(new NowyKlientViewModel()))),
                //new CommandViewModel("dodaj adres", new BaseCommand(() => createView(new NowyAdresViewModel()))),
                //new CommandViewModel("dodaj auto", new BaseCommand(() => createView(new NowySamochodViewModel()))),
                //new CommandViewModel("dodaj stanowisko", new BaseCommand(() => createView(new NoweStanowiskoViewModel()))),
                //new CommandViewModel("dodaj firme", new BaseCommand(() => createView(new NowaFirmaViewModel()))),
                //new CommandViewModel("dodaj towar", new BaseCommand(() => createView(new NowyTowarViewModel()))),
                //new CommandViewModel("dodaj platnosc", new BaseCommand(() => createView(new NowySposobPlatnosciViewModel()))),
                //new CommandViewModel("dodaj usluge", new BaseCommand(() => createView(new NowaUslugaViewModel()))),
                new CommandViewModel("Faktury", new BaseCommand(showAllFaktury)),
                new CommandViewModel("Klienci", new BaseCommand(showAllKlienci)),
                new CommandViewModel("Pracownicy", new BaseCommand(showAllPracownicy)),
                new CommandViewModel("Urlopy", new BaseCommand(showAllUrlopy)),
                new CommandViewModel("Rabaty", new BaseCommand(showAllRabaty)),
                new CommandViewModel("Magazyn", new BaseCommand(showAllMagazyn)),  
                new CommandViewModel("Towary", new BaseCommand(showAllTowar)),
                new CommandViewModel("Adresy", new BaseCommand(showAllAdresy)),
                new CommandViewModel("Pojazdy", new BaseCommand(showAllSamochody)),
                new CommandViewModel("Stanowiska", new BaseCommand(showAllStanowiska)),
                new CommandViewModel("Firmy", new BaseCommand(showAllFirmy)),
                new CommandViewModel("Sposoby platnosci", new BaseCommand(showAllSposobyPlatnosci)),
                new CommandViewModel("Uslugi", new BaseCommand(showAllUslugi)),
                new CommandViewModel("Zlecenia", new BaseCommand(showAllZlecenia)),
                new CommandViewModel("Zamowienia", new BaseCommand(showAllZamowienia)),
                new CommandViewModel("Raporty", new BaseCommand(() => createView(new RaportyViewModel())))
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
        private void modify(IDictionary<string, string> json)
        {
            if(json["Operation"]== "Modyfikuj klienta")
            {
                createView(new NowyKlientViewModel(Int32.Parse(json["Id"]), "Modyfikuj klienta"));
            }else if (json["Operation"] == "Modyfikuj pracownika")
            {
                createView(new NowyPracownikViewModel(Int32.Parse(json["Id"]), "Modyfikuj pracownika"));
            }
            else if (json["Operation"] == "Modyfikuj adres")
            {
                createView(new NowyAdresViewModel(Int32.Parse(json["Id"]), "Modyfikuj adres"));
            }
            else if (json["Operation"] == "Modyfikuj fakture")
            {
                createView(new NowaFakturaViewModel(Int32.Parse(json["Id"]), "Modyfikuj fakture"));
            }
            else if (json["Operation"] == "Modyfikuj firme")
            {
                createView(new NowaFirmaViewModel(Int32.Parse(json["Id"]), "Modyfikuj firme"));
            }
            else if (json["Operation"] == "Modyfikuj magazyn")
            {
                createView(new NowyMagazynViewModel(Int32.Parse(json["Id"]), "Modyfikuj magazyn"));
            }
            else if (json["Operation"] == "Modyfikuj rabat")
            {
                createView(new NowyRabatViewModel(Int32.Parse(json["Id"]), "Modyfikuj rabat"));
            }
            else if (json["Operation"] == "Modyfikuj samochod")
            {
                createView(new NowySamochodViewModel(Int32.Parse(json["Id"]), "Modyfikuj samochod"));
            }
            else if (json["Operation"] == "Modyfikuj sposob platnosci")
            {
                createView(new NowySposobPlatnosciViewModel(Int32.Parse(json["Id"]), "Modyfikuj sposob platnosci"));
            }
            else if (json["Operation"] == "Modyfikuj usluge")
            {
                createView(new NowaUslugaViewModel(Int32.Parse(json["Id"]), "Modyfikuj usluge"));
            }
            else if (json["Operation"] == "Modyfikuj stanowisko")
            {
                createView(new NoweStanowiskoViewModel(Int32.Parse(json["Id"]), "Modyfikuj stanowisko"));
            }
            else if (json["Operation"] == "Modyfikuj towar")
            {
                createView(new NowyTowarViewModel(Int32.Parse(json["Id"]), "Modyfikuj towar"));
            }
            else if (json["Operation"] == "Modyfikuj urlop")
            {
                createView(new NowyUrlopViewModel(Int32.Parse(json["Id"]), "Modyfikuj urlop"));
            }
            else if (json["Operation"] == "Modyfikuj zlecenie")
            {
                createView(new NoweZlecenieViewModel(Int32.Parse(json["Id"]), "Modyfikuj zlecenie"));
            }
            else if (json["Operation"] == "Modyfikuj zamowienie")
            {
                createView(new NoweZamowienieViewModel(Int32.Parse(json["Id"]), "Modyfikuj zamowienie"));
            }
        }
        private void open(string name)
        {

            if(name=="Dodaj klienta")
            {
                createView(new NowyKlientViewModel());
            }
            else if (name == "Dodaj pracownika")
            {
                createView(new NowyPracownikViewModel());
            }
            else if (name == "Dodaj adres")
            {
                createView(new NowyAdresViewModel());
            }
            else if (name == "Dodaj fakture")
            {
                createView(new NowaFakturaViewModel());
            }
            else if (name == "Dodaj firme")
            {
                createView(new NowaFirmaViewModel());
            }
            else if (name == "Dodaj magazyn")
            {
                createView(new NowyMagazynViewModel());
            }
            else if (name == "Dodaj rabat")
            {
                createView(new NowyRabatViewModel());
            }
            else if (name == "Dodaj samochod")
            {
                createView(new NowySamochodViewModel());
            }
            else if (name == "Dodaj sposob platnosci")
            {
                createView(new NowySposobPlatnosciViewModel());
            }
            else if (name == "Dodaj stanowisko")
            {
                createView(new NoweStanowiskoViewModel());
            }
            else if (name == "Dodaj towar")
            {
                createView(new NowyTowarViewModel());
            }
            else if (name == "Dodaj urlop")
            {
                createView(new NowyUrlopViewModel());
            }
            else if (name == "Dodaj usluge")
            {
                createView(new NowaUslugaViewModel());
            }
            else if (name == "Dodaj zamowienie")
            {
                createView(new NoweZamowienieViewModel());
            }
            else if (name == "Dodaj zlecenie")
            {
                createView(new NoweZlecenieViewModel());
            }
            else if (name == "Raport sprzedazy")
            {
                WindowComposer.OpenNewWindow(new RaportSprzedazyViewModel());
            }
            else if (name == "Stan magazynowy")
            {
                WindowComposer.OpenNewWindow(new StanMagazynowyViewModel());
            }
            else if (name == "Aktywni pracownicy")
            {
                WindowComposer.OpenNewWindow(new AktywniPracownicyViewModel());
            }

        }

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
        private void showAllZlecenia()
        {

            WszystkieZleceniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieZleceniaViewModel) as WszystkieZleceniaViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieZleceniaViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);

        }
        private void showAllZamowienia()
        {

            WszystkieZamowieniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieZamowieniaViewModel) as WszystkieZamowieniaViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieZamowieniaViewModel();
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
        private void showAllMagazyn()
        {

            WszystkieMagazynViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieMagazynViewModel) as WszystkieMagazynViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieMagazynViewModel();
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
