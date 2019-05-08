USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[ConFac_TRI]    Script Date: 26/04/2019 15:36:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConFac_TRI]

@docEntry int
AS
BEGIN
	SELECT '1000','IGV','VAT',CONVERT(NUMERIC(12,2),ROUND(t0.SubTot,2)),CONVERT(NUMERIC(12,2),ROUND(t0.Impues,2))
	 FROM FACCLI T0 WHERE DocEntry = @DocEntry
END
GO


