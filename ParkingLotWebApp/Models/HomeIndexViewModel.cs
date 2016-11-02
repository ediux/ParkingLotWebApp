using System.Collections.Generic;

namespace ParkingLotWebApp.Models
{
    public class HomeIndexViewModel
    {
        public Dictionary<string, IEnumerable<vw_ParkingLotGridRemain>> RemainSummary { get; set; }

        private Dictionary<string, bool> objSelected;
        public  Dictionary<string,bool> SelectedTowers { get { return objSelected; } }
        public HomeIndexViewModel()
        {
            objSelected = new Dictionary<string, bool>();
        }
    }
}