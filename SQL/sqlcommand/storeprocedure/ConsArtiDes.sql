USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[ConsArtiDes]    Script Date: 26/04/2019 15:37:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsArtiDes]
@Descri varchar(50)
AS
BEGIN
	SELECT t0.CodArt, t0.Descri,t0.PreUni,null,T1.Descri FROM ARTICU T0 INNER JOIN UNIMED T1 ON T1.CodUni =T0.CodUni WHERE T0.Descri like  @Descri+'%'
END

GO


