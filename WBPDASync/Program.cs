using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Devices;
using System.IO;
using RestSharp;
using System.Collections.ObjectModel;

namespace WBPDASync
{
    [Serializable]
    public class SyncDataViewModel
    {
        public SyncDataViewModel()
        {
            ETCBinding = new Collection<ETCBinding>();
            CarPurposeTypes = new Collection<CarPurposeTypes>();
        }
        public virtual ICollection<ETCBinding> ETCBinding { get; set; }

        public virtual ICollection<CarPurposeTypes> CarPurposeTypes { get; set; }
    }

    class Program
    {
        static RemoteDeviceManager devmgr;

        static void Main(string[] args)
        {
            devmgr = new RemoteDeviceManager();

            foreach(var device in devmgr.Devices)
            {
                RemoteDevice PA692 = device;

                if (PA692 != null)
                {
                    Console.WriteLine("找到連接的裝置!");
                    Console.WriteLine("Device Name: {0}", PA692.Name);
                    Console.WriteLine("Device ID: {0}", PA692.DeviceId);
                    Console.WriteLine("Device Platform: {0}", PA692.Platform);
                    Console.WriteLine("Device OS Kernel Version: {0}", PA692.OSVersion);

                    if (RemoteFile.Exists(PA692, "\\Program Files\\wbeparkingpda\\wbeparking.db"))
                    {
                        Console.WriteLine("資料庫檔案存在!");

                        string CurrentFolder = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                        string SyncRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), PA692.Platform);

                        if (Directory.Exists(SyncRoot) == false)
                        {
                            Directory.CreateDirectory(SyncRoot);
                        }

                        string SyncForDevice = Path.Combine(SyncRoot, PA692.DeviceId.ToString("N"));

                        if (Directory.Exists(SyncForDevice) == false)
                        {
                            Directory.CreateDirectory(SyncForDevice);
                        }

                        string DevicePath = "\\Program Files\\wbeparkingpda\\wbeparking.db";
                        string DBFileName = Path.Combine(SyncForDevice, "wbeparking.db");
                        Console.WriteLine("從裝置路徑 {0} 複製檔案到 {1}...", DevicePath, DBFileName);
                        RemoteFile.CopyFileFromDevice(PA692, DevicePath, DBFileName, true);
                        Console.WriteLine("複製成功!");

                        
                        Console.WriteLine("開啟資料庫...");
                        WBSQLiteModelContainer1 sqldb = new WBPDASync.WBSQLiteModelContainer1(string.Format("metadata=res://*/WBSQLiteModel.csdl|res://*/WBSQLiteModel.ssdl|res://*/WBSQLiteModel.msl;provider=System.Data.SQLite.EF6;provider connection string=\"data source={0}\"", DBFileName));
                        Console.WriteLine("開啟資料庫成功!");
                        //WBSQLiteModelContainer1 sqldb = new WBPDASync.WBSQLiteModelContainer1();
                        var etags = sqldb.ETCBinding.Distinct().OrderBy(o => o.ETCID);
                        SyncDataViewModel db = new SyncDataViewModel();

                        if (etags.Count()>0)
                        {                            
                            foreach(var tag in etags)
                            {
                                db.ETCBinding.Add(tag);
                                Console.WriteLine("找到{0}->{1}", tag.ETCID, tag.CarID);
                            }

                            db.CarPurposeTypes = new Collection<CarPurposeTypes>(db.CarPurposeTypes.ToList());
                        }

                        Console.WriteLine("同步資料庫中...");
                        db = StartSyncDB(db);
                        Console.WriteLine("同步資料庫成功!");
                        sqldb.Dispose();                        
                    }

                }
            }
        
        }

        static SyncDataViewModel StartSyncDB(SyncDataViewModel sqlitedb)
        {
            var client = new RestClient("http://localhost:57276/api/SQLiteSync");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;           
            request.AddBody(sqlitedb);
            //request.AddHeader("postman-token", "1293d735-dc97-9b40-ea71-48bc269b2f9b");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");         
            IRestResponse<SyncDataViewModel> response = client.Execute<SyncDataViewModel>(request);  
                      
            Console.Write(response.Content);
            Console.WriteLine();


            sqlitedb = response.Data;
            return sqlitedb;
        }
    }
}
