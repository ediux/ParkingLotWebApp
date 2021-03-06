USE [WbParkSystem]
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', N'COLUMN',N'Void'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower', @level2type=N'COLUMN',@level2name=N'Void'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', N'COLUMN',N'Name'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower', @level2type=N'COLUMN',@level2name=N'Name'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', N'COLUMN',N'ID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower', @level2type=N'COLUMN',@level2name=N'ID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'Name'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'Name'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'PowerTypeID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'PowerTypeID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'Password'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'Password'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'Account'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'Account'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'ID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'ID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneType', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneType'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneType', N'COLUMN',N'PushPhone'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneType', @level2type=N'COLUMN',@level2name=N'PushPhone'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneType', N'COLUMN',N'ID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneType', @level2type=N'COLUMN',@level2name=N'ID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'LastUpdate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'Void'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'Void'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'PhoneNumber'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'PhoneNumber'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'Token'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'Token'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'DeviceID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'DeviceID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'PhoneTypeID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'PhoneTypeID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'Count'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'Count'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'ParkDate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'ParkDate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'LogTime'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'LogTime'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'ID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'ID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'Count'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'Count'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'ParkDate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'ParkDate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'LogTime'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'LogTime'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'ID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'ID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'LastUpdate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'Void'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'Void'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'MotoLastGrid'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'MotoLastGrid'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'MotoTotalGrid'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'MotoTotalGrid'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'CarLastGrid'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'CarLastGrid'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'CarTotalGrid'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'CarTotalGrid'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'FloorName'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'FloorName'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'FloorOrder'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'FloorOrder'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'ParkingLotsID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'ParkingLotsID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'LastUpdate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Void'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Void'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Latitude'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Latitude'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Longitude'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Longitude'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Charge'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Charge'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Period'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Period'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Tel'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Tel'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Address'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Address'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Name'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Name'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'ID'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'ID'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'LastUpdateTime'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'LastUpdateUserId'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'LastUpdateUserId'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'CreateTime'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'CreateTime'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'CreateUserId'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'CreateUserId'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'Name'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'Name'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'LastUpdate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'ToTop'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'ToTop'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'Detail'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'Detail'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'Title'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'Title'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'EndDate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'EndDate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'StartDate'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'StartDate'

GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'No'))
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'No'

GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PushPhoneDetail_PushPhoneType]') AND parent_object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]'))
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [FK_PushPhoneDetail_PushPhoneType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PushPhoneDetail_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]'))
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [FK_PushPhoneDetail_Cars]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ParkingLotsFloor_ParkingLotsDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[ParkingLotsFloor]'))
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [FK_ParkingLotsFloor_ParkingLotsDetail]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_ToETAs]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_ToETAs]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_ToEmployee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_ToEmployee]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_CarPurposeTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_CarPurposeTypes]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserRole_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]'))
ALTER TABLE [dbo].[ApplicationUserRole] DROP CONSTRAINT [FK_ApplicationUserRole_ToApplicationUser]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserRole_ToApplicationRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]'))
ALTER TABLE [dbo].[ApplicationUserRole] DROP CONSTRAINT [FK_ApplicationUserRole_ToApplicationRole]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserLogin_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserLogin]'))
ALTER TABLE [dbo].[ApplicationUserLogin] DROP CONSTRAINT [FK_ApplicationUserLogin_ToApplicationUser]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserClaim_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserClaim]'))
ALTER TABLE [dbo].[ApplicationUserClaim] DROP CONSTRAINT [FK_ApplicationUserClaim_ToApplicationUser]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLoginPower_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLoginPower] DROP CONSTRAINT [DF_WebLoginPower_Void]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLoginPower_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLoginPower] DROP CONSTRAINT [DF_WebLoginPower_Name]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] DROP CONSTRAINT [DF_WebLogin_Name]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_PowerTypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] DROP CONSTRAINT [DF_WebLogin_PowerTypeID]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_Password]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] DROP CONSTRAINT [DF_WebLogin_Password]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_Account]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] DROP CONSTRAINT [DF_WebLogin_Account]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneType_PushPhoto]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneType] DROP CONSTRAINT [DF_PushPhoneType_PushPhoto]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF_PushPhoneDetail_LastUpdate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF_PushPhoneDetail_Void]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_PhoneNumber]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF_PushPhoneDetail_PhoneNumber]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_DeviceID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF_PushPhoneDetail_DeviceID]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__CarTy__43D61337]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF__tmp_ms_xx__CarTy__43D61337]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__PushPhone__CarID__4A8310C6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF__PushPhone__CarID__4A8310C6]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_PhoneType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] DROP CONSTRAINT [DF_Table_1_PhoneType]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecord_Count]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecord] DROP CONSTRAINT [DF_ParkingLotsRecord_Count]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecord_ParkDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecord] DROP CONSTRAINT [DF_ParkingLotsRecord_ParkDate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecord_LogTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecord] DROP CONSTRAINT [DF_ParkingLotsRecord_LogTime]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecoed_HT_Count]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecoed_HT] DROP CONSTRAINT [DF_ParkingLotsRecoed_HT_Count]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecoed_HT_ParkDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecoed_HT] DROP CONSTRAINT [DF_ParkingLotsRecoed_HT_ParkDate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecoed_HT_LogTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecoed_HT] DROP CONSTRAINT [DF_ParkingLotsRecoed_HT_LogTime]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_LastUpdate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_Void]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_MotoLastGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_MotoLastGrid]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_MotoTotalGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_MotoTotalGrid]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_CarLastGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_CarLastGrid]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_CarTotalGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_CarTotalGrid]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_FloorName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_FloorName]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_FloorOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] DROP CONSTRAINT [DF_ParkingLotsFloor_FloorOrder]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_LastUpdate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_Void]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_latitude]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_Table_1_latitude]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_longitude]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_Table_1_longitude]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Charge]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_Charge]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Period]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_Period]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Tel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_Tel]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_Address]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] DROP CONSTRAINT [DF_ParkingLotsDetail_Name]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__LastUpdate__693CA210]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] DROP CONSTRAINT [DF__ETAs__LastUpdate__693CA210]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__LastUpdate__68487DD7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] DROP CONSTRAINT [DF__ETAs__LastUpdate__68487DD7]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__CreateUTCT__6754599E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] DROP CONSTRAINT [DF__ETAs__CreateUTCT__6754599E]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__CreateUser__66603565]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] DROP CONSTRAINT [DF__ETAs__CreateUser__66603565]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__Void__656C112C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] DROP CONSTRAINT [DF__ETAs__Void__656C112C]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__Code__6477ECF3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] DROP CONSTRAINT [DF__ETAs__Code__6477ECF3]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__LastUp__6383C8BA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__LastUp__6383C8BA]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__LastUs__628FA481]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__LastUs__628FA481]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Create__619B8048]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__Create__619B8048]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Create__60A75C0F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__Create__60A75C0F]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Void__5FB337D6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__Void__5FB337D6]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Code__5EBF139D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__Code__5EBF139D]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Name__5DCAEF64]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [DF__Employee__Name__5DCAEF64]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__LastU__1EA48E88]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx__LastU__1EA48E88]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__LastU__1DB06A4F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx__LastU__1DB06A4F]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__Creat__1CBC4616]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx__Creat__1CBC4616]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__Creat__1BC821DD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx__Creat__1BC821DD]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx___Void__1AD3FDA4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx___Void__1AD3FDA4]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cars__EmpId__3D2915A8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__Cars__EmpId__3D2915A8]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cars__ETAId__3C34F16F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__Cars__ETAId__3C34F16F]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cars__CarPurpose__3B40CD36]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__Cars__CarPurpose__3B40CD36]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__CarTy__17036CC0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx__CarTy__17036CC0]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__CarNu__160F4887]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [DF__tmp_ms_xx__CarNu__160F4887]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__CarPurpose__Void__3A4CA8FD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CarPurposeTypes] DROP CONSTRAINT [DF__CarPurpose__Void__3A4CA8FD]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__CarPurpose__Name__395884C4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CarPurposeTypes] DROP CONSTRAINT [DF__CarPurpose__Name__395884C4]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Void__5629CD9C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUserRole] DROP CONSTRAINT [DF__Applicatio__Void__5629CD9C]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Acces__7A672E12]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__Acces__7A672E12]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__797309D9]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__LastU__797309D9]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__787EE5A0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__LastU__787EE5A0]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__778AC167]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__Creat__778AC167]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__76969D2E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__Creat__76969D2E]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_PhoneConfirmed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF_ApplicationUser_PhoneConfirmed]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_PhoneNumber]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF_ApplicationUser_PhoneNumber]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_EMailConfirmed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF_ApplicationUser_EMailConfirmed]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_EMail]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF_ApplicationUser_EMail]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_DisplayName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF_ApplicationUser_DisplayName]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Void__75A278F5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicatio__Void__75A278F5]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__TwoFa__74AE54BC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__TwoFa__74AE54BC]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__UserN__73BA3083]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] DROP CONSTRAINT [DF__Applicati__UserN__73BA3083]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__48CFD27E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] DROP CONSTRAINT [DF__Applicati__LastU__48CFD27E]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__47DBAE45]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] DROP CONSTRAINT [DF__Applicati__LastU__47DBAE45]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__46E78A0C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] DROP CONSTRAINT [DF__Applicati__Creat__46E78A0C]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__45F365D3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] DROP CONSTRAINT [DF__Applicati__Creat__45F365D3]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Void__44FF419A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] DROP CONSTRAINT [DF__Applicatio__Void__44FF419A]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Name__440B1D61]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] DROP CONSTRAINT [DF__Applicatio__Name__440B1D61]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] DROP CONSTRAINT [DF_AnnouncementDetail_LastUpdate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_ToTop]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] DROP CONSTRAINT [DF_AnnouncementDetail_ToTop]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_Detail]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] DROP CONSTRAINT [DF_AnnouncementDetail_Detail]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_Title]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] DROP CONSTRAINT [DF_AnnouncementDetail_Title]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_EndDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] DROP CONSTRAINT [DF_AnnouncementDetail_EndDate]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_StartDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] DROP CONSTRAINT [DF_AnnouncementDetail_StartDate]
END

GO
/****** Object:  Table [dbo].[WebLoginPower]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebLoginPower]') AND type in (N'U'))
DROP TABLE [dbo].[WebLoginPower]
GO
/****** Object:  Table [dbo].[WebLogin]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebLogin]') AND type in (N'U'))
DROP TABLE [dbo].[WebLogin]
GO
/****** Object:  Table [dbo].[PushPhoneType]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PushPhoneType]') AND type in (N'U'))
DROP TABLE [dbo].[PushPhoneType]
GO
/****** Object:  Table [dbo].[PushPhoneDetail]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]') AND type in (N'U'))
DROP TABLE [dbo].[PushPhoneDetail]
GO
/****** Object:  Table [dbo].[ParkingLotsRecord]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsRecord]') AND type in (N'U'))
DROP TABLE [dbo].[ParkingLotsRecord]
GO
/****** Object:  Table [dbo].[ParkingLotsRecoed_HT]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsRecoed_HT]') AND type in (N'U'))
DROP TABLE [dbo].[ParkingLotsRecoed_HT]
GO
/****** Object:  Table [dbo].[ParkingLotsFloor]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsFloor]') AND type in (N'U'))
DROP TABLE [dbo].[ParkingLotsFloor]
GO
/****** Object:  Table [dbo].[ParkingLotsDetail]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsDetail]') AND type in (N'U'))
DROP TABLE [dbo].[ParkingLotsDetail]
GO
/****** Object:  Table [dbo].[ETAs]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ETAs]') AND type in (N'U'))
DROP TABLE [dbo].[ETAs]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
DROP TABLE [dbo].[Cars]
GO
/****** Object:  Table [dbo].[CarPurposeTypes]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CarPurposeTypes]') AND type in (N'U'))
DROP TABLE [dbo].[CarPurposeTypes]
GO
/****** Object:  Table [dbo].[ApplicationUserRole]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationUserRole]
GO
/****** Object:  Table [dbo].[ApplicationUserLogin]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationUserLogin]
GO
/****** Object:  Table [dbo].[ApplicationUserClaim]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUserClaim]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationUserClaim]
GO
/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUser]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationUser]
GO
/****** Object:  Table [dbo].[ApplicationRole]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationRole]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationRole]
GO
/****** Object:  Table [dbo].[AnnouncementDetail]    Script Date: 2016/11/7 上午 12:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AnnouncementDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AnnouncementDetail]
GO
--USE [master]
--GO
--/****** Object:  Database [WbParkSystem]    Script Date: 2016/11/7 上午 12:33:56 ******/
--IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'WbParkSystem')
--DROP DATABASE [WbParkSystem]
--GO
--/****** Object:  Database [WbParkSystem]    Script Date: 2016/11/7 上午 12:33:56 ******/
--IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'WbParkSystem')
--BEGIN
--CREATE DATABASE [WbParkSystem]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'WbParkSystem', FILENAME = N'C:\WbParkDB\WbParkSystem.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10240KB ), 
-- FILEGROUP [SENSOR] 
--( NAME = N'SensorData', FILENAME = N'C:\WbParkDB\SensorData.ndf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
-- LOG ON 
--( NAME = N'WbParkSystem_log', FILENAME = N'C:\WbParkDB\WbParkSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 4194304KB , FILEGROWTH = 5%), 
--( NAME = N'WbParkSystem1_log', FILENAME = N'C:\WbParkDB\WbParkSystem1_log.ldf' , SIZE = 1024KB , MAXSIZE = 4194304KB , FILEGROWTH = 5%), 
--( NAME = N'WbParkSystem2_log', FILENAME = N'C:\WbParkDB\WbParkSystem2_log.ldf' , SIZE = 1024KB , MAXSIZE = 4194304KB , FILEGROWTH = 5%), 
--( NAME = N'WbParkSystem3_log', FILENAME = N'C:\WbParkDB\WbParkSystem3_log.ldf' , SIZE = 1024KB , MAXSIZE = 4194304KB , FILEGROWTH = 5%)
--END

GO
ALTER DATABASE [WbParkSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WbParkSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WbParkSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WbParkSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WbParkSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WbParkSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WbParkSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [WbParkSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WbParkSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WbParkSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WbParkSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WbParkSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WbParkSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WbParkSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WbParkSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WbParkSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WbParkSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WbParkSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WbParkSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WbParkSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WbParkSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WbParkSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WbParkSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WbParkSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WbParkSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [WbParkSystem] SET  MULTI_USER 
GO
ALTER DATABASE [WbParkSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WbParkSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WbParkSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WbParkSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
--USE [WbParkSystem]
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
--GO
USE [WbParkSystem]
GO
/****** Object:  Table [dbo].[AnnouncementDetail]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AnnouncementDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AnnouncementDetail](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Detail] [nvarchar](1000) NOT NULL,
	[ToTop] [bit] NOT NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_AnnouncementDetail] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ApplicationRole]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Void] [bit] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateTime] [smalldatetime] NOT NULL,
	[LastUpdateUserId] [int] NOT NULL,
	[LastUpdateTime] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ApplicationRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[Void] [bit] NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[EMail] [nvarchar](512) NULL,
	[EMailConfirmed] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](10) NULL,
	[PhoneConfirmed] [bit] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateTime] [smalldatetime] NOT NULL,
	[LastUpdateUserId] [int] NOT NULL,
	[LastUpdateTime] [smalldatetime] NOT NULL,
	[LastActivityTime] [smalldatetime] NULL,
	[LastUnlockedTime] [smalldatetime] NULL,
	[LastLoginFailTime] [smalldatetime] NULL,
	[AccessFailedCount] [int] NOT NULL,
	[LockoutEnabled] [bit] NULL,
	[LockoutEndDate] [smalldatetime] NULL,
	[ResetPasswordToken] [nvarchar](512) NULL,
 CONSTRAINT [PK__Applicat__3214EC07DE1F5C2F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ApplicationUserClaim]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUserClaim]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationUserClaim](
	[UserId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](256) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApplicationUserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ApplicationUserLogin]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUserLogin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationUserLogin](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](512) NOT NULL,
	[ProviderKey] [nvarchar](512) NOT NULL,
 CONSTRAINT [PK_ApplicationUserLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ApplicationUserRole]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationUserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Void] [bit] NOT NULL,
 CONSTRAINT [PK_ApplicationUserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CarPurposeTypes]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CarPurposeTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CarPurposeTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Void] [bit] NOT NULL,
 CONSTRAINT [PK_CarPurposeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarNumber] [nvarchar](50) NOT NULL,
	[CarType] [nchar](1) NOT NULL,
	[CarPurposeTypeID] [int] NULL,
	[ETAId] [int] NULL,
	[EmpId] [int] NULL,
	[Void] [bit] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateUTCTime] [smalldatetime] NOT NULL,
	[LastUpdateUserId] [int] NOT NULL,
	[LastUpdateUTCTime] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Void] [bit] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateUTCTime] [smalldatetime] NOT NULL,
	[LastUserId] [int] NOT NULL,
	[LastUpdateUTCTime] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ETAs]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ETAs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ETAs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Void] [bit] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CreateUTCTime] [smalldatetime] NOT NULL,
	[LastUpdateUserId] [int] NOT NULL,
	[LastUpdateUTCTime] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ETAs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ParkingLotsDetail]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ParkingLotsDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Address] [nvarchar](75) NOT NULL,
	[Tel] [nvarchar](15) NOT NULL,
	[Period] [varchar](25) NOT NULL,
	[Charge] [nvarchar](512) NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Void] [bit] NOT NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_ParkingLotsDetail_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ParkingLotsFloor]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsFloor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ParkingLotsFloor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParkingLotsID] [int] NOT NULL,
	[FloorOrder] [smallint] NOT NULL,
	[FloorName] [nvarchar](10) NOT NULL,
	[CarTotalGrid] [int] NOT NULL,
	[CarLastGrid] [int] NOT NULL,
	[MotoTotalGrid] [int] NOT NULL,
	[MotoLastGrid] [int] NOT NULL,
	[Void] [bit] NOT NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_ParkingLotsFloor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ParkingLotsRecoed_HT]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsRecoed_HT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ParkingLotsRecoed_HT](
	[ID] [int] NOT NULL,
	[LogTime] [datetime] NULL,
	[ParkDate] [date] NULL,
	[Count] [smallint] NOT NULL
) ON [SENSOR]
END
GO
/****** Object:  Table [dbo].[ParkingLotsRecord]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParkingLotsRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ParkingLotsRecord](
	[ID] [int] NOT NULL,
	[LogTime] [datetime] NULL,
	[ParkDate] [date] NULL,
	[Count] [smallint] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PushPhoneDetail]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PushPhoneDetail](
	[PhoneTypeID] [tinyint] NOT NULL,
	[CarID] [nvarchar](10) NOT NULL,
	[CarType] [char](1) NOT NULL,
	[DeviceID] [nvarchar](200) NOT NULL,
	[Token] [nvarchar](200) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Void] [bit] NOT NULL,
	[LastUpdate] [datetime] NULL,
	[CarRefId] [int] NULL,
 CONSTRAINT [PK_PushPhoneDetail] PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC,
	[Token] ASC,
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PushPhoneType]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PushPhoneType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PushPhoneType](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[PushPhone] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PushPhoneType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WebLogin]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebLogin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WebLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[PowerTypeID] [tinyint] NOT NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WebLoginPower]    Script Date: 2016/11/7 上午 12:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WebLoginPower]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WebLoginPower](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
	[Void] [bit] NULL
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[AnnouncementDetail] ON 

INSERT [dbo].[AnnouncementDetail] ([No], [StartDate], [EndDate], [Title], [Detail], [ToTop], [LastUpdate]) VALUES (1, CAST(N'2016-11-04' AS Date), CAST(N'2016-11-18' AS Date), N'asdfasdftop', N'&lt;p&gt;
	dfsadfsdfsafs&lt;/p&gt;
', 1, CAST(N'2016-11-04T10:38:25.000' AS DateTime))
INSERT [dbo].[AnnouncementDetail] ([No], [StartDate], [EndDate], [Title], [Detail], [ToTop], [LastUpdate]) VALUES (2, CAST(N'2016-11-04' AS Date), CAST(N'2016-11-18' AS Date), N'asdfasdf', N'&lt;p&gt; dfsadfsdfsafs&lt;/p&gt; ', 0, CAST(N'2016-11-04T09:17:09.000' AS DateTime))
INSERT [dbo].[AnnouncementDetail] ([No], [StartDate], [EndDate], [Title], [Detail], [ToTop], [LastUpdate]) VALUES (3, CAST(N'2016-11-10' AS Date), CAST(N'2016-11-13' AS Date), N'2asd', N'&lt;p&gt; test&lt;/p&gt; ', 1, CAST(N'2016-11-04T10:38:37.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[AnnouncementDetail] OFF
SET IDENTITY_INSERT [dbo].[ApplicationRole] ON 

INSERT [dbo].[ApplicationRole] ([Id], [Name], [Void], [CreateUserId], [CreateTime], [LastUpdateUserId], [LastUpdateTime]) VALUES (1, N'Admins', 0, 3, CAST(N'2016-11-04T18:56:00' AS SmallDateTime), 3, CAST(N'2016-11-04T18:56:00' AS SmallDateTime))
INSERT [dbo].[ApplicationRole] ([Id], [Name], [Void], [CreateUserId], [CreateTime], [LastUpdateUserId], [LastUpdateTime]) VALUES (2, N'Users', 0, 3, CAST(N'2016-11-04T11:20:00' AS SmallDateTime), 3, CAST(N'2016-11-04T11:20:00' AS SmallDateTime))
INSERT [dbo].[ApplicationRole] ([Id], [Name], [Void], [CreateUserId], [CreateTime], [LastUpdateUserId], [LastUpdateTime]) VALUES (3, N'訪客', 0, 3, CAST(N'2016-11-06T00:00:00' AS SmallDateTime), 3, CAST(N'2016-11-06T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[ApplicationRole] OFF
SET IDENTITY_INSERT [dbo].[ApplicationUser] ON 

INSERT [dbo].[ApplicationUser] ([Id], [UserName], [Password], [PasswordHash], [SecurityStamp], [TwoFactorEnabled], [Void], [DisplayName], [Address], [EMail], [EMailConfirmed], [PhoneNumber], [PhoneConfirmed], [CreateUserId], [CreateTime], [LastUpdateUserId], [LastUpdateTime], [LastActivityTime], [LastUnlockedTime], [LastLoginFailTime], [AccessFailedCount], [LockoutEnabled], [LockoutEndDate], [ResetPasswordToken]) VALUES (3, N'root', N'', N'AI9fBRKzhEaRgiBBhyzO1q6SbVKnXNA8WKJ3BO+3Az4EVG4rDMNTFmwf72dN9E8s3w==', N'', 0, 0, N'系統管理員', NULL, NULL, 0, NULL, 0, -1, CAST(N'2016-11-03T10:43:00' AS SmallDateTime), -1, CAST(N'2016-11-03T10:43:00' AS SmallDateTime), CAST(N'2016-11-03T10:43:00' AS SmallDateTime), NULL, NULL, 0, 0, NULL, N'')
SET IDENTITY_INSERT [dbo].[ApplicationUser] OFF
INSERT [dbo].[ApplicationUserRole] ([UserId], [RoleId], [Void]) VALUES (3, 1, 0)
SET IDENTITY_INSERT [dbo].[CarPurposeTypes] ON 

INSERT [dbo].[CarPurposeTypes] ([Id], [Name], [Void]) VALUES (1, N'自用車', 0)
INSERT [dbo].[CarPurposeTypes] ([Id], [Name], [Void]) VALUES (2, N'公務車', 0)
INSERT [dbo].[CarPurposeTypes] ([Id], [Name], [Void]) VALUES (3, N'迎賓車', 0)
SET IDENTITY_INSERT [dbo].[CarPurposeTypes] OFF
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [CarNumber], [CarType], [CarPurposeTypeID], [ETAId], [EmpId], [Void], [CreateUserId], [CreateUTCTime], [LastUpdateUserId], [LastUpdateUTCTime]) VALUES (1, N'asd-123123', N'C', 1, 1, 1, 0, 3, CAST(N'2016-11-04T08:42:00' AS SmallDateTime), 3, CAST(N'2016-11-05T16:55:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Cars] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [Code], [Void], [CreateUserId], [CreateUTCTime], [LastUserId], [LastUpdateUTCTime]) VALUES (1, N'管理員', N'ADMIN001', 0, 3, CAST(N'2016-11-04T08:41:00' AS SmallDateTime), 3, CAST(N'2016-11-04T08:41:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[ETAs] ON 

INSERT [dbo].[ETAs] ([Id], [Code], [Void], [CreateUserId], [CreateUTCTime], [LastUpdateUserId], [LastUpdateUTCTime]) VALUES (1, N'Aas123123123', 0, 3, CAST(N'2016-11-04T08:41:00' AS SmallDateTime), 3, CAST(N'2016-11-04T08:41:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[ETAs] OFF
SET IDENTITY_INSERT [dbo].[ParkingLotsDetail] ON 

INSERT [dbo].[ParkingLotsDetail] ([ID], [Name], [Address], [Tel], [Period], [Charge], [Longitude], [Latitude], [Void], [LastUpdate]) VALUES (1, N'北塔', N'428台中市大雅區科雅一路8號', N'04 2521 3558', N'09:00~21:00', N'<p>  </p> <p> 每次/20元</p> <p> <a href="javascript:alert(''s'');" onclick="javascript:alert(''s'');">d</a></p> <p>  </p>
', 0, 0, 0, CAST(N'2016-11-04T15:16:35.000' AS DateTime))
INSERT [dbo].[ParkingLotsDetail] ([ID], [Name], [Address], [Tel], [Period], [Charge], [Longitude], [Latitude], [Void], [LastUpdate]) VALUES (2, N'南塔', N'428台中市大雅區科雅一路8號 ', N'04-22345123', N'09:00~23:00', N'&lt;p&gt; 30元/次&lt;/p&gt; ', 0, 0, 0, CAST(N'2016-11-06T12:55:17.000' AS DateTime))
INSERT [dbo].[ParkingLotsDetail] ([ID], [Name], [Address], [Tel], [Period], [Charge], [Longitude], [Latitude], [Void], [LastUpdate]) VALUES (3, N'平面', N'428台中市大雅區科雅一路8號 ', N'04-22345123', N'09:00~23:00', N'&lt;p&gt; 20元/次&lt;/p&gt; ', 0, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[ParkingLotsDetail] OFF
SET IDENTITY_INSERT [dbo].[ParkingLotsFloor] ON 

INSERT [dbo].[ParkingLotsFloor] ([ID], [ParkingLotsID], [FloorOrder], [FloorName], [CarTotalGrid], [CarLastGrid], [MotoTotalGrid], [MotoLastGrid], [Void], [LastUpdate]) VALUES (1, 1, 1, N'1樓', 50, 21, 50, 22, 0, CAST(N'2016-11-06T12:42:01.080' AS DateTime))
INSERT [dbo].[ParkingLotsFloor] ([ID], [ParkingLotsID], [FloorOrder], [FloorName], [CarTotalGrid], [CarLastGrid], [MotoTotalGrid], [MotoLastGrid], [Void], [LastUpdate]) VALUES (2, 1, 2, N'2樓', 50, 49, 50, 50, 0, CAST(N'2016-11-06T14:10:43.410' AS DateTime))
INSERT [dbo].[ParkingLotsFloor] ([ID], [ParkingLotsID], [FloorOrder], [FloorName], [CarTotalGrid], [CarLastGrid], [MotoTotalGrid], [MotoLastGrid], [Void], [LastUpdate]) VALUES (3, 3, 0, N'平面', 120, 120, 35, 35, 0, CAST(N'2016-11-06T12:58:56.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ParkingLotsFloor] OFF
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_StartDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] ADD  CONSTRAINT [DF_AnnouncementDetail_StartDate]  DEFAULT (getdate()) FOR [StartDate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_EndDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] ADD  CONSTRAINT [DF_AnnouncementDetail_EndDate]  DEFAULT (getdate()) FOR [EndDate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_Title]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] ADD  CONSTRAINT [DF_AnnouncementDetail_Title]  DEFAULT ('') FOR [Title]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_Detail]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] ADD  CONSTRAINT [DF_AnnouncementDetail_Detail]  DEFAULT ('') FOR [Detail]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_ToTop]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] ADD  CONSTRAINT [DF_AnnouncementDetail_ToTop]  DEFAULT ((0)) FOR [ToTop]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AnnouncementDetail_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AnnouncementDetail] ADD  CONSTRAINT [DF_AnnouncementDetail_LastUpdate]  DEFAULT (getdate()) FOR [LastUpdate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Name__440B1D61]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] ADD  DEFAULT ('Unknow Role') FOR [Name]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Void__44FF419A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] ADD  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__45F365D3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] ADD  DEFAULT ((-1)) FOR [CreateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__46E78A0C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] ADD  DEFAULT (getdate()) FOR [CreateTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__47DBAE45]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] ADD  DEFAULT ((-1)) FOR [LastUpdateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__48CFD27E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationRole] ADD  DEFAULT (getdate()) FOR [LastUpdateTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__UserN__73BA3083]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__UserN__73BA3083]  DEFAULT (N'Anonymous') FOR [UserName]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__TwoFa__74AE54BC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__TwoFa__74AE54BC]  DEFAULT ((0)) FOR [TwoFactorEnabled]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Void__75A278F5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicatio__Void__75A278F5]  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_DisplayName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_DisplayName]  DEFAULT ('未命名') FOR [DisplayName]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_EMail]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_EMail]  DEFAULT ('aaa@aaa.com') FOR [EMail]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_EMailConfirmed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_EMailConfirmed]  DEFAULT ((0)) FOR [EMailConfirmed]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_PhoneNumber]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_PhoneNumber]  DEFAULT ((212345678)) FOR [PhoneNumber]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ApplicationUser_PhoneConfirmed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_PhoneConfirmed]  DEFAULT ((0)) FOR [PhoneConfirmed]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__76969D2E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__Creat__76969D2E]  DEFAULT ((-1)) FOR [CreateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Creat__778AC167]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__Creat__778AC167]  DEFAULT (getdate()) FOR [CreateTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__787EE5A0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__LastU__787EE5A0]  DEFAULT ((-1)) FOR [LastUpdateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__LastU__797309D9]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__LastU__797309D9]  DEFAULT (getdate()) FOR [LastUpdateTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicati__Acces__7A672E12]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF__Applicati__Acces__7A672E12]  DEFAULT ((0)) FOR [AccessFailedCount]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Applicatio__Void__5629CD9C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ApplicationUserRole] ADD  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__CarPurpose__Name__395884C4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CarPurposeTypes] ADD  DEFAULT ('') FOR [Name]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__CarPurpose__Void__3A4CA8FD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CarPurposeTypes] ADD  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__CarNu__160F4887]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ('AAA-1234') FOR [CarNumber]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__CarTy__17036CC0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ('C') FOR [CarType]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cars__CarPurpose__3B40CD36]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [CarPurposeTypeID]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cars__ETAId__3C34F16F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [ETAId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cars__EmpId__3D2915A8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [EmpId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx___Void__1AD3FDA4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__Creat__1BC821DD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((-1)) FOR [CreateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__Creat__1CBC4616]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ('1900/1/1') FOR [CreateUTCTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__LastU__1DB06A4F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ((-1)) FOR [LastUpdateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__LastU__1EA48E88]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cars] ADD  DEFAULT ('1900/1/1') FOR [LastUpdateUTCTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Name__5DCAEF64]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (N'NoName') FOR [Name]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Code__5EBF139D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT (N'123') FOR [Code]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Void__5FB337D6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Create__60A75C0F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((-1)) FOR [CreateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__Create__619B8048]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('1900/1/1') FOR [CreateUTCTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__LastUs__628FA481]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((-1)) FOR [LastUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Employee__LastUp__6383C8BA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('1900/1/1') FOR [LastUpdateUTCTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__Code__6477ECF3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] ADD  DEFAULT ('M123456789') FOR [Code]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__Void__656C112C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] ADD  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__CreateUser__66603565]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] ADD  DEFAULT ((-1)) FOR [CreateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__CreateUTCT__6754599E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] ADD  DEFAULT ('1900/1/1') FOR [CreateUTCTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__LastUpdate__68487DD7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] ADD  DEFAULT ((-1)) FOR [LastUpdateUserId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ETAs__LastUpdate__693CA210]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ETAs] ADD  DEFAULT ('1900/1/1') FOR [LastUpdateUTCTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_Name]  DEFAULT ('') FOR [Name]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Address]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_Address]  DEFAULT ('') FOR [Address]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Tel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_Tel]  DEFAULT ('') FOR [Tel]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Period]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_Period]  DEFAULT ('') FOR [Period]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Charge]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_Charge]  DEFAULT ('') FOR [Charge]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_longitude]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_Table_1_longitude]  DEFAULT ((0.0)) FOR [Longitude]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_latitude]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_Table_1_latitude]  DEFAULT ((0.0)) FOR [Latitude]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_Void]  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsDetail_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsDetail] ADD  CONSTRAINT [DF_ParkingLotsDetail_LastUpdate]  DEFAULT (getdate()) FOR [LastUpdate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_FloorOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_FloorOrder]  DEFAULT ((0)) FOR [FloorOrder]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_FloorName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_FloorName]  DEFAULT ('') FOR [FloorName]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_CarTotalGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_CarTotalGrid]  DEFAULT ((0)) FOR [CarTotalGrid]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_CarLastGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_CarLastGrid]  DEFAULT ((0)) FOR [CarLastGrid]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_MotoTotalGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_MotoTotalGrid]  DEFAULT ((0)) FOR [MotoTotalGrid]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_MotoLastGrid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_MotoLastGrid]  DEFAULT ((0)) FOR [MotoLastGrid]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_Void]  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsFloor_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsFloor] ADD  CONSTRAINT [DF_ParkingLotsFloor_LastUpdate]  DEFAULT (getdate()) FOR [LastUpdate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecoed_HT_LogTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecoed_HT] ADD  CONSTRAINT [DF_ParkingLotsRecoed_HT_LogTime]  DEFAULT (getdate()) FOR [LogTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecoed_HT_ParkDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecoed_HT] ADD  CONSTRAINT [DF_ParkingLotsRecoed_HT_ParkDate]  DEFAULT (getdate()) FOR [ParkDate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecoed_HT_Count]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecoed_HT] ADD  CONSTRAINT [DF_ParkingLotsRecoed_HT_Count]  DEFAULT ((0)) FOR [Count]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecord_LogTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecord] ADD  CONSTRAINT [DF_ParkingLotsRecord_LogTime]  DEFAULT (getdate()) FOR [LogTime]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecord_ParkDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecord] ADD  CONSTRAINT [DF_ParkingLotsRecord_ParkDate]  DEFAULT (getdate()) FOR [ParkDate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ParkingLotsRecord_Count]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ParkingLotsRecord] ADD  CONSTRAINT [DF_ParkingLotsRecord_Count]  DEFAULT ((0)) FOR [Count]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Table_1_PhoneType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  CONSTRAINT [DF_Table_1_PhoneType]  DEFAULT ('') FOR [PhoneTypeID]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__PushPhone__CarID__4A8310C6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  DEFAULT (N'') FOR [CarID]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__tmp_ms_xx__CarTy__43D61337]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  DEFAULT (N'') FOR [CarType]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_DeviceID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  CONSTRAINT [DF_PushPhoneDetail_DeviceID]  DEFAULT ('') FOR [DeviceID]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_PhoneNumber]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  CONSTRAINT [DF_PushPhoneDetail_PhoneNumber]  DEFAULT ('') FOR [PhoneNumber]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  CONSTRAINT [DF_PushPhoneDetail_Void]  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneDetail_LastUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneDetail] ADD  CONSTRAINT [DF_PushPhoneDetail_LastUpdate]  DEFAULT (getdate()) FOR [LastUpdate]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_PushPhoneType_PushPhoto]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PushPhoneType] ADD  CONSTRAINT [DF_PushPhoneType_PushPhoto]  DEFAULT ('') FOR [PushPhone]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_Account]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] ADD  CONSTRAINT [DF_WebLogin_Account]  DEFAULT ('') FOR [Account]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_Password]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] ADD  CONSTRAINT [DF_WebLogin_Password]  DEFAULT ('') FOR [Password]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_PowerTypeID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] ADD  CONSTRAINT [DF_WebLogin_PowerTypeID]  DEFAULT ((1)) FOR [PowerTypeID]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLogin_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLogin] ADD  CONSTRAINT [DF_WebLogin_Name]  DEFAULT ('') FOR [Name]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLoginPower_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLoginPower] ADD  CONSTRAINT [DF_WebLoginPower_Name]  DEFAULT ('') FOR [Name]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_WebLoginPower_Void]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WebLoginPower] ADD  CONSTRAINT [DF_WebLoginPower_Void]  DEFAULT ((0)) FOR [Void]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserClaim_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserClaim]'))
ALTER TABLE [dbo].[ApplicationUserClaim]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserClaim_ToApplicationUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserClaim_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserClaim]'))
ALTER TABLE [dbo].[ApplicationUserClaim] CHECK CONSTRAINT [FK_ApplicationUserClaim_ToApplicationUser]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserLogin_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserLogin]'))
ALTER TABLE [dbo].[ApplicationUserLogin]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserLogin_ToApplicationUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserLogin_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserLogin]'))
ALTER TABLE [dbo].[ApplicationUserLogin] CHECK CONSTRAINT [FK_ApplicationUserLogin_ToApplicationUser]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserRole_ToApplicationRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]'))
ALTER TABLE [dbo].[ApplicationUserRole]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserRole_ToApplicationRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[ApplicationRole] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserRole_ToApplicationRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]'))
ALTER TABLE [dbo].[ApplicationUserRole] CHECK CONSTRAINT [FK_ApplicationUserRole_ToApplicationRole]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserRole_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]'))
ALTER TABLE [dbo].[ApplicationUserRole]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserRole_ToApplicationUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationUserRole_ToApplicationUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationUserRole]'))
ALTER TABLE [dbo].[ApplicationUserRole] CHECK CONSTRAINT [FK_ApplicationUserRole_ToApplicationUser]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_CarPurposeTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars]  WITH NOCHECK ADD  CONSTRAINT [FK_Cars_CarPurposeTypes] FOREIGN KEY([CarPurposeTypeID])
REFERENCES [dbo].[CarPurposeTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_CarPurposeTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarPurposeTypes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_ToEmployee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_ToEmployee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_ToEmployee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_ToEmployee]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_ToETAs]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_ToETAs] FOREIGN KEY([ETAId])
REFERENCES [dbo].[ETAs] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cars_ToETAs]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cars]'))
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_ToETAs]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ParkingLotsFloor_ParkingLotsDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[ParkingLotsFloor]'))
ALTER TABLE [dbo].[ParkingLotsFloor]  WITH CHECK ADD  CONSTRAINT [FK_ParkingLotsFloor_ParkingLotsDetail] FOREIGN KEY([ParkingLotsID])
REFERENCES [dbo].[ParkingLotsDetail] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ParkingLotsFloor_ParkingLotsDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[ParkingLotsFloor]'))
ALTER TABLE [dbo].[ParkingLotsFloor] CHECK CONSTRAINT [FK_ParkingLotsFloor_ParkingLotsDetail]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PushPhoneDetail_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]'))
ALTER TABLE [dbo].[PushPhoneDetail]  WITH CHECK ADD  CONSTRAINT [FK_PushPhoneDetail_Cars] FOREIGN KEY([CarRefId])
REFERENCES [dbo].[Cars] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PushPhoneDetail_Cars]') AND parent_object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]'))
ALTER TABLE [dbo].[PushPhoneDetail] CHECK CONSTRAINT [FK_PushPhoneDetail_Cars]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PushPhoneDetail_PushPhoneType]') AND parent_object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]'))
ALTER TABLE [dbo].[PushPhoneDetail]  WITH CHECK ADD  CONSTRAINT [FK_PushPhoneDetail_PushPhoneType] FOREIGN KEY([PhoneTypeID])
REFERENCES [dbo].[PushPhoneType] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PushPhoneDetail_PushPhoneType]') AND parent_object_id = OBJECT_ID(N'[dbo].[PushPhoneDetail]'))
ALTER TABLE [dbo].[PushPhoneDetail] CHECK CONSTRAINT [FK_PushPhoneDetail_PushPhoneType]
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'No'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統內碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'No'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'StartDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'開始顯示公告日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'EndDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'結束顯示公告日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'Title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'訊息標題' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'Title'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'Detail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'訊息明細' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'Detail'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'ToTop'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否置頂' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'ToTop'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail', @level2type=N'COLUMN',@level2name=N'LastUpdate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'AnnouncementDetail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告資訊' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AnnouncementDetail'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'Name'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'Name'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'CreateUserId'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立角色的使用者識別碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'CreateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'LastUpdateUserId'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最後一次更新的使用者識別碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'LastUpdateUserId'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ApplicationRole', N'COLUMN',N'LastUpdateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最後更新時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ApplicationRole', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場系統代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Name'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Name'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Address'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Address'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Tel'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電話' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Tel'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Period'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可停時間(例如00:00~24:00)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Period'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Charge'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'費用說明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Charge'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Longitude'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'經度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Longitude'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Latitude'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'緯度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Latitude'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'Void'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否作廢' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'Void'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail', @level2type=N'COLUMN',@level2name=N'LastUpdate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsDetail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場資訊' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsDetail'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'ParkingLotsID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場系統代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'ParkingLotsID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'FloorOrder'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'樓層順序(由低1到高99)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'FloorOrder'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'FloorName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'樓層名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'FloorName'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'CarTotalGrid'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汽車總車格數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'CarTotalGrid'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'CarLastGrid'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汽車剩餘車格數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'CarLastGrid'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'MotoTotalGrid'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'機車總車格數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'MotoTotalGrid'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'MotoLastGrid'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'機車剩餘車格數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'MotoLastGrid'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'Void'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否作廢' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'Void'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor', @level2type=N'COLUMN',@level2name=N'LastUpdate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsFloor', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場各樓層資訊' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsFloor'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場系統代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'LogTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資訊紀錄時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'LogTime'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'ParkDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'ParkDate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', N'COLUMN',N'Count'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'計數(進場-1 出場+1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT', @level2type=N'COLUMN',@level2name=N'Count'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecoed_HT', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場進出紀錄_歷史' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecoed_HT'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場系統代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'LogTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資訊紀錄時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'LogTime'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'ParkDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'ParkDate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', N'COLUMN',N'Count'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'計數(進場-1 出場+1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord', @level2type=N'COLUMN',@level2name=N'Count'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'ParkingLotsRecord', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'停車場進出紀錄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParkingLotsRecord'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'PhoneTypeID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推播手機類型代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'PhoneTypeID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'DeviceID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'設備ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'DeviceID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'Token'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'動態簡訊密碼器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'Token'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'PhoneNumber'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手機門號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'PhoneNumber'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'Void'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否停用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'Void'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', N'COLUMN',N'LastUpdate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail', @level2type=N'COLUMN',@level2name=N'LastUpdate'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneDetail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推播手機明細' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneDetail'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneType', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推播手機類型代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneType', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneType', N'COLUMN',N'PushPhone'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推撥手機類型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneType', @level2type=N'COLUMN',@level2name=N'PushPhone'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PushPhoneType', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推播手機類型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PushPhoneType'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系統內碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'Account'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Web登入帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'Account'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'Password'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Web登入密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'Password'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'PowerTypeID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'權限類型代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'PowerTypeID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', N'COLUMN',N'Name'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登入名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin', @level2type=N'COLUMN',@level2name=N'Name'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLogin', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Web登入權限帳密' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLogin'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'權限代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', N'COLUMN',N'Name'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'權限名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower', @level2type=N'COLUMN',@level2name=N'Name'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', N'COLUMN',N'Void'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否停用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower', @level2type=N'COLUMN',@level2name=N'Void'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'WebLoginPower', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Web權限類型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WebLoginPower'
GO
USE [master]
GO
ALTER DATABASE [WbParkSystem] SET  READ_WRITE 
GO
