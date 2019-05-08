USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[ConFac_CAB]    Script Date: 26/04/2019 15:34:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConFac_CAB]
@DocEntry int

AS
BEGIN
SELECT '0101',convert(varchar(10),T0.FecDoc,120),CONVERT(varchar,GETDATE(),108),'-','000',
		'6',T0.RucSoc,T0.NomSoc,'PEN',CONVERT(NUMERIC(18,2),ROUND(T0.Impues,2)),
		CONVERT(NUMERIC(18,2),ROUND(T0.SubTot,2)),CONVERT(NUMERIC(18,2),ROUND(T0.TotDoc,2)),0.00,0.00,0.00,
		CONVERT(NUMERIC(18,2),ROUND(T0.TotDoc,2)),2.1,2.0
	 FROM FACCLI T0 WHERE DocEntry = @DocEntry
END
GO


