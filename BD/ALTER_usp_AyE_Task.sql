USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Task]    Script Date: 11/12/2021 20:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Objetivo: Guardar, UPDATE, Eliminar y guardar las sub tareas
-- TIPO 1: GUARDAR TAREA
-- TIPO 2: UPDATE TAREA 
-- TIPO 3: DELETE TAREA 
-- TIPO 4: SaveTaskSubTask (Guarda la Sub Tarea) 

--Ejemplo  [dbo].[usp_AyE_Task] 0,156,1,1,44,15,0,156,32,'Personal Income Tax','2021-01-06', '2021-01-07', 480,'','1',1,67,0,1
ALTER PROCEDURE [dbo].[usp_AyE_Task] 
@IdTask INT,  
@IdClient INT,  
@IdTypeTask INT,  
@IdEmployee INT,  
@IdStatus INT,  
@IdLocation INT,  
@IdParentTask INT,  
@IdContact INT,  
@IdPriority INT,  
@Name varchar(150),
@StartDateTime datetime,  
@DueDateTime datetime,  
@Estimate int,  
@Description varchar(max),  
@State char(1),  
@TIPO TINYINT,  
@FiscalYear INT,  
@IdClientAccount INT, 
@IdEmployeeCreate INT
AS  

DECLARE @FROM varchar(max)
DECLARE @BC varchar(max)
DECLARE @CC varchar(max)
DECLARE @BODY  NVARCHAR(MAX)
DECLARE @Email varchar(120)
DECLARE @sub NVARCHAR(MAX)
DECLARE @EmailAsigando varchar(120)
DECLARE @EmailCreation varchar(120)
DECLARE @EmployeeCreate NVARCHAR(150)
DECLARE @NameClient NVARCHAR(200)



IF @TIPO=1  
  
BEGIN  
print @IdEmployeeCreate
INSERT INTO dbo.Task(IdClient,IdTypeTask,IdEmployee,IdStatus,IdLocation,IdParentTask,IdContact,IdPriority,Name,StartDateTime,DueDateTime,Estimate,Description,State,FiscalYear,IdClientAccount,IdEmployeeCreate,CreationDate,ModificationDate)  
VALUES(@IdClient,@IdTypeTask,@IdEmployee,@IdStatus,@IdLocation,@IdParentTask,@IdContact,@IdPriority,@Name,@StartDateTime,@DueDateTime,@Estimate,@Description,@State,@FiscalYear,@IdClientAccount,@IdEmployeeCreate,GETDATE(),GETDATE())  

SELECT @EmailAsigando = Email FROM Employees WHERE IdEmployee = @IdEmployee
SELECT @EmailCreation = Email FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @EmployeeCreate = FirstName + ' ' + LastName  FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @NameClient = Name FROM Client WHERE IdClient = @IdClient

Set @FROM = @EmailAsigando
set @CC = @EmailCreation
SET @sub = @Name + 'TASK ASSIGNED ' + CONVERT(varchar, @StartDateTime, 101) 
SET @body =  N'<H2>' + @EmployeeCreate + '</H2>' + N'<H3> Assigned you to perform a task '+ @Name +' scheduled to start the day: ' + CONVERT(varchar, @StartDateTime, 101)  + '</H3>' + 
			N'<H3>' +'Name Client: ' + @NameClient + '</H3>'

--EL CORREO YA  NO SE ENVIA DESDE ACA
--EXEC msdb.dbo.sp_send_dbmail
--		@profile_name = 'Notifications',
--		@recipients = @FROM,
--		@copy_recipients =@CC,
--		@Blind_copy_recipients=@BC,
--		@body = @body,
--		@body_format=HTML,
--		@subject = @sub

IF (EXISTS(select count(*) from [dbo].[SubTask] where IdTypeTask = @IdTypeTask))  
Begin  
	 Declare @IdTaskMax int  
	 select @IdTaskMax = MAX(IdTask) from [dbo].[Task]  
  
	 DECLARE @ANHO CHAR(4)  
	 SELECT @ANHO = YEAR(GETDATE())  
	 INSERT [dbo].[Task] (IdClient, IdTypeTask, IdEmployee, IdStatus, IdLocation, IdParentTask, IdContact, IdPriority, Name, StartDateTime, DueDateTime, Estimate, Description, State,FiscalYear,IdClientAccount,IdEmployeeCreate,CreationDate,ModificationDate)  
	 SELECT   
	 @IdClient,  
	 @IdTypeTask,  
	 @IdEmployee,  
	 @IdStatus,  
	 @IdLocation,  
	 @IdTaskMax,  
	 @IdContact,  
	 @IdPriority,  
	 NameSubtask,  
	 @ANHO + '-'+ CAST(Mes AS varchar)+ '-' + '01'  ,  
	 @ANHO + '-'+ CAST(Mes AS varchar)+ '-' + CAST((DAY(DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,(@ANHO + '-' + CAST(Mes AS varchar) + '-' + '01')) + 1,0)))) AS VARCHAR),  
	 0,   
	 @Description,  
	 @State,  
	 @FiscalYear,  
	 @IdClientAccount,
	 @IdEmployeeCreate,
	 GETDATE(),
	 GETDATE()
	 FROM [dbo].[SubTask] WHERE IdTypeTask = @IdTypeTask  
End


END  
  
IF @TIPO=2  
BEGIN  
UPDATE dbo.Task  
SET  
IdClient=@IdClient,  
IdTypeTask=@IdTypeTask,  
IdEmployee=@IdEmployee,  
IdStatus=@IdStatus,  
IdLocation=@IdLocation,  
IdParentTask=@IdParentTask,  
IdContact=@IdContact,  
IdPriority=@IdPriority,  
Name=@Name,  
StartDateTime=@StartDateTime,  
DueDateTime=@DueDateTime,  
Estimate=@Estimate,  
Description=@Description,  
State=@State,  
FiscalYear=@FiscalYear,  
IdClientAccount=@IdClientAccount,
ModificationDate=GETDATE()
WHERE  
IdTask=@IdTask  


SELECT @EmailAsigando = Email FROM Employees WHERE IdEmployee = @IdEmployee
SELECT @EmailCreation = Email FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @EmployeeCreate = FirstName + ' ' + LastName  FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @NameClient = Name FROM Client WHERE IdClient = @IdClient

Set @FROM = @EmailAsigando
set @CC = @EmailCreation
SET @sub = @Name + 'TASK ASSIGNED ' + CONVERT(varchar, @StartDateTime, 101) 
SET @body =  N'<H2>' + @EmployeeCreate + '</H2>' + N'<H3> Reassigned you to perform a task '+ @Name +' scheduled to start the day: ' + CONVERT(varchar, @StartDateTime, 101)  + '</H3>' + 
			N'<H3>' +'Name Client: ' + @NameClient + '</H3>'

--EL CORREO YA  NO SE ENVIA DESDE ACA
--EXEC msdb.dbo.sp_send_dbmail
--		@profile_name = 'Notifications',
--		@recipients = @FROM,
--		@copy_recipients =@CC,
--		@Blind_copy_recipients=@BC,
--		@body = @body,
--		@body_format=HTML,
--		@subject = @sub

END  
  
  
IF @TIPO=3  
BEGIN  
UPDATE dbo.Task  
SET  State=@State, ModificationDate = GETDATE()
WHERE  
IdTask=@IdTask  
END  
  
  
IF @TIPO=4 
begin
  
IF (NOT EXISTS(select count(*) from [dbo].[SubTask] where IdTypeTask = @IdTypeTask))  
Begin  
 INSERT [dbo].[Task] (IdClient, IdTypeTask, IdEmployee, IdStatus, IdLocation, IdParentTask, IdContact, IdPriority, Name, StartDateTime, DueDateTime, Estimate, Description, State,FiscalYear,IdClientAccount,IdEmployeeCreate,CreationDate,ModificationDate)  
    VALUES (@IdClient,@IdTypeTask,@IdEmployee,@IdStatus,@IdLocation,@IdParentTask,@IdContact,@IdPriority,@Name,@StartDateTime,@DueDateTime,@Estimate,@Description,@State,@FiscalYear,@IdClientAccount,@IdEmployeeCreate,GETDATE(),GETDATE())  

SELECT @EmailAsigando = Email FROM Employees WHERE IdEmployee = @IdEmployee
SELECT @EmailCreation = Email FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @EmployeeCreate = FirstName + ' ' + LastName  FROM Employees WHERE IdEmployee = @IdEmployeeCreate
SELECT @NameClient = Name FROM Client WHERE IdClient = @IdClient

Set @FROM = @EmailAsigando
set @CC = @EmailCreation
SET @sub = @Name + 'TASK ASSIGNED ' + CONVERT(varchar, @StartDateTime, 101) 
SET @body =  N'<H2>' + @EmployeeCreate + '</H2>' + N'<H3> Assigned you to perform a task '+ @Name +' scheduled to start the day: ' + CONVERT(varchar, @StartDateTime, 101)  + '</H3>' + 
			N'<H3>' +'Name Client: ' + @NameClient + '</H3>'


EXEC msdb.dbo.sp_send_dbmail
		@profile_name = 'Notifications',
		@recipients = @FROM,
		@copy_recipients =@CC,
		@Blind_copy_recipients=@BC,
		@body = @body,
		@body_format=HTML,
		@subject = @sub

End  
Else  
Begin   
 INSERT [dbo].[Task] (IdClient, IdTypeTask, IdEmployee, IdStatus, IdLocation, IdParentTask, IdContact, IdPriority, Name, StartDateTime, DueDateTime, Estimate, Description, State,FiscalYear,IdClientAccount,IdEmployeeCreate,CreationDate,ModificationDate)  
 SELECT   
 @IdClient,  
 @IdTypeTask,  
 @IdEmployee,  
 @IdStatus,  
 @IdLocation,  
 @IdTaskMax,  
 @IdContact,  
 @IdPriority,  
 NameSubtask,  
 @ANHO + '-'+ CAST(Mes AS varchar)+ '-' + '01'  ,  
 @ANHO + '-'+ CAST(Mes AS varchar)+ '-' + CAST((DAY(DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,(@ANHO + '-' + CAST(Mes AS varchar) + '-' + '01')) + 1,0)))) AS VARCHAR),  
 @State,   
 @Description,  
 @State,  
 @FiscalYear,  
 @IdClientAccount,
 @IdEmployeeCreate,
 GETDATE(),
 GETDATE()
 FROM [dbo].[SubTask] WHERE IdTypeTask = @IdTypeTask  
End  
end
