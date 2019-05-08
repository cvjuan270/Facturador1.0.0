USE [FACTURADOR01]
GO

/****** Object:  Table [dbo].[NTMER1]    Script Date: 26/04/2019 15:32:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NTMER1](
	[DocEntry] [int] NOT NULL,
	[NumLin] [int] NOT NULL,
	[RefBas] [int] NULL,
	[tipBas] [int] NULL,
	[LinBas] [int] NULL,
	[RefObj] [int] NULL,
	[TipObj] [int] NULL,
	[LinObje] [int] NULL,
	[EstLin] [char](1) NOT NULL,
	[CodArt] [nchar](10) NOT NULL,
	[Descri] [varchar](100) NOT NULL,
	[Cantid] [numeric](18, 2) NOT NULL,
	[Precio] [money] NOT NULL,
	[PreBru] [money] NOT NULL,
	[RatImp] [numeric](2, 2) NULL,
	[Impues] [money] NULL,
	[CodUni] [varchar](3) NULL,
	[TotLine] [money] NULL,
	[TotBru] [money] NULL,
	[CodSun] [varchar](8) NULL,
 CONSTRAINT [NTRMER1_PRIMARY] PRIMARY KEY CLUSTERED 
(
	[DocEntry] ASC,
	[NumLin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


