USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Entre_fechas]    Script Date: 26/09/2021 22:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Ejemplo [dbo].[usp_AyE_Listar_Entre_fechas]'MDocument',2,'2020-01-04','2021-02-05'
--[dbo].[usp_AyE_Listar_Entre_fechas]'MTask',0,'2021-01-01','2021-01-31'
ALTER PROCEDURE [dbo].[usp_AyE_Listar_Entre_fechas]
@TIPO VARCHAR(30),
@id Int,
@InicioDate date,
@findate date
AS

IF @TIPO='MDocument'
SELECT a.IdDocument,a.NameDocument, a.Descripction, a.CreationDate,a.ModificationDate,
c.IdClient, c.Name as 'Client',
e.IdTask, e.Name as 'TaskName',
b.NameFile,f.Name as 'FolderName',
h.Username, d.FirstName,
ec.IdClient as 'IdClienteTask', ec.Name as 'ClientTask',
b.IdFile
FROM dbo.Document a
inner join [File] b on b.IdFile=a.IdFile
left JOIN Client c on c.IdClient=a.IdClient
inner join Employees d on d.IdEmployee=a.IdEmployee
left join Task e on e.IdTask=a.IdTask
left join Client ec on ec.IdClient=e.IdClient
inner join Folder f on f.IdFolder=a.IdFolder
inner join TablaMaestra g on g.IdTabla=a.IdStatusDocument
inner join Users h on h.IdUser=a.IdUser
where a.State='1'  and a.IdClient=@id and a.CreationDate between @InicioDate and @findate 
order by a.NameDocument asc



IF @TIPO='MTask'
BEGIN
--SELECT * 
--INTO #Task
--FROM dbo.Task WHERE State='1' and StartDateTime >= @InicioDate and StartDateTime <=@findate

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
--DROP TABLE #Task
END

 

