USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[NueRegArt]    Script Date: 26/04/2019 15:38:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NueRegArt]
		@CodArt nchar(10),
        @Descri varchar(100),
        @CodSun varchar(8),
        @GruArt int,
        @PreUni money,
       -- @LisPre int,
        @CodUni varchar(3),
        @ArtInv bit,
        @ArtCom bit,
        @ArtVen bit,
        @ArtAct bit,
        @ArtIna bit
AS
BEGIN
	INSERT INTO [dbo].[ARTICU]
           ([CodArt]
           ,[Descri]
           ,[CodSun]
           ,[GruArt]
           ,[PreUni]
           --,[LisPre]
           ,[CodUni]
           ,[ArtInv]
           ,[ArtCom]
           ,[ArtVen]
           ,[ArtAct]
           ,[ArtIna])
     VALUES
			   (@CodArt,
				@Descri ,
				@CodSun ,
				@GruArt ,
				@PreUni ,
				--@LisPre ,
				@CodUni ,
				@ArtInv ,
				@ArtCom ,
				@ArtVen ,
				@ArtAct ,
				@ArtIna )
END
GO


