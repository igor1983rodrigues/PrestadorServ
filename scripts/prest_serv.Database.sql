USE [master]
GO
/****** Object:  Database [prest_serv]    Script Date: 26/03/2019 16:22:14 ******/
CREATE DATABASE [prest_serv]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prest_serv', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\prest_serv.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'prest_serv_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\prest_serv_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [prest_serv] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prest_serv].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prest_serv] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prest_serv] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prest_serv] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prest_serv] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prest_serv] SET ARITHABORT OFF 
GO
ALTER DATABASE [prest_serv] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prest_serv] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prest_serv] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prest_serv] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prest_serv] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prest_serv] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prest_serv] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prest_serv] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prest_serv] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prest_serv] SET  DISABLE_BROKER 
GO
ALTER DATABASE [prest_serv] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prest_serv] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prest_serv] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prest_serv] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prest_serv] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prest_serv] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prest_serv] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prest_serv] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [prest_serv] SET  MULTI_USER 
GO
ALTER DATABASE [prest_serv] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prest_serv] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prest_serv] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prest_serv] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [prest_serv] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'prest_serv', N'ON'
GO
ALTER DATABASE [prest_serv] SET QUERY_STORE = OFF
GO
ALTER DATABASE [prest_serv] SET  READ_WRITE 
GO
