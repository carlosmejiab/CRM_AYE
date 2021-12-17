USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Task_Participantes]    Script Date: 25/11/2021 01:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AyE_Listar_Task_Participantes]
@idTask Int
AS

--Listar los participantes por Tarea
select IdEmployee
into #Temp
from TaskPacticipants where IdTask = @idTask AND State = '1'


select T0.IdEmployee, Employees = T0.LastName +' '+ T0.FirstName,State = 0 
into #temp2
from Employees T0
left join #Temp T1 ON T0.IdEmployee = T1.IdEmployee
WHERE T1.IdEmployee is null


select T0.IdEmployee,Employees = T0.LastName +' '+ T0.FirstName, State = 1  from Employees T0
INNER JOIN #Temp T1 ON T0.IdEmployee = T1.IdEmployee
union
select IdEmployee,Employees,State from #temp2

DROP TABLE #Temp
DROP TABLE #temp2

 


