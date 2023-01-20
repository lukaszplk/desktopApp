using Firma.Models.BusinessLogic;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels.Raporty
{
    public class StanMagazynowyViewModel : RaportBaseViewModel
    {
        private MagazynLogic logic;
        private List<StanMagazynowyForView> _List;
        public List<StanMagazynowyForView> List
        {
            get
            {
                return _List;
            }
            set
            {
                if (value != _List)
                {
                    _List = value;
                    base.OnPropertyChanged(() => List);
                }
            }
        }
        
        public StanMagazynowyViewModel():base("Stan magazynowy")
        {
            logic = new MagazynLogic(new projektEntities());
        }

        public override decimal RunRaport()
        {
            List = logic.StanMagazynowy();
            return 0;
        }
    }
}
