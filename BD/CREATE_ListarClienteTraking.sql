USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[ListarClienteTraking]    Script Date: 25/11/2021 00:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarClienteTraking]
AS
SELECT DISTINCT T2.Name, T1.IdClient, T1.State, T1.IdTask FROM Tracking T0
INNER JOIN Task T1 ON T0.IdTask = T1.IdTask
INNER JOIN Client T2 ON T1.IdClient = T2.IdClient
--WHERE T0.State = '1'
ORDER BY T2.Name ASC 


