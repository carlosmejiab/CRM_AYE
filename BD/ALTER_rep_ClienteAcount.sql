USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[rep_ClienteAcount]    Script Date: 25/11/2021 00:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[rep_ClienteAcount] 'ALL','ALL','ALL'
--[dbo].[rep_ClienteAcount] 'Evelyn Garcia','2021','ALL'
--[dbo].[rep_ClienteAcount] 'Evelyn Garcia','2021','The Union Roofing LLC'

ALTER PROCEDURE [dbo].[rep_ClienteAcount]
@Username Varchar(50),
@FiscalYear CHAR(4),
@ClientName Varchar(150)
AS

CREATE TABLE #Client(
IdClient INT
)

CREATE TABLE #FiscalYear(
FiscalYear INT
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


CREATE TABLE #TEMP1 
([Id] [int] IDENTITY (1, 1) NOT NULL,  
IdParentTask int,
StatusEnero varchar(30),
StatusFebrero varchar(30),
StatusMarzo varchar(30),
StatusAbril varchar(30),
StatusMayo varchar(30),
StatusJunio varchar(30),
StatusJulio varchar(30),
StatusAgosto varchar(30),
StatusSetiembre varchar(30),
StatusOctubre varchar(30),
StatusNoviembre varchar(30),
StatusDiciembre varchar(30))


Declare @tc int
Declare @j int
Declare @IdParentTask int
Declare @EstatusEnero varchar(30)
Declare @EstatusFebrero varchar(30)
Declare @EstatusMarzo varchar(30)
Declare @EstatusAbril varchar(30)
Declare @EstatusMayo varchar(30)
Declare @EstatusJunio varchar(30)
Declare @EstatusJulio varchar(30)
Declare @EstatusAgosto varchar(30)
Declare @EstatusSetiembre varchar(30)
Declare @EstatusOctubre varchar(30)
Declare @EstatusNoviembre varchar(30)
Declare @EstatusDiciembre varchar(30)


select 
IdParentTask 
into #temporal
from Task where IdParentTask <> 0 and IdTypeTask in (6,7,8)
GROUP BY IdParentTask 

SELECT  
Orden = ROW_NUMBER() OVER(PARTITION BY IdParentTask ORDER BY IdParentTask ASC) ,
Mes = Name,
Estatus = T1.Description,
IdParentTask
Into #temporal2
from Task T0
left join TablaMaestra T1 on T1.Groups = 'StatusTask' and T1.[IdTabla] = T0.IdStatus
where IdParentTask <> 0 and IdTypeTask in (6,7,8) 

select @tc = COUNT(*) from #temporal 
set @j = 1
WHILE @j<=@tc      
BEGIN  
    
	SELECT @IdParentTask=IdParentTask FROM #temporal      
	print '@IdParentTask'
	print @IdParentTask
	SELECT @EstatusEnero = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 1 AND @IdParentTask=IdParentTask
	SELECT @EstatusFebrero = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 2 AND @IdParentTask=IdParentTask
	SELECT @EstatusMarzo = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 3 AND @IdParentTask=IdParentTask
	SELECT @EstatusAbril = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 4 AND @IdParentTask=IdParentTask
	SELECT @EstatusMayo = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 5 AND @IdParentTask=IdParentTask
	SELECT @EstatusJunio = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 6 AND @IdParentTask=IdParentTask
	SELECT @EstatusJulio = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 7 AND @IdParentTask=IdParentTask
	SELECT @EstatusAgosto = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 8 AND @IdParentTask=IdParentTask
	SELECT @EstatusSetiembre = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 9 AND @IdParentTask=IdParentTask
	SELECT @EstatusOctubre = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 10 AND @IdParentTask=IdParentTask
	SELECT @EstatusNoviembre = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 11 AND @IdParentTask=IdParentTask
	SELECT @EstatusDiciembre = ISNULL(Estatus,'') FROM #temporal2 WHERE Orden = 12 AND @IdParentTask=IdParentTask

	INSERT #TEMP1
	SELECT @IdParentTask,@EstatusEnero,@EstatusFebrero,@EstatusMarzo,@EstatusAbril,@EstatusMayo,@EstatusJunio,@EstatusJulio,
		       @EstatusAgosto,@EstatusSetiembre,@EstatusOctubre,@EstatusNoviembre,@EstatusDiciembre

    DELETE FROM #temporal2 WHERE IdParentTask=@IdParentTask
    DELETE FROM #temporal WHERE IdParentTask=@IdParentTask
	    
	SET @j=@j+1 
END

--select * from #TEMP1

IF @Username = 'all'
begin
	select 
	'User' = (T8.FirstName + ' ' + T8.LastName), 
	'Cliente' = T2.Name,
	'ClientType' = T4.Name,
	'Account' = T5.Description + ' - ' + T5.AccountNumber,
	'Jan' = T0.StatusEnero,
	'Feb' = T0.StatusFebrero,
	'Mar' = T0.StatusMarzo,
	'Apr' = T0.StatusAbril,
	'May' = T0.StatusMayo,
	'Jun' = T0.StatusJunio,
	'Jul' = T0.StatusJulio,
	'Aug' = T0.StatusAgosto,
	'Sep' = T0.StatusSetiembre,
	'Oct' = T0.StatusOctubre,
	'Nov' = T0.StatusNoviembre,
	'Dec' = T0.StatusDiciembre,
	'TimeTraked' = T1.Estimate,
	'Task' = T1.Name,
	T1.IdTask,
	'FiscalYear' = T10.Description
	 from #TEMP1 T0
	INNER JOIN Task T1 ON T0.IdParentTask = T1.IdTask
	Inner Join TaskPacticipants TP on TP.IdTask = T1.IdTask
	INNER JOIN Client T2 ON T2.IdClient = T1.IdClient
	INNER JOIN [Service] T3 on T2.IdService = T3.IdService
	INNER JOIN TypeClient T4 on T3.IdTypeClient = T4.IdTypeClient
	INNER JOIN (SELECT DISTINCT AC.AccountNumber,AC.IdBank ,TK.IdTask, BK.Description FROM Task TK
	LEFT JOIN ClientAccount AC ON TK.IdClientAccount = AC.IdClientAccount
	LEFT JOIN TablaMaestra BK on BK.Groups = 'Bank' and AC.IdBank = BK.[IdTabla]) T5 on T1.IdTask = T5.IdTask
	INNER JOIN Employees T8 on T1.IdEmployee = T8.IdEmployee
	INNER JOIN Users T9 on T8.IdEmployee = T9.IdEmployee
	INNER JOIN TablaMaestra T10 on T1.FiscalYear = T10.IdTabla
	Inner Join #Client T11 on T11.IdClient = T1.IdClient 
	Inner Join #FiscalYear T12 on T12.FiscalYear = T1.FiscalYear
	where T1.State = 1 
	order by T2.Name asc
end
else
begin
	
	SELECT @Username = IdEmployee FROM Employees WHERE (FirstName + ' ' + LastName) = @Username
	
	select 
	'User' = (T8.FirstName + ' ' + T8.LastName), 
	'Cliente' = T2.Name,
	'ClientType' = T4.Name,
	'Account' = T5.Description + ' - ' + T5.AccountNumber,
	'Jan' = T0.StatusEnero,
	'Feb' = T0.StatusFebrero,
	'Mar' = T0.StatusMarzo,
	'Apr' = T0.StatusAbril,
	'May' = T0.StatusMayo,
	'Jun' = T0.StatusJunio,
	'Jul' = T0.StatusJulio,
	'Aug' = T0.StatusAgosto,
	'Sep' = T0.StatusSetiembre,
	'Oct' = T0.StatusOctubre,
	'Nov' = T0.StatusNoviembre,
	'Dec' = T0.StatusDiciembre,
	'TimeTraked' = T1.Estimate,
	'Task' = T1.Name,
	T1.IdTask,
	'FiscalYear' = T10.Description
	 from #TEMP1 T0
	INNER JOIN Task T1 ON T0.IdParentTask = T1.IdTask
	Inner Join TaskPacticipants TP on TP.IdTask = T1.IdTask
	INNER JOIN Client T2 ON T2.IdClient = T1.IdClient
	INNER JOIN [Service] T3 on T2.IdService = T3.IdService
	INNER JOIN TypeClient T4 on T3.IdTypeClient = T4.IdTypeClient
	INNER JOIN (SELECT DISTINCT AC.AccountNumber,AC.IdBank ,TK.IdTask, BK.Description FROM Task TK
	LEFT JOIN ClientAccount AC ON TK.IdClientAccount = AC.IdClientAccount
	LEFT JOIN TablaMaestra BK on BK.Groups = 'Bank' and AC.IdBank = BK.[IdTabla]) T5 on T1.IdTask = T5.IdTask
	INNER JOIN Employees T8 on T1.IdEmployee = T8.IdEmployee
	INNER JOIN Users T9 on T8.IdEmployee = T9.IdEmployee
	INNER JOIN TablaMaestra T10 on T1.FiscalYear = T10.IdTabla
	Inner Join #Client T11 on T11.IdClient = T1.IdClient 
	Inner Join #FiscalYear T12 on T12.FiscalYear = T1.FiscalYear
	where T1.State = 1 and CONVERT(VARCHAR(150),TP.IdEmployee) in (@Username) 
	order by T2.Name asc

end

drop table #Client
drop table #FiscalYear
drop table #TEMP1
drop table #temporal2
drop table #temporal



