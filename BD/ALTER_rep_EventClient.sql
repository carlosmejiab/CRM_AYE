USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[rep_EventClient]    Script Date: 25/11/2021 00:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[rep_EventClient] 'All','All','All','All','2021-01-25','2021-02-25','All'
--[dbo].[rep_EventClient] 'All','All','All','All','2018-01-25','2022-02-25','All'
ALTER PROCEDURE [dbo].[rep_EventClient]-- 'All','All','All','All','2021-01-25','2021-02-25','All'
@Username varchar(50),
@TypeActivityEvent varchar(150),
@Location varchar(50),
@StatusEvent varchar(50),
@DateEventInicio date,
@DateEventFin date,
@Pacticipants varchar(150)

as

CREATE TABLE #TypeActivity(
IdActivityType INT
)

CREATE TABLE #Location(
IdLocation INT
)

CREATE TABLE #StatusEvent(
IdStatusEvent INT
)

CREATE TABLE #Pacticipants(
IdEmployee INT
)

IF @Pacticipants = 'ALL'
BEGIN
	INSERT INTO #Pacticipants
	SELECT DISTINCT IdEmployee FROM Event T0
	INNER JOIN EventPacticipants T1 ON T1.IdEvent = T0.IdEvent

	
END
ELSE
BEGIN
	INSERT INTO #Pacticipants
	SELECT DISTINCT T1.IdEmployee FROM Event T0
	INNER JOIN EventPacticipants T1 ON T1.IdEvent = T0.IdEvent
	INNER JOIN Employees T2 ON T2.IdEmployee = T1.IdEmployee
	where (T2.FirstName + ' ' + T2.LastName) = @Pacticipants 
END

IF @StatusEvent = 'ALL'
BEGIN
	INSERT INTO #StatusEvent
	SELECT DISTINCT IdStatusEvent FROM Event
	
END
ELSE
BEGIN
	INSERT INTO #StatusEvent
	SELECT DISTINCT T0.IdStatusEvent FROM Event T0
	INNER JOIN TablaMaestra T1 on T0.IdStatusEvent = T1.IdTabla
	where T1.Description = @StatusEvent
END

IF @Location = 'ALL'
BEGIN
	INSERT INTO #Location
	SELECT DISTINCT IdLocation FROM Event
END
ELSE
BEGIN
	INSERT INTO #Location
	SELECT DISTINCT T0.IdLocation FROM Event T0
	INNER JOIN TablaMaestra T1 on T0.IdLocation = T1.IdTabla
	where T1.Description = @Location
END

IF @TypeActivityEvent = 'ALL'
BEGIN
	INSERT INTO #TypeActivity
	SELECT DISTINCT IdActivityType FROM Event
END
ELSE
BEGIN
	INSERT INTO #TypeActivity
	SELECT DISTINCT T0.IdActivityType FROM Event T0
	INNER JOIN TablaMaestra T1 on T0.IdActivityType = T1.IdTabla
	where T1.Description = @TypeActivityEvent
END

IF @Username = 'All'
begin
select 

'UserCreate' = (T7.FirstName + ' ' + T7.LastName),
'Cliente' = T1.Name,
'NameEvent' = T0.Name,
'ActivityType' = T2.Description,
'Status' = T3.Description,
'StartDateTime' = T0.StartDateTime,
'Participants' = (T5.FirstName + ' ' + T5.LastName),
'Location' = T6.Description,
T0.IdEvent

 from Event T0
INNER JOIN Client T1 ON T0.IdClient = T1.IdClient
INNER JOIN TablaMaestra T2 ON T0.IdActivityType = T2.IdTabla
INNER JOIN TablaMaestra T3 ON T0.IdStatusEvent = T3.IdTabla
INNER JOIN [dbo].[EventPacticipants] T4 ON T0.IdEvent = T4.IdEvent
INNER JOIN Employees T5 on T4.IdEmployee = T5.IdEmployee
INNER JOIN TablaMaestra T6 ON T0.IdLocation = T6.IdTabla
INNER JOIN Employees T7 ON T0.IdEmployeeCreate = T7.IdEmployee
INNER JOIN #TypeActivity T8 ON T8.IdActivityType = T0.IdActivityType
INNER JOIN #Location T9 ON T9.IdLocation = T0.IdLocation
INNER JOIN #StatusEvent T10 ON T10.IdStatusEvent = T0.IdStatusEvent
INNER JOIN #Pacticipants T11 ON T11.IdEmployee = T4.IdEmployee
where Convert(Date,T0.StartDateTime) >= @DateEventInicio and convert(date,T0.StartDateTime) <= @DateEventFin 
order by T1.Name asc

end
else
begin
	select 
	'UserCreate' = (T7.FirstName + ' ' + T7.LastName),
	'Cliente' = T1.Name,
	'NameEvent' = T0.Name,
	'ActivityType' = T2.Description,
	'Status' = T3.Description,
	'StartDateTime' = T0.StartDateTime,
	'Participants' = (T5.FirstName + ' ' + T5.LastName),
	'Location' = T6.Description,
	T0.IdEvent
	from Event T0
	INNER JOIN Client T1 ON T0.IdClient = T1.IdClient
	INNER JOIN TablaMaestra T2 ON T0.IdActivityType = T2.IdTabla
	INNER JOIN TablaMaestra T3 ON T0.IdStatusEvent = T3.IdTabla
	INNER JOIN [dbo].[EventPacticipants] T4 ON T0.IdEvent = T4.IdEvent
	INNER JOIN Employees T5 on T4.IdEmployee = T5.IdEmployee
	INNER JOIN TablaMaestra T6 ON T0.IdLocation = T6.IdTabla
	INNER JOIN Employees T7 ON T0.IdEmployeeCreate = T7.IdEmployee
	INNER JOIN #TypeActivity T8 ON T8.IdActivityType = T0.IdActivityType
	INNER JOIN #Location T9 ON T9.IdLocation = T0.IdLocation
	INNER JOIN #StatusEvent T10 ON T10.IdStatusEvent = T0.IdStatusEvent
	INNER JOIN #Pacticipants T11 ON T11.IdEmployee = T4.IdEmployee
	where (T7.FirstName + ' ' + T7.LastName) = @Username  
	 and Convert(Date,T0.StartDateTime) >= @DateEventInicio and convert(date,T0.StartDateTime) <= @DateEventFin
	order by T1.Name asc
end


DROP TABLE #TypeActivity
DROP TABLE #Location
DROP TABLE #StatusEvent
DROP TABLE #Pacticipants