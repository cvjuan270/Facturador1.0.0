USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[NueRegLinEntMer]    Script Date: 26/04/2019 15:39:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NueRegLinEntMer] 
	-- Add the parameters for the stored procedure here
		@DocEntry int,
		@NumLin int,
		@RefBas int,
		@tipBas int,
		@LinBas int,
		@RefObj int,
		@TipObj int,
		@LinObje int,
		@EstLin char(1),
		@CodArt nchar(10),
		@Descri varchar(100),
		@Cantid numeric(18,2),
		@Precio money,
		@PreBru money,
		@RatImp numeric(2,2),
		@Impues money,
		@CodUni varchar(3),
		@TotLine money,
		@TotBru money

AS
BEGIN
	INSERT INTO NTMER1 VALUES--(1,1,Null,Null,Null,Null,Null,Null,'O','20101','GUANTES DE SOLDADOR',10,1.00,1.18,NULL,1.80,'NIU',10.00,1.8 )
	(
		@DocEntry ,
		@NumLin,
		@RefBas ,
		@tipBas ,
		@LinBas,
		@RefObj ,
		@TipObj ,
		@LinObje ,
		@EstLin ,
		@CodArt,
		@Descri ,
		@Cantid ,
		@Precio ,
		@PreBru ,
		@RatImp ,
		@Impues,
		@CodUni,
		@TotLine,
		@TotBru

)
END
GO


