USE [prest_serv]
GO
/****** Object:  User [prest_serv]    Script Date: 28/03/2019 16:55:49 ******/
CREATE USER [prest_serv] FOR LOGIN [prest_serv] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_datareader] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [prest_serv]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [prest_serv]
GO
