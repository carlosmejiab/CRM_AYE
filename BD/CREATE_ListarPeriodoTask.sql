USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[ListarPeriodoTask]    Script Date: 25/11/2021 00:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarPeriodoTask]
as

SELECT Description, IdTabla FROM TablaMaestra where Groups = 'PeriodTask'


