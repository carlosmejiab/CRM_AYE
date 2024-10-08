USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[UpdateSendMailTask]    Script Date: 25/11/2021 01:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Objetivo se envia un correo cuando el usuario actualiza la tarea
--EXECUTE  UpdateSendMailTask 1,5112,4
CREATE PROCEDURE [dbo].[UpdateSendMailTask]
@State char(1),
@IdTask int, 
@IdEmployee int
as

DECLARE @EmailAsigando varchar(120)

DECLARE @FROM varchar(max)
DECLARE @BC varchar(max)
DECLARE @CC varchar(max)
DECLARE @BODY  NVARCHAR(MAX)
DECLARE @Email varchar(120)
DECLARE @sub NVARCHAR(MAX)
DECLARE @EmployeeCreate NVARCHAR(150)
DECLARE @NameClient NVARCHAR(200)
DECLARE @EmailCreation varchar(120)
DECLARE @IdEmployeeCreate INT
DECLARE @IdClient INT
DECLARE @NameTask varchar(150)
DECLARE @StartDateTime datetime 
DECLARE @NameStatusTask  varchar(150)
DECLARE @CANTIDAD INT
DECLARE @J INT
--DECLARE @CadenaEmail varchar(250)
 
--SET @CadenaEmail = ''
SELECT @IdEmployeeCreate = IdEmployeeCreate from Task where IdTask = @IdTask
SELECT @IdClient = IdClient from Task where IdTask = @IdTask
SELECT @NameTask = Name from Task where IdTask = @IdTask
SELECT @StartDateTime = StartDateTime from Task where IdTask = @IdTask

SELECT @NameStatusTask = T1.Description from Task T0
INNER JOIN TablaMaestra T1 ON T0.IdStatus = T1.IdTabla
where IdTask = @IdTask

SELECT @CANTIDAD = COUNT(*) from TaskPacticipants WHERE  IdTask = @IdTask
SET @J = 1

SELECT IdEmployee 
INTO #TaskPacticipants
FROM TaskPacticipants
WHERE  IdTask = @IdTask

SELECT @EmailAsigando = @EmailAsigando + T1.Email  + N','
FROM TaskPacticipants T0
INNER JOIN Employees T1 ON T0.IdEmployee = T1.IdEmployee

SET @EmailAsigando = LEFT(@EmailAsigando, LEN(@EmailAsigando) - 1)
SELECT @EmailAsigando = Email FROM Employees WHERE IdEmployee = @IdEmployee
SELECT @EmployeeCreate = FirstName + ' ' + LastName  FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @NameClient = Name FROM Client WHERE IdClient = @IdClient

Set @FROM = @EmailAsigando
set @CC = @EmailAsigando
SET @sub = @NameTask + ' TASK ASSIGNED ' + CONVERT(varchar, @StartDateTime, 101) 
SET @body =  N'<H2>' + @EmployeeCreate + '</H2>' + N'<H3> Reassigned you to perform a task '+ @NameTask +' scheduled to start the day: ' + CONVERT(varchar, @StartDateTime, 101)  + '</H3>' + 
			N'<H3>' +'Name Client: ' + @NameClient + '</H3>' +
			N'<H3>' +'Status     : ' + @NameStatusTask + '</H3>' +
			N'<H3>' +'Task Number     : ' + CONVERT(VARCHAR(50),@IdTask) + '</H3>' 


print @FROM
print @CC
print @body
print @BC
print @sub



EXEC msdb.dbo.sp_send_dbmail
		@profile_name = 'Notifications',
		@recipients = @FROM,
		@copy_recipients =@CC,
		@Blind_copy_recipients=@BC,
		@body = @body,
		@body_format=HTML,
		@subject = @sub