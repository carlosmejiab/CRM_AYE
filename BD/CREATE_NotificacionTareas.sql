USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[NotificacionTareas]    Script Date: 25/11/2021 00:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE NotificacionTareas

CREATE PROCEDURE [dbo].[NotificacionTareas]
AS
SET FMTONLY OFF
DECLARE @CANTIDAD INT
DECLARE @J INT
DECLARE @IdTask INT
DECLARE @IdNotificationsTasks INT
DECLARE @UserSend INT
SET @CANTIDAD = 0
SET @J = 1

--SELECT * from NotificationsTasks where StatusSendMail = 1


SELECT @CANTIDAD = COUNT(*) from NotificationsTasks where StatusSendMail IN (1,3)

SELECT * 
INTO #NotificationsTasks
FROM NotificationsTasks where StatusSendMail IN (1,3)

WHILE @J<=@CANTIDAD
BEGIN
	SELECT @IdTask = IdTask FROM #NotificationsTasks
	SELECT @IdNotificationsTasks = IdNotificationsTasks FROM #NotificationsTasks
	SELECT @UserSend = UserSend FROM #NotificationsTasks
	SET @J = @J +1
	DELETE #NotificationsTasks WHERE IdNotificationsTasks = @IdNotificationsTasks

	EXECUTE EnviarCorrreoNotificacionTareas @IdTask, @UserSend
END


--PRINT @CANTIDAD


