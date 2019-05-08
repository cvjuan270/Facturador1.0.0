USE [FACTURADOR01]
GO

/****** Object:  Table [dbo].[SOCNEG]    Script Date: 26/04/2019 15:32:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SOCNEG](
	[CodSoc] [varchar](20) NOT NULL,
	[TipSoc] [int] NOT NULL,
	[NomSoc] [varchar](100) NULL,
	[RucSoc] [numeric](12, 0) NOT NULL,
	[Telefo1] [varchar](12) NULL,
	[TelMov] [varchar](12) NULL,
	[CorEle] [varchar](50) NULL,
	[DirFac] [varchar](200) NOT NULL,
	[DirGui] [varchar](200) NULL,
	[ConPag] [int] NULL,
	[LisPre] [int] NULL,
	[LimCre] [money] NULL,
 CONSTRAINT [PK_SOCNEG] PRIMARY KEY CLUSTERED 
(
	[CodSoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


