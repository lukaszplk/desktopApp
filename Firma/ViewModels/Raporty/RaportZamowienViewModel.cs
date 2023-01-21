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
    public class RaportZamowienViewModel : RaportBaseViewModel
    {
        private ZamowieniaLogic logic;
        private decimal? total { get; set; }
        private List<ZamowieniaRaportForView> _List;
        public List<ZamowieniaRaportForView> List
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

        public RaportZamowienViewModel() : base("Raport zamowien")
        {
            logic = new ZamowieniaLogic(new projektEntities());
        }

        public override decimal RunRaport()
        {
            logic.Od = Od;
            logic.Do = Do;
            (List, total) = logic.RaportZamowien();
            Result = (decimal)total;
            return 0;
        }
    }

}

