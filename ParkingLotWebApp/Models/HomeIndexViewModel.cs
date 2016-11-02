using System.Collections.Generic;

namespace ParkingLotWebApp.Models
{
    public class HomeIndexViewModel
    {
        private Dictionary<int, string> areas;
        public Dictionary<int, string> Areas { get { return areas; } }

        private Dictionary<int, List<vw_ParkingLotGridRemain>> reminsummary;
        public Dictionary<int, List<vw_ParkingLotGridRemain>> RemainSummary { get { return reminsummary; } }

        private Dictionary<int, bool> objSelected;
        public Dictionary<int, bool> SelectedAreas { get { return objSelected; } }
        public HomeIndexViewModel()
        {
            reminsummary = new Dictionary<int, List<vw_ParkingLotGridRemain>>();
            areas = new Dictionary<int, string>();
            objSelected = new Dictionary<int, bool>();
        }
    }
}