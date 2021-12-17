USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[rep_TypeTask]    Script Date: 9/12/2021 15:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EJEMPLO [dbo].[rep_TypeTask]  'Evelyn Garcia', 'Bookkeeping Services',2020,'In-Progress'
--EJEMPLO [dbo].[rep_TypeTask]  'all', 'Bookkeeping Services',2021,'In-Progress'
--EJEMPLO [dbo].[rep_TypeTask]  'all', 'all',2021,'In-Progress'
--EJEMPLO [dbo].[rep_TypeTask]  'all', 'all','all','In-Progress'
--EJEMPLO [dbo].[rep_TypeTask]  'all', 'all','all','all'

ALTER PROCEDURE [dbo].[rep_TypeTask] 
@Username varchar(150),
@TypeTask varchar(1000),
@FiscalYear varchar(150),
@IdStatus varchar(150)
AS

	CREATE TABLE #Task(
	IdTypeTask INT
	)

	CREATE TABLE #FiscalYear(
	FiscalYear INT
	)

	CREATE TABLE #IdStatus(
	IdStatus INT
	)

	IF @TypeTask = 'ALL'
	BEGIN
		INSERT INTO #Task
		SELECT DISTINCT IdTypeTask 
		FROM Task
	END
	ELSE
	BEGIN
		INSERT INTO #Task
		SELECT IdTypeTask 
		FROM TypeTask where Name = @TypeTask
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

	IF @IdStatus = 'ALL'
	BEGIN
		INSERT INTO #IdStatus
		SELECT DISTINCT IdStatus 
		FROM Task
	END
	ELSE
	BEGIN
		INSERT INTO #IdStatus
		SELECT IdTabla 
		FROM TablaMaestra where Groups = 'StatusTask' AND [Description] = @IdStatus
	END


	IF @Username = 'ALL'
	BEGIN
		SELECT DISTINCT 'User' = (T10.FirstName + ' ' + T10.LastName), 
			   'Cliente' = T0.Name,
			   'TypeTask' = T9.Name,
			   'Status' = T6.[Description],
				'StartDateTime' = T1.StartDateTime,
				'AssignedTo' = (T3.FirstName + ' ' + T3.LastName), 
			   'FiscalYear' = T7.[Order],
			   'Location' = T11.Description,
			   T1.IdTask
   
		FROM Task  T1
		Inner Join Client T0 on T0.IdClient = T1.IdClient
		Inner Join TaskPacticipants T2 on T2.IdTask = T1.IdTask
		Inner join Employees T3 on T3.IdEmployee = T2.IdEmployee 
		Inner join TablaMaestra T6 on T6.Groups = 'StatusTask' and T6.[IdTabla] = T1.IdStatus
		Inner join TablaMaestra T7 on T7.IdTabla = T1.FiscalYear
		Inner Join Users T8 on T3.IdEmployee = T8.IdEmployee
		inner join TypeTask T9 on T1.IdTypeTask = T9.IdTypeTask
		Inner Join Employees T10 on T1.IdEmployeeCreate = T10.IdEmployee
		Inner Join TablaMaestra T11 on T11.Groups = 'Location' and T11.IdTabla = T1.IdLocation
		Inner Join #Task T12 on T1.IdTypeTask = T12.IdTypeTask
		Inner Join #FiscalYear T13 on T1.FiscalYear = T13.FiscalYear
		Inner Join #IdStatus T14 on T1.IdStatus = T14.IdStatus
		where T1.State = '1'
		order by T0.Name asc
	END
	ELSE
	BEGIN
	    SELECT @Username = IdEmployee FROM Employees WHERE (FirstName + ' ' + LastName) = @Username

			SELECT DISTINCT 'User' = (T10.FirstName + ' ' + T10.LastName), 
		   'Cliente' = T0.Name,
		   'TypeTask' = T9.Name,
		   'Status' = T6.[Description],
			'StartDateTime' = T1.StartDateTime,
			'AssignedTo' = (T3.FirstName + ' ' + T3.LastName), 
		   'FiscalYear' = T7.[Order],
		   'Location' = T11.Description,
		   T1.IdTask
   
			FROM Task  T1
			Inner Join Client T0 on T0.IdClient = T1.IdClient
			Inner Join TaskPacticipants T2 on T2.IdTask = T1.IdTask
			Inner join Employees T3 on T3.IdEmployee = T2.IdEmployee 
			Inner join TablaMaestra T6 on T6.Groups = 'StatusTask' and T6.[IdTabla] = T1.IdStatus
			Inner join TablaMaestra T7 on T7.IdTabla = T1.FiscalYear
			Inner Join Users T8 on T3.IdEmployee = T8.IdEmployee
			inner join TypeTask T9 on T1.IdTypeTask = T9.IdTypeTask
			Inner Join Employees T10 on T1.IdEmployeeCreate = T10.IdEmployee
			Inner Join TablaMaestra T11 on T11.Groups = 'Location' and T11.IdTabla = T1.IdLocation
		    Inner Join #Task T12 on T1.IdTypeTask = T12.IdTypeTask
			Inner Join #FiscalYear T13 on T1.FiscalYear = T13.FiscalYear
			Inner Join #IdStatus T14 on T1.IdStatus = T14.IdStatus
			where T1.State = '1' and CONVERT(VARCHAR(150),T2.IdEmployee) in (@Username) 
			order by T0.Name asc
	END



	DROP TABLE #Task
	DROP TABLE #FiscalYear
	DROP TABLE #IdStatus
