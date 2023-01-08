using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Firma.ViewModels;
using Firma.ViewModels.Raporty;
using Firma.ViewModels.Jeden;
using Firma.ViewModels.Wszystkie;
using Firma.Views.Jeden;
using Firma.Views.Raporty;
using Firma.Views.Wszystkie;

namespace Firma.Helpers
{
    public class WindowComposer
    {
        public static void OpenNewWindow(WorkspaceViewModel viewModel)
        {
            Window window = new Window();
            UserControl userControl = GetViewOfViewModel(viewModel);
            userControl.DataContext = viewModel;
            window.Content = userControl;
            window.Title = viewModel.DisplayName;
            window.Show();
        }
        private static UserControl GetViewOfViewModel(WorkspaceViewModel vm)
        {
            if(vm.GetType() == typeof(NowyTowarViewModel))
            {
                return new NowyTowarView();
            }
            else if (vm.GetType() == typeof(AktywniPracownicyViewModel))
            {
                return new AktywniPracownicyView();
            }
            else if (vm.GetType() == typeof(StanMagazynowyViewModel))
            {
                return new StanMagazynowyView();
            }
            else if (vm.GetType() == typeof(RaportSprzedazyViewModel))
            {
                return new RaportSprzedazyView();
            }
            else
            {
                return null;
            }
        }
    }
}
