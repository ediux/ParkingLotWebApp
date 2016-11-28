using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class Counter_ParkingDetail
    {
        public Counter_ParkingDetail()
        {
            _id = 0;
            _name = string.Empty;
        }
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private int _count;
        public int Count { get { return _count; } set { _count = value; } }

        private int _rfidcount;

        public int RFIDCount { get { return _rfidcount; } set { _rfidcount = value; } }

        private int _total;
        public int Total { get { return _total; } set { _total = value;
            } }
    }

    public class CounterViewModel
    {
        public CounterViewModel()
        {
            parkingAreas = new List<Models.Counter_ParkingDetail>();
        }
        private List<Counter_ParkingDetail> parkingAreas;
        public List< Counter_ParkingDetail> ParkingAreas { get { return parkingAreas; } set { parkingAreas = value; } }
    }
}