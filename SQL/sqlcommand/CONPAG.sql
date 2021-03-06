USE [FACTURADOR01]
GO

/****** Object:  Table [dbo].[CONPAG]    Script Date: 26/04/2019 15:29:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CONPAG](
	[CodCon] [int] IDENTITY(1,1) NOT NULL,
	[Descri] [varchar](50) NULL,
	[Meses] [int] NULL,
	[Dias] [int] NULL,
	[Cuotas] [int] NULL,
 CONSTRAINT [PK_CONPAG] PRIMARY KEY CLUSTERED 
(
	[CodCon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


