USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[rep_TaskClient]    Script Date: 25/11/2021 00:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[rep_TaskClient] 'All','All','All','All'
-- [dbo].[rep_TaskClient] 'Evelyn Garcia','All','All','All'
-- [dbo].[rep_TaskClient] 'Evelyn Garcia','The Union Roofing LLC','All','All'
-- [dbo].[rep_TaskClient] 'Evelyn Garcia','The Union Roofing LLC','2021','All'
-- [dbo].[rep_TaskClient] 'Evelyn Garcia','The Union Roofing LLC','2021','Done'

ALTER PROCEDURE [dbo].[rep_TaskClient]
@Username varchar(50),
@ClientName varchar(100),
@FiscalYear VARCHAR (10),
@Status varchar(100)

AS
	
	CREATE TABLE #Client(
	IdClient INT
	)

	CREATE TABLE #FiscalYear(
	FiscalYear INT
	)
	--Status
	CREATE TABLE #IdStatus(
	IdStatus INT
	)

	IF @ClientName = 'ALL'
	BEGIN
		INSERT INTO #Client
		SELECT DISTINCT IdClient 
		FROM Task
	END
	ELSE
	BEGIN
		INSERT INTO #Client
		SELECT T1.IdClient FROM Task T0
		INNER JOIN Client T1 on T0.IdClient = T1.IdClient
		where T1.Name = @ClientName
	END

	IF @FiscalYear = 'ALL'
	BEGIN
		
		INSERT INTO #FiscalYear
		SELECT DISTINCT FiscalYear
		FROM TASK

	END
	ELSE
	BEGIN
		INSERT INTO #FiscalYear
		SELECT IdTabla 
		FROM TablaMaestra where Groups = 'FiscalYear' AND [Order] = @FiscalYear

	END


	IF @Status = 'ALL'
	BEGIN
		INSERT INTO #IdStatus
		SELECT DISTINCT IdStatus 
		FROM Task
	END
	ELSE
	BEGIN
		INSERT INTO #IdStatus
		SELECT IdTabla 
		FROM TablaMaestra where Groups = 'StatusTask' AND [Description] = @Status
	END



IF @Username = 'all'
begin
	Select 'User' = (T3.FirstName + ' ' + T3.LastName), 
		   'Cliente' = T0.Name,
		   'ClientType' = T5.Name,
		   'DropOffDate' = T1.StartDateTime,
		   'Status' = T6.[Description],
		   'DueDate' = T1.DueDateTime,
		   'TimeTraked' = T2.TimeWork,
		   'FiscalYear' = T7.[Order],
		   'Task' = T1.Name
	   
		   from Client T0
	Inner Join Task T1 on T0.IdClient = T1.IdClient
	Inner Join TaskPacticipants TP on TP.IdTask = T1.IdTask
	left Join Tracking T2 on T1.IdTask = T2.IdTask
	Inner Join Employees T3 on TP.IdEmployee = T3.IdEmployee
	Inner Join [Service] T4 on T0.IdService = T4.IdService
	Inner Join TypeClient T5 on T4.IdTypeClient = T5.IdTypeClient
	Inner join TablaMaestra T6 on T6.Groups = 'StatusTask' and T6.[IdTabla] = T1.IdStatus
	Inner join TablaMaestra T7 on T7.IdTabla = T1.FiscalYear
	Inner Join Users T8 on T3.IdEmployee = T8.IdEmployee
	Inner Join #Client T9 on T9.IdClient = T1.IdClient 
	Inner Join #FiscalYear T10 on T10.FiscalYear = T1.FiscalYear
	Inner Join #IdStatus T11 on T11.IdStatus = T1.IdStatus
	where T1.State = '1'
	order by T0.Name asc
end
else
begin
	
	SELECT @Username = IdEmployee FROM Employees WHERE (FirstName + ' ' + LastName) = @Username

	Select 'User' = (T3.FirstName + ' ' + T3.LastName), 
		   'Cliente' = T0.Name,
		   'ClientType' = T5.Name,
		   'DropOffDate' = T1.StartDateTime,
		   'Status' = T6.[Description],
		   'DueDate' = T1.DueDateTime,
		   'TimeTraked' = T2.TimeWork,
		   'FiscalYear' = T7.[Order],
		   'Task' = T1.Name
	   
		   from Client T0
	Inner Join Task T1 on T0.IdClient = T1.IdClient
	Inner Join TaskPacticipants TP on TP.IdTask = T1.IdTask
	left  Join Tracking T2 on T1.IdTask = T2.IdTask
	Inner Join Employees T3 on TP.IdEmployee = T3.IdEmployee
	Inner Join [Service] T4 on T0.IdService = T4.IdService
	Inner Join TypeClient T5 on T4.IdTypeClient = T5.IdTypeClient
	Inner join TablaMaestra T6 on T6.Groups = 'StatusTask' and T6.[IdTabla] = T1.IdStatus
	Inner join TablaMaestra T7 on T7.IdTabla = T1.FiscalYear
	Inner Join Users T8 on T3.IdEmployee = T8.IdEmployee
	Inner Join #Client T9 on T9.IdClient = T1.IdClient 
	Inner Join #FiscalYear T10 on T10.FiscalYear = T1.FiscalYear
	Inner Join #IdStatus T11 on T11.IdStatus = T1.IdStatus
	where T1.State = '1' and CONVERT(VARCHAR(150),TP.IdEmployee) in (@Username) 
	order by T0.Name asc
end

DROP TABLE #Client
DROP TABLE #FiscalYear
DROP TABLE #IdStatus