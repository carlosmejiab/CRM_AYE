USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[rep_Traking]    Script Date: 25/11/2021 00:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rep_Traking]
@Username varchar(50),
@ClientName varchar(100),
@YearTraking CHAR(4),
@Status varchar(100)

AS

CREATE TABLE #Client(
IdClient INT
)

CREATE TABLE #YearTraking(
TrackingStar INT
)

CREATE TABLE #IdStatus(
IdStatus INT
)

IF @ClientName = 'ALL'
BEGIN
	INSERT INTO #Client
	SELECT DISTINCT T2.IdClient FROM Tracking T0
	INNER JOIN Task T1 on T0.IdTask = T1.IdTask
	INNER JOIN Client T2 on T2.IdClient = T1.IdClient

END
ELSE
BEGIN
	INSERT INTO #Client
	SELECT DISTINCT T2.IdClient FROM Tracking T0
	INNER JOIN Task T1 on T0.IdTask = T1.IdTask
	INNER JOIN Client T2 on T2.IdClient = T1.IdClient
	where T2.Name = @ClientName
END

IF @YearTraking = 'ALL'
BEGIN
		
	INSERT INTO #YearTraking
	SELECT DISTINCT TrackingStar = YEAR(TrackingStar) FROM Tracking

END
ELSE
BEGIN
	INSERT INTO #YearTraking
	SELECT DISTINCT TrackingStar = YEAR(TrackingStar) FROM Tracking	WHERE YEAR(TrackingStar) = @YearTraking
END

IF @Status = 'ALL'
BEGIN
	INSERT INTO #IdStatus
	SELECT DISTINCT IdStatusTracking
	FROM Tracking
END
ELSE
BEGIN
	INSERT INTO #IdStatus
	SELECT IdTabla FROM TablaMaestra where Groups = 'StatusTracking' AND [Description] = @Status
END

IF @Username = 'all'
begin
	SELECT  'USER' = (T2.FirstName + ' ' + T2.LastName),
			'CLIENT' =  T5.Name,
			'ACCOUNT' = ISNULL((T7.Description + ' - ' + T6.AccountNumber),''),
			'TASK' = T4.Name,
			'CALENDAR_YEAR' = YEAR(T0.TrackingStar),
			'STATUS' = T8.Description,
			'TIME_TRAKED' = T0.TimeWork FROM Tracking T0
	INNER JOIN Employees T2 on T0.IdEmployee = T2.IdEmployee
	INNER JOIN Users T3 on T3.IdEmployee = T2.IdEmployee
	INNER JOIN Task T4 on T4.IdTask = T0.IdTask
	INNER JOIN Client T5 on T5.IdClient = T4.IdClient
	LEFT JOIN ClientAccount T6 on T6.IdClientAccount = T4.IdClientAccount
	LEFT JOIN TablaMaestra T7 on T7.IdTabla = T6.IdBank
	INNER JOIN TablaMaestra T8 on T8.IdTabla = T0.IdStatusTracking
	INNER JOIN #Client T9 on T9.IdClient = T5.IdClient
	INNER JOIN #YearTraking T10 ON YEAR(T0.TrackingStar) = T10.TrackingStar
	INNER JOIN #IdStatus T11 ON T0.IdStatusTracking = T11.IdStatus
end
else
begin

	SELECT @Username = IdEmployee FROM Employees WHERE (FirstName + ' ' + LastName) = @Username
	

	SELECT  'USER' = (T2.FirstName + ' ' + T2.LastName),
			'CLIENT' =  T5.Name,
			'ACCOUNT' = ISNULL((T7.Description + ' - ' + T6.AccountNumber),''),
			'TASK' = T4.Name,
			'CALENDAR_YEAR' = YEAR(T0.TrackingStar),
			'STATUS' = T8.Description,
			'TIME_TRAKED' = T0.TimeWork FROM Tracking T0
	INNER JOIN Employees T2 on T0.IdEmployee = T2.IdEmployee
	INNER JOIN Users T3 on T3.IdEmployee = T2.IdEmployee
	INNER JOIN Task T4 on T4.IdTask = T0.IdTask
	INNER JOIN Client T5 on T5.IdClient = T4.IdClient
	LEFT JOIN ClientAccount T6 on T6.IdClientAccount = T4.IdClientAccount
	LEFT JOIN TablaMaestra T7 on T7.IdTabla = T6.IdBank
	INNER JOIN TablaMaestra T8 on T8.IdTabla = T0.IdStatusTracking
	INNER JOIN #Client T9 on T9.IdClient = T5.IdClient
	INNER JOIN #YearTraking T10 ON YEAR(T0.TrackingStar) = T10.TrackingStar
	INNER JOIN #IdStatus T11 ON T0.IdStatusTracking = T11.IdStatus
	where CONVERT(VARCHAR(150),T0.IdEmployee) = @Username
end