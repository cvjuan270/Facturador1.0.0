USE [FACTURADOR01]
GO

/****** Object:  Table [dbo].[ENTMER]    Script Date: 26/04/2019 15:30:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ENTMER](
	[DocEntry] [int] IDENTITY(1,1) NOT NULL,
	[NumDoc] [int] NULL,
	[SerDoc] [varchar](10) NULL,
	[Estado] [char](1) NOT NULL,
	[FecReg] [date] NOT NULL,
	[FecVen] [date] NULL,
	[FecDoc] [date] NOT NULL,
	[CodSoc] [varchar](20) NOT NULL,
	[NomSoc] [varchar](100) NOT NULL,
	[RucSoc] [numeric](12, 0) NOT NULL,
	[RefDoc] [varchar](50) NULL,
	[ConPag] [int] NULL,
	[SubTot] [money] NOT NULL,
	[Impues] [money] NOT NULL,
	[TotDoc] [money] NOT NULL,
	[Coment] [varchar](200) NULL,
	[SerCor] [nchar](4) NOT NULL,
	[NumCor] [int] NOT NULL,
	[EstSun] [char](1) NOT NULL,
	[CodHas] [varchar](50) NULL,
	[CadQr] [varchar](50) NULL,
	[DirEnt] [varchar](200) NULL,
 CONSTRAINT [PK_ENTMER] PRIMARY KEY CLUSTERED 
(
	[NumCor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


