USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[UltiPrecClie]    Script Date: 26/04/2019 15:39:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UltiPrecClie]
	@CodArt varchar(10), 
	@CodSoc varchar(20)
	
AS
BEGIN
DECLARE @Tabla1 table(PreBru money,FecDoc DATETIME)
	insert into @Tabla1
SELECT ROUND(T0.PreBru,2),T1.FecDoc FROM NTMER1 T0 INNER JOIN ENTMER T1 ON T0.DocEntry = T1.DocEntry WHERE  T0.CodArt = @CodArt AND T1.CodSoc =@CodSoc  --ORDER BY t0.DocEntry DESC
UNION
SELECT ROUND(T0.PreBru,2),T1.FecDoc FROM ACCLI1 T0 INNER JOIN FACCLI T1 ON T0.DocEntry = T1.DocEntry WHERE  T0.CodArt = @CodArt AND T1.CodSoc =@CodSoc  --ORDER BY t0.DocEntry DESC
 SELECT top (1) PreBru FROM @Tabla1 ORDER BY FecDoc desc
END
GO


