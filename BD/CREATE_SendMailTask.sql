USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[SendMailTask]    Script Date: 25/11/2021 01:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE SendMailTask 0,4,1,5115
CREATE PROCEDURE [dbo].[SendMailTask]
@IdTaskMax int,
@IdEmployee int,
@State char(1),
@IdTask int
as

declare @CadenaNumeroTarea varchar(1000)
declare @CadenaNombreTarea varchar(2500)
declare @Mensaje varchar(2500)
declare @NameStatusTask  varchar(150)

DECLARE @FROM varchar(max)
DECLARE @BC varchar(max)
DECLARE @CC varchar(max)
DECLARE @BODY  NVARCHAR(MAX)
DECLARE @Email varchar(120)
DECLARE @sub NVARCHAR(MAX)
DECLARE @EmailAsigando VARCHAR(120)
DECLARE @EmailCreation VARCHAR(120)
DECLARE @EmployeeCreate NVARCHAR(150)
DECLARE @NameClient NVARCHAR(200)
DECLARE @IdEmployeeCreate INT
DECLARE @IdClient INT
DECLARE @Name nvarchar(100)
DECLARE @StartDateTime datetime

create table #table (
IdTask int,
IdEmployee int,
State char(1)
)

IF @IdTaskMax <> 0
BEGIN


	insert into #table(IdTask,IdEmployee,State)
	select IdTask= @IdTaskMax,IdEmployee = @IdEmployee, State = @State

	insert into #table(IdTask,IdEmployee,State)
	select IdTask,IdEmployee,State from Task where IdParentTask = @IdTaskMax

	SELECT @NameStatusTask = T1.Description from Task T0
	INNER JOIN TablaMaestra T1 ON T0.IdStatus = T1.IdTabla
	where IdTask = @IdTaskMax

	set @CadenaNumeroTarea = ''
	set @CadenaNombreTarea = ''


	select @CadenaNumeroTarea = @CadenaNumeroTarea + convert(varchar(250), T0.IdTask) + N',', @CadenaNombreTarea = @CadenaNombreTarea + T1.Name + N','  from #table T0
	inner join Task T1 on T1.IdTask = T0.IdTask

	set @CadenaNumeroTarea = LEFT(@CadenaNumeroTarea, LEN(@CadenaNumeroTarea) - 1)
	set @CadenaNombreTarea = LEFT(@CadenaNombreTarea, LEN(@CadenaNombreTarea) - 1)

	set @Mensaje = ''

	SELECT @IdEmployeeCreate = IdEmployeeCreate, @IdClient = IdClient, @Name = Name, @StartDateTime = StartDateTime FROM Task WHERE  IdTask = @IdTaskMax
	set @body = ''


	SELECT @EmailAsigando = Email FROM Employees WHERE IdEmployee = @IdEmployee
	SELECT @EmailCreation = Email FROM Employees WHERE IdEmployee = @IdEmployeeCreate
	SELECT @EmployeeCreate = FirstName + ' ' + LastName  FROM Employees WHERE IdEmployee = @IdEmployeeCreate
	SELECT @NameClient = Name FROM Client WHERE IdClient = @IdClient

	Set @FROM = @EmailAsigando
	--set @CC = @EmailCreation
	set @CC = @EmailAsigando
	SET @sub = @Name + ' TASK ASSIGNED ' + CONVERT(varchar, @StartDateTime, 101) 
	SET @body =  N'<H2>' + @EmployeeCreate + '</H2>' + N'<H3> Assigned you to perform a task '+ @Name +' scheduled to start the day: ' + CONVERT(varchar, @StartDateTime, 101)  + '</H3>' + char(13) +
				N'<H3>' +'Name Client: ' + @NameClient + '</H3>'  + 
				N'<H3>' +'Task Data: ' + '</H3>'  + 
				N'<H3>' +'======= ' + '</H3>'  + 
				N'<H3>' +'Task Number : ' + @CadenaNumeroTarea + '</H3>'  + 
				N'<H3>' +'Task Name	  : ' + @CadenaNombreTarea + '</H3>'  + 
				N'<H3>' +'Status	  : ' + @NameStatusTask + '</H3>'  

	PRINT @FROM
	PRINT @CC
	PRINT @sub
	print @body

	EXEC msdb.dbo.sp_send_dbmail
			@profile_name = 'Notifications',
			@recipients = @FROM,
			@copy_recipients =@CC,
			@Blind_copy_recipients=@BC,
			@body = @body,
			@body_format=HTML,
			@subject = @sub
END

ELSE
BEGIN
	SELECT @NameStatusTask = T1.Description, 
	@CadenaNumeroTarea = convert(varchar(250), T0.IdTask),
	@CadenaNombreTarea = T0.Name,
	@IdEmployeeCreate = IdEmployeeCreate,
	@IdClient = IdClient,
	@Name = Name,
	@StartDateTime = StartDateTime from Task T0
	INNER JOIN TablaMaestra T1 ON T0.IdStatus = T1.IdTabla
	where IdTask = @IdTask

	set @body = ''

	SELECT @EmailAsigando = Email FROM Employees WHERE IdEmployee = @IdEmployee
	SELECT @EmailCreation = Email FROM Employees WHERE IdEmployee = @IdEmployeeCreate
	SELECT @EmployeeCreate = FirstName + ' ' + LastName  FROM Employees WHERE IdEmployee = @IdEmployeeCreate
	SELECT @NameClient = Name FROM Client WHERE IdClient = @IdClient

	Set @FROM = @EmailAsigando
	--set @CC = @EmailCreation
	set @CC = @EmailAsigando
	SET @sub = @Name + ' TASK ASSIGNED ' + CONVERT(varchar, @StartDateTime, 101) 
	SET @body =  N'<H2>' + @EmployeeCreate + '</H2>' + N'<H3> Assigned you to perform a task '+ @Name +' scheduled to start the day: ' + CONVERT(varchar, @StartDateTime, 101)  + '</H3>' + char(13) +
				N'<H3>' +'Name Client: ' + @NameClient + '</H3>'  + 
				N'<H3>' +'Task Data: ' + '</H3>'  + 
				N'<H3>' +'======= ' + '</H3>'  + 
				N'<H3>' +'Task Number : ' + @CadenaNumeroTarea + '</H3>'  + 
				N'<H3>' +'Task Name	  : ' + @CadenaNombreTarea + '</H3>'  + 
				N'<H3>' +'Status	  : ' + @NameStatusTask + '</H3>' 

	PRINT @FROM
	PRINT @CC
	PRINT @sub
	print @body

	EXEC msdb.dbo.sp_send_dbmail
	@profile_name = 'Notifications',
	@recipients = @FROM,
	@copy_recipients =@CC,
	@Blind_copy_recipients=@BC,
	@body = @body,
	@body_format=HTML,
	@subject = @sub

END

drop table #table

