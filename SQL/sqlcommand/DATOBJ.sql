USE [FACTURADOR01]
GO

/****** Object:  Table [dbo].[DATOBJ]    Script Date: 26/04/2019 15:30:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DATOBJ](
	[TipObj] [int] NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[NextDocNum] [int] NOT NULL,
	[SerCor] [varchar](4) NOT NULL,
	[NexNumCor] [int] NOT NULL,
	[Detalles] [varchar](50) NOT NULL
) ON [PRIMARY]
GO


