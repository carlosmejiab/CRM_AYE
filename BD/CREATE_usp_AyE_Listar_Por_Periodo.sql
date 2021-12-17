USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Por_Periodo]    Script Date: 25/11/2021 01:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[usp_AyE_Listar_Por_Periodo] 201
CREATE PROCEDURE [dbo].[usp_AyE_Listar_Por_Periodo]
--@TIPO VARCHAR(30),
@id Int,
@IdCliente Int
AS

DECLARE @InicioDate DATETIME
DECLARE @findate DATETIME

SET @findate = GETDATE()

IF @id = 202
BEGIN
	SET @InicioDate = DATEADD(day, -7, @findate)
END

IF @id = 203
BEGIN
	SET @InicioDate = DATEADD(month, -1, @findate)
END

IF @id = 204
BEGIN
	SET @InicioDate = DATEADD(month, -3, @findate)
END

IF @id = 205
BEGIN
	SET @InicioDate = DATEADD(month, -6, @findate)
END

IF @id = 206
BEGIN
	SET @InicioDate = DATEADD(month, -12, @findate)
END

	IF @IdCliente = 0
	BEGIN

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
		WHERE a.State='1' and a.StartDateTime >= @InicioDate and StartDateTime <=@findate
		order by a.Name, a.IdTypeTask, b.Name asc

	END
	ELSE
	BEGIN
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
		WHERE a.State='1' and a.StartDateTime >= @InicioDate and StartDateTime <=@findate and a.IdClient = @IdCliente
		order by a.Name, a.IdTypeTask, b.Name asc
	END