USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[Inc_DatObj]    Script Date: 26/04/2019 15:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Inc_DatObj]
	@TipObj int
AS
BEGIN
	UPDATE DATOBJ  SET NextDocNum = (select NextDocNum+1 from DATOBJ where TipObj = @TipObj), NexNumCor = (select NexNumCor+1 from DATOBJ where TipObj = @TipObj) WHERE TipObj = @TipObj

END
GO


