﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingLotWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WbParkSystemEntities : DbContext
    {
        public WbParkSystemEntities()
            : base("name=WbParkSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnnouncementDetail> AnnouncementDetail { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<PushPhoneType> PushPhoneType { get; set; }
        public virtual DbSet<CarPurposeTypes> CarPurposeTypes { get; set; }
        public virtual DbSet<ParkingArea> ParkingArea { get; set; }
        public virtual DbSet<ParkingLotsDetail> ParkingLotsDetail { get; set; }
        public virtual DbSet<ParkingLotsFloor> ParkingLotsFloor { get; set; }
        public virtual DbSet<ParkingLotsRecord> ParkingLotsRecord { get; set; }
        public virtual DbSet<ParkingLotsRecord_HT> ParkingLotsRecord_HT { get; set; }
        public virtual DbSet<PushPhoneDetail> PushPhoneDetail { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<ETAs> ETAs { get; set; }
    
        public virtual int API_CancelPushPhone(string deviceID, string carID, string carType)
        {
            var deviceIDParameter = deviceID != null ?
                new ObjectParameter("DeviceID", deviceID) :
                new ObjectParameter("DeviceID", typeof(string));
    
            var carIDParameter = carID != null ?
                new ObjectParameter("CarID", carID) :
                new ObjectParameter("CarID", typeof(string));
    
            var carTypeParameter = carType != null ?
                new ObjectParameter("CarType", carType) :
                new ObjectParameter("CarType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("API_CancelPushPhone", deviceIDParameter, carIDParameter, carTypeParameter);
        }
    
        public virtual ObjectResult<API_GetAnnouncement_Result> API_GetAnnouncement()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_GetAnnouncement_Result>("API_GetAnnouncement");
        }
    
        public virtual ObjectResult<API_GetArea_Result> API_GetArea()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_GetArea_Result>("API_GetArea");
        }
    
        public virtual ObjectResult<API_GetFloorsGrid_Result> API_GetFloorsGrid(Nullable<int> parkingLotsID)
        {
            var parkingLotsIDParameter = parkingLotsID.HasValue ?
                new ObjectParameter("ParkingLotsID", parkingLotsID) :
                new ObjectParameter("ParkingLotsID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_GetFloorsGrid_Result>("API_GetFloorsGrid", parkingLotsIDParameter);
        }
    
        public virtual ObjectResult<API_GetLotsDetail_Result> API_GetLotsDetail(Nullable<int> areaID)
        {
            var areaIDParameter = areaID.HasValue ?
                new ObjectParameter("AreaID", areaID) :
                new ObjectParameter("AreaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_GetLotsDetail_Result>("API_GetLotsDetail", areaIDParameter);
        }
    
        public virtual ObjectResult<API_GetLotsGrid_Result> API_GetLotsGrid(Nullable<int> areaID)
        {
            var areaIDParameter = areaID.HasValue ?
                new ObjectParameter("AreaID", areaID) :
                new ObjectParameter("AreaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<API_GetLotsGrid_Result>("API_GetLotsGrid", areaIDParameter);
        }
    
        public virtual int API_UpdatePushPhone(Nullable<byte> phoneTypeID, string deviceID, string token, string phoneNumber, string carID, string carType)
        {
            var phoneTypeIDParameter = phoneTypeID.HasValue ?
                new ObjectParameter("PhoneTypeID", phoneTypeID) :
                new ObjectParameter("PhoneTypeID", typeof(byte));
    
            var deviceIDParameter = deviceID != null ?
                new ObjectParameter("DeviceID", deviceID) :
                new ObjectParameter("DeviceID", typeof(string));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var carIDParameter = carID != null ?
                new ObjectParameter("CarID", carID) :
                new ObjectParameter("CarID", typeof(string));
    
            var carTypeParameter = carType != null ?
                new ObjectParameter("CarType", carType) :
                new ObjectParameter("CarType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("API_UpdatePushPhone", phoneTypeIDParameter, deviceIDParameter, tokenParameter, phoneNumberParameter, carIDParameter, carTypeParameter);
        }
    }
}
