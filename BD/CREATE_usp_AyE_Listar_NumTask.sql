
use AyE_Services
go
-- Objetivo: Permite listar las tareas, para ello se requiere como parametro una lista de tareas separadas por coma
-- usp_AyE_Listar_NumTask '4309,4310,4311,4308,782'
ALTER PROCEDURE usp_AyE_Listar_NumTask 
@DetalleNumTask VARCHAR(300)
AS


SELECT  RTRIM(LTRIM(Name)) as 'IdTask'
INTO #Temp_Task
FROM dbo.splitstring(@DetalleNumTask)



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
(l.Description + ' - ' + k.AccountNumber ) as 'ClientAccount'
FROM Task a
inner join Client b on b.IdClient=a.IdClient
inner join TypeTask c on c.IdTypeTask=a.IdTypeTask
inner join Employees d on d.IdEmployee=a.IdEmployee
inner join TablaMaestra e on e.IdTabla=a.IdStatus
inner join TablaMaestra f on f.IdTabla=a.IdLocation
left join Contact  g on g.IdContact=a.IdContact
inner join TablaMaestra h on h.IdTabla=a.IdPriority
inner join #Temp_Task i on i.IdTask = a.IdTask
inner join TablaMaestra j on j.IdTabla = a.FiscalYear
left join ClientAccount k on k.IdClientAccount = a.IdClientAccount
left join TablaMaestra l on l.IdTabla = k.IdBank
WHERE a.State='1' 
order by a.Name, a.IdTypeTask, b.Name asc


drop table #Temp_Task



