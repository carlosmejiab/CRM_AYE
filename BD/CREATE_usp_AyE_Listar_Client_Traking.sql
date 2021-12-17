USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Client_Traking]    Script Date: 25/11/2021 01:05:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AyE_Listar_Client_Traking]
@IdClient INT
AS

SELECT T0.IdTracking,TrackingName = T0.Name, T0.StartDateTime, T0.DueDateTime, 
T0.DurationTime, T0.TimeWork,StatusTracking = T2.Description, Task = T1.Name,
NameClient = T3.Name, FiscalYear = T4.Description 
FROM Tracking T0  
INNER JOIN Task T1 ON T0.IdTask = T1.IdTask  
INNER JOIN TablaMaestra T2 ON T0.IdStatusTracking = T2.IdTabla  
INNER JOIN Client T3 ON T3.IdClient = T1.IdClient
INNER JOIN TablaMaestra T4 ON T4.Groups = 'FiscalYear' and T4.IdTabla = T1.FiscalYear
WHERE T1.IdClient = @IdClient --T2.Groups = 'StatusTracking' AND  --AND T2.Description <> 'Completed'
ORDER BY T0.Name ASC