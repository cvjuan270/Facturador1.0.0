USE [master]
GO

/****** Object:  Database [FACTURADOR01]    Script Date: 26/04/2019 15:23:02 ******/
CREATE DATABASE [FACTURADOR01] ON  PRIMARY 
( NAME = N'FACTURADOR01', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FACTURADOR01.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FACTURADOR01_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FACTURADOR01_log.ldf' , SIZE = 15040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [FACTURADOR01] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FACTURADOR01].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [FACTURADOR01] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [FACTURADOR01] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [FACTURADOR01] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [FACTURADOR01] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [FACTURADOR01] SET ARITHABORT OFF 
GO

ALTER DATABASE [FACTURADOR01] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [FACTURADOR01] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [FACTURADOR01] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [FACTURADOR01] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [FACTURADOR01] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [FACTURADOR01] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [FACTURADOR01] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [FACTURADOR01] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [FACTURADOR01] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [FACTURADOR01] SET  DISABLE_BROKER 
GO

ALTER DATABASE [FACTURADOR01] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [FACTURADOR01] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [FACTURADOR01] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [FACTURADOR01] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [FACTURADOR01] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [FACTURADOR01] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [FACTURADOR01] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [FACTURADOR01] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [FACTURADOR01] SET  MULTI_USER 
GO

ALTER DATABASE [FACTURADOR01] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [FACTURADOR01] SET DB_CHAINING OFF 
GO

ALTER DATABASE [FACTURADOR01] SET  READ_WRITE 
GO


