USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Client_Task]    Script Date: 26/09/2021 21:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[usp_AyE_Listar_Por_Periodo] 201
ALTER PROCEDURE [dbo].[usp_AyE_Listar_Por_Periodo]
--@TIPO VARCHAR(30),
@id Int
AS

DECLARE @InicioDate DATETIME
DECLARE @findate DATETIME

SET @findate = GETDATE()

IF @id = 197
BEGIN
	SET @InicioDate = DATEADD(day, -7, @findate)
END

IF @id = 198
BEGIN
	SET @InicioDate = DATEADD(month, -1, @findate)
END

IF @id = 199
BEGIN
	SET @InicioDate = DATEADD(month, -3, @findate)
END

IF @id = 200
BEGIN
	SET @InicioDate = DATEADD(month, -6, @findate)
END

IF @id = 201
BEGIN
	SET @InicioDate = DATEADD(month, -12, @findate)
END

	SELECT  a.IdTask,a.Name,a.StartDateTime,a.DueDateTime,a.Estimate,a.Description,a.State,
	b.IdClient,b.Name as 'Client',
	c.IdTypeTask, c.Name as 'TypeTask',
	d.IdEmployee, d.FirstName + ' ' + d.LastName as 'LastNameEmployees',d.FirstName as 'FirstNameEmployees', 
	e.IdTabla as 'IdStatus',e.Description as 'Status',
	f.IdTabla as 'IdLocation', f.Description as 'Location',
	g.IdContact,g.FirstName as 'FirstNameContact', g.LastName as 'LastNameContact',
	h.IdTabla, h.Description as 'Priority',
	a.CreationDate,
	a.ModificationDate,
	j.Description as 'FiscalYear',
	ISNULL((l.Description + ' - ' + k.AccountNumber ),'') as 'ClientAccount'
	FROM Task a
	inner join Client b on b.IdClient=a.IdClient
	inner join TypeTask c on c.IdTypeTask=a.IdTypeTask
	inner join Employees d on d.IdEmployee=a.IdEmployee
	inner join TablaMaestra e on e.IdTabla=a.IdStatus
	inner join TablaMaestra f on f.IdTabla=a.IdLocation
	left join Contact  g on g.IdContact=a.IdContact
	inner join TablaMaestra h on h.IdTabla=a.IdPriority
	inner join TablaMaestra j on j.IdTabla = a.FiscalYear
	left join ClientAccount k on k.IdClientAccount = a.IdClientAccount
	left join TablaMaestra l on l.IdTabla = k.IdBank
	WHERE a.State='1' and a.CreationDate >= @InicioDate and StartDateTime <=@findate
	order by a.Name, a.IdTypeTask, b.Name asc
