USE [AyE_Services]
GO

CREATE PROCEDURE ListarClienteTask
as

select DISTINCT T1.Name, T1.IdClient from Task  T0
inner join Client T1 ON T0.IdClient = T1.IdClient
WHERE T0.State = '1' 
ORDER BY T1.Name ASC

