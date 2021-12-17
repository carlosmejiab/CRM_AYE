USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[ListarClienteTask]    Script Date: 25/11/2021 00:50:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarClienteTask]
as

select DISTINCT T1.Name, T1.IdClient from Task  T0
inner join Client T1 ON T0.IdClient = T1.IdClient
WHERE T0.State = '1' 
ORDER BY T1.Name ASC

