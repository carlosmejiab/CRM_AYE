USE [AyE_Services]
GO

CREATE PROCEDURE ListarPeriodoTask
as

SELECT Description, IdTabla FROM TablaMaestra where Groups = 'PeriodTask'


