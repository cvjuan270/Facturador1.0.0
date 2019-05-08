USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[ConFac_LEY]    Script Date: 26/04/2019 15:36:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConFac_LEY]
	@DocEntry int
AS
BEGIN
	select 1000,TotDoc from FACCLI where DocEntry = @DocEntry
END
GO


