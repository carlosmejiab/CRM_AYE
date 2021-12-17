USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerListaTareasEnviarCorreo]    Script Date: 25/11/2021 00:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ObtenerListaTareasEnviarCorreo]

AS
SET FMTONLY OFF

DECLARE @FechaActual DATETIME

SET @FechaActual = GETDATE()

select DISTINCT T0.IdTask,T0.IdEmployee, StatusSendMail = 1
INTO #TemporalTask
from TaskPacticipants T0
INNER JOIN Task T1 ON T0.IdTask = T1.IdTask
WHERE DATEDIFF (HOUR ,@FechaActual,DueDateTime) >= -48 and DATEDIFF (HOUR ,@FechaActual,DueDateTime) <= 0 


SELECT T0.IdTask,T0.StatusSendMail,SendDate = @FechaActual,T0.IdEmployee   FROM #TemporalTask T0
LEFT JOIN NotificationsTasks T1 ON T0.IdTask = T1.IdTask AND T0.IdEmployee = T1.UserSend
WHERE T1.IdTask IS NULL 

drop table #TemporalTask



