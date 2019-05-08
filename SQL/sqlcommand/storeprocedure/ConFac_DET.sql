USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[ConFac_DET]    Script Date: 26/04/2019 15:35:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConFac_DET]
@DocEntry int
AS
BEGIN
	SELECT t0.CodUni,t0.Cantid,RTRIM(t0.CodArt),t0.CodSun,t0.Descri,
		CONVERT(NUMERIC(12,2),ROUND(t0.Precio,2)),CONVERT(NUMERIC(12,2),ROUND(t0.Impues,2)),1000,CONVERT(NUMERIC(12,2),ROUND(t0.Impues,2)),CONVERT(NUMERIC(12,2),ROUND(t0.TotLine,2)),
		'IGV','VAT',10,18.00,'-',
		0.00,0.00,'','','',
		15.00,'-',0.00,0.00,'',
		'',15.00,CONVERT(NUMERIC(12,2),ROUND(t0.TotBru,2)),CONVERT(NUMERIC(12,2),ROUND(t0.TotLine,2)),0.00
	 FROM ACCLI1 t0 WHERE t0.DocEntry = @DocEntry 
END
GO


