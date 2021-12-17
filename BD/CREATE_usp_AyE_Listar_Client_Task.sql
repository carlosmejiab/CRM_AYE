USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Client_Task]    Script Date: 25/11/2021 01:04:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Ejemplo [dbo].[usp_AyE_Listar_Client_Task]736,'2021-02-04','2021-02-07'
--[dbo].[usp_AyE_Listar_Client_Task]1441,'1/01/1900 00:00:00','01/01/1900'
CREATE PROCEDURE [dbo].[usp_AyE_Listar_Client_Task]
--@TIPO VARCHAR(30),
@id Int,
@InicioDate date,
@findate date
AS

Declare @anioI int
set @anioI = year(@InicioDate)
Declare @anioF int
set @anioF = year(@findate)



IF @anioI <= 1900 Or @anioF <= 1900
begin
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
	WHERE a.State='1' AND a.IdClient = @id
	order by a.Name, a.IdTypeTask, b.Name asc
end
else
begin
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
end