USE [FACTURADOR01]
GO

/****** Object:  StoredProcedure [dbo].[NueRegEntMer]    Script Date: 26/04/2019 15:38:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NueRegEntMer]
	
			@NumDoc int,
			@SerDoc varchar(10),
			@Estado char(1),
			@FecReg date,
			@FecVen date,
			@FecDoc date,
			@CodSoc varchar(20),
			@NomSoc varchar(100),
			@RucSoc numeric(12,0),
			@RefDoc varchar(50),
			@ConPag int,
			@SubTot money,
			@Impues money,
			@TotDoc money,
			@Coment varchar(200),
			@SerCor nchar(4),
			@NumCor int,
			@EstSun char(1),
			@CodHas varchar(50),
			@CadQr varchar(50)
			

AS
BEGIN
	
	INSERT INTO ENTMER
         
     VALUES (
			@NumDoc,
			@SerDoc, 
			@Estado, 
			@FecReg, 
			@FecVen,
			@FecDoc, 
			@CodSoc, 
			@NomSoc, 
			@RucSoc ,
			@RefDoc ,
			@ConPag ,
			@SubTot ,
			@Impues ,
			@TotDoc ,
			@Coment ,
			@SerCor ,
			@NumCor ,
			@EstSun ,
			@CodHas ,
			@CadQr 
			)
END
GO


