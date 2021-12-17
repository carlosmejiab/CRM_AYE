USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Listar_Tablas_Todo]    Script Date: 25/11/2021 00:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_AyE_Listar_Tablas_Todo]  
@TIPO VARCHAR(30)  
AS  
  
IF @TIPO='MLocationes'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'Location' and a.State='1'  
  
IF @TIPO='MLocationesIdOrd'  
SELECT COUNT(*)+1 as 'Id',max(a.[Order])+1 as 'Order'   
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'Location' and a.State='1'  
  
IF @TIPO='MPosition'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'PositionEmployee' and a.State='1'  
ORDER BY a.Description ASC
  
IF @TIPO='MPositionIdOrd'  
SELECT COUNT(*)+1 as 'Id',max(a.[Order])+1 as 'Order'   
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'PositionEmployee' and a.State='1' 
 
  
IF @TIPO='MExtension'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'Extension' and a.State='1'  
ORDER BY a.Description ASC

  
IF @TIPO='MExtensionIdOrd'  
SELECT COUNT(*)+1 as 'Id',max(a.[Order])+1 as 'Order'   
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'Extension' and a.State='1'  
  
IF @TIPO='MPriority'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'PriorityTask' and a.State='1'  
ORDER BY a.Description ASC

  
IF @TIPO='MPriorityIdOrd'  
SELECT COUNT(*)+1 as 'Id',max(a.[Order])+1 as 'Order'   
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'PriorityTask' and a.State='1'  
  
  
IF @TIPO='MTitle'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'TitleContact' and a.State='1'  
ORDER BY a.Description ASC
  
  
IF @TIPO='MStatusTask'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'StatusTask' and a.State='1'  
ORDER BY a.Description ASC

  
IF @TIPO='MStatusTracking'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'StatusTracking' and a.State='1'  
  
  
IF @TIPO='MProfiles'  
SELECT  a.IdProfile,a.ProfileName,a.Description  
FROM dbo.Profiles a  
WHERE a.State='1' 
ORDER BY  a.ProfileName ASC

  
IF @TIPO='MStatusEvent'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'StatusEvento' and a.State='1'  
ORDER BY a.Description ASC

  
  
IF @TIPO='MActivityType'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'ActivityTypeEvent' and a.State='1' 
ORDER BY a.Description ASC
 
  
IF @TIPO='MStatusDoc'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'StatusDocumento' and a.State='1'  
ORDER BY a.Description ASC

  
  
IF @TIPO='MUsersEmpleyees'  
SELECT  a.IdUser,a.Username,a.State,a.CreationDate,a.ModificationDate,  
b.IdEmployee,b.LastName,b.FirstName,b.Email,b.MobilePhone,b.State,b.CreationDate,b.ModificationDate,  
c.IdProfile,c.ProfileName,c.Description,  
d.Description as 'Location',e.Description as 'Position', f.Description as 'Extension'  
FROM dbo.Users a  
inner join Employees b on b.IdEmployee=a.IdEmployee  
inner join Profiles c on c.IdProfile=a.IdProfile  
inner join TablaMaestra d on d.IdTabla=b.IdLocation  
inner join TablaMaestra e on e.IdTabla=b.IdPosition  
inner join TablaMaestra f on f.IdTabla=b.IdExtension  
WHERE a.State='1'  
ORDER BY a.Username ASC

  
IF @TIPO='EmployeesIdMax'  
select MAX(IdEmployee) as 'Id_Max' from Employees;  
  
IF @TIPO='TaskIdMax'  
select MAX(IdTask) as 'Id_Max' from Task;  
  
IF @TIPO='EventIdMax'  
select MAX(IdEvent) as 'Id_Max' from Event;  

IF @TIPO='TaskIdMax'  
select MAX(IdTask) as 'Id_Max' from Task;  
  
  
IF @TIPO='MEmployees'  
SELECT  b.IdEmployee,LastName = (b.FirstName + ' ' + b.LastName),b.FirstName,b.Email,b.MobilePhone,b.State,b.CreationDate,b.ModificationDate,  
d.Description as 'Location',e.Description as 'Position', f.Description as 'Extension',
UserNameDoc = b.FirstName + ' ' + b.LastName,
NameEmployees = (b.FirstName + ' ' + b.LastName)    
FROM  Employees b   
inner join TablaMaestra d on d.IdTabla=b.IdLocation  
inner join TablaMaestra e on e.IdTabla=b.IdPosition  
inner join TablaMaestra f on f.IdTabla=b.IdExtension  
--WHERE b.State='1'  
ORDER BY b.FirstName, b.LastName ASC

  
  
IF @TIPO='ProfileIdMax'  
select MAX(IdProfile) as 'Id_Max' from Profiles;  
  
  
IF @TIPO='MTypeClient'  
SELECT  a.IdTypeClient,a.Name  
FROM dbo.TypeClient a  
WHERE a.State='1'
ORDER BY a.Name ASC 
  
IF @TIPO='MState'  
SELECT  a.IdState,a.NameState  
FROM dbo.State a  
WHERE a.State='1'
ORDER BY  a.NameState  ASC 
  
--Quitar el tema de top 100 cuando se realice la consulta  de listado  
IF @TIPO='MCity'  
SELECT a.IdCity,a.NombreCity,  
b.IdState,b.NameState  
FROM dbo.City a  
inner join State b on b.IdState=a.IdState  
WHERE a.State='1'  
ORDER BY a.NombreCity ASC
--Quitar el tema de top 100 cuando se realice la consulta  de listado  
  
  
IF @TIPO='MServices'  
SELECT a.IdService,a.IdStatusService,a.Name,convert(decimal(10,2),a.Price) as 'Price',a.Descripcion,  
b.IdTypeClient,b.Name as 'ClientType'  
FROM dbo.Service a  
inner join TypeClient b on b.IdTypeClient=a.IdTypeClient  
WHERE a.IdStatusService='1' 
ORDER BY a.Name ASC
 
  
IF @TIPO='MClient'  
SELECT a.IdClient,a.Name,a.Email,a.Phone,a.Address,a.Comments,a.State,a.CreationDate,a.ModificationDate,  
b.IdTypeClient,b.Name as 'TypeClient',  
c.IdCity,c.NombreCity,d.IdTabla,d.Description as 'Location',e.IdUser,e.Username,  
x.IdService, x.Name as 'Services'  
FROM dbo.Client a  
inner join Service x on x.IdService=a.IdService  
inner join TypeClient b on b.IdTypeClient=x.IdTypeClient  
inner join City c on c.IdCity=a.IdCity  
inner join TablaMaestra d on d.IdTabla=a.IdLocation  
inner join Users e on e.IdUser=a.IdUser  
WHERE a.State='1'  
order by name asc  
  
  
IF @TIPO='ClientIdMax'  
select MAX(IdClient) as 'Id_Max' from Client;  
  
IF @TIPO='MContact'  
SELECT a.IdContact,a.WordAreas,a.FirstName,a.LastName,a.Email,a.Phone,a.DateOfBirth,a.Address,a.Description,a.State,a.CreationDate,a.ModificationDate,  
c.IdCity,c.NombreCity,d.IdTabla,d.Description as 'Titles',  
e.IdUser,e.Username,f.IdState,f.NameState,  
b.IdEmployee,b.LastName as 'LastNameEmployees',b.FirstName + ' ' + b.LastName as 'FirstNameEmployees',  
g.IdClient,g.Name as 'Client'  
FROM Contact a  
inner join Employees b on b.IdEmployee=a.IdEmployee  
inner join City c on c.IdCity=a.IdCity  
left join TablaMaestra d on d.IdTabla=a.IdTitles  
left join Users e on e.IdUser=a.IdUser  
inner join State f on f.IdState=c.IdState  
inner join Client g on g.IdClient=a.IdClient  
WHERE a.State='1'  
order by FirstName,LastName asc  
  
IF @TIPO='MTypeTask'  
SELECT  a.IdTypeTask,a.Name  
FROM dbo.TypeTask a  
ORDER BY a.Name ASC
  
IF @TIPO='MTask'  
SELECT  a.IdTask,a.Name,a.StartDateTime,a.DueDateTime,a.Estimate,a.Description,a.State,  
b.IdClient,b.Name as 'Client',  
c.IdTypeTask, c.Name as 'TypeTask',  
d.IdEmployee,d.LastName as 'LastNameEmployees',d.FirstName as 'FirstNameEmployees',   
e.IdTabla as 'IdStatus',e.Description as 'Status',  
f.IdTabla as 'IdLocation', f.Description as 'Location',  
g.IdContact,g.FirstName as 'FirstNameContact', g.LastName as 'LastNameContact',  
h.IdTabla, h.Description as 'Priority',
Assigned = d.LastName
FROM dbo.Task a  
inner join Client b on b.IdClient=a.IdClient  
inner join TypeTask c on c.IdTypeTask=a.IdTypeTask  
inner join Employees d on d.IdEmployee=a.IdEmployee  
inner join TablaMaestra e on e.IdTabla=a.IdStatus  
inner join TablaMaestra f on f.IdTabla=a.IdLocation  
inner join Contact  g on g.IdContact=a.IdContact  
inner join TablaMaestra h on h.IdTabla=a.IdPriority  
where a.State='1'   
ORDER BY a.Name ASC 
  
IF @TIPO='MTaskList'  
SELECT  a.IdTask,a.Name,a.StartDateTime,a.DueDateTime,a.State,  
b.IdClient,b.Name as 'Client',  
d.IdEmployee,d.LastName as 'LastNameEmployees',d.FirstName as 'FirstNameEmployees',   
e.IdTabla as 'IdStatus',e.Description as 'Status'  
FROM dbo.Task a  
inner join Client b on b.IdClient=a.IdClient  
inner join Employees d on d.IdEmployee=a.IdEmployee  
inner join TablaMaestra e on e.IdTabla=a.IdStatus  
where a.State='1' and IdParentTask=0  
ORDER BY a.Name ASC
  
  
  
IF @TIPO='MSubTask'  
SELECT  a.IdSubTasks,a.NameSubtask,  
CASE a.Mes  
WHEN '1' THEN 'January'  
WHEN '2' THEN 'February'  
WHEN '3' THEN 'March'  
WHEN '4' THEN 'April'  
WHEN '5' THEN 'May'  
WHEN '6' THEN 'June'  
WHEN '7' THEN 'July'  
WHEN '8' THEN 'August'  
WHEN '9' THEN 'September'  
WHEN '10' THEN 'October'  
WHEN '11' THEN 'November'  
WHEN '12' THEN 'December' END AS 'Mes',  
a.State,b.IdTypeTask,b.Description as 'TypeTask',  
c.IdTabla as 'IdStatus', c.Description as 'Status'  
FROM dbo.SubTask a  
inner join TypeTask b on b.IdTypeTask=a.IdTypeTask  
inner join TablaMaestra c on c.IdTabla=a.IdStatus  
WHERE a.State='1'  
ORDER BY  a.NameSubtask ASC 
  
  
IF @TIPO='MFolder'  
SELECT a.IdFolder,a.Name as 'Folder', a.FolderParent,a.Ruta,  
b.IdClient,b.Name  
FROM dbo.Folder a  
inner join Client b on b.IdClient=a.IdClient  
ORDER BY a.Name ASC
  
IF @TIPO='MFolderParent'    
SELECT a.IdFolder,a.Name as 'Folder', a.FolderParent,a.Ruta,    
--SUBSTRING(a.Ruta,99,100) as 'RutaCorta'
a.Ruta as 'RutaCorta'
FROM dbo.Folder a 
ORDER BY a.Name ASC
--where a.IdClient=0 
  
IF @TIPO='MEvent'  
select a.IdEvent,a.Name,a.StartDateTime,a.DueDateTime,a.Descripction,  
b.IdTabla as 'IdStatusEvent',b.Description as 'Status',  
c.IdTypeTask, c.Description as 'TypeTask',  
d.IdTabla as 'IdLocation', d.Description as 'Location',  
e.IdTabla as 'IdPriority', e.Description as 'Priority',  
f.IdTask,f.Description as 'Task',  
g.IdClient,g.Name as 'Client'  
from Event a  
inner join TablaMaestra b on b.IdTabla=a.IdStatusEvent  
inner join TypeTask c on c.IdTypeTask=a.IdActivityType  
inner join TablaMaestra d on d.IdTabla=a.IdLocation  
inner join TablaMaestra e on e.IdTabla=a.IdPriority  
left join Task f on f.IdTask=a.IdTask  
left join Client g on g.IdClient=a.IdClient  
where a.State='1' 
ORDER BY a.Name ASC
  
  
IF @TIPO='MDocument'  
SELECT a.IdDocument,a.NameDocument, a.Descripction, a.CreationDate,a.ModificationDate,  
c.IdClient, c.Name as 'Client',  
e.IdTask, e.Name as 'TaskName',  
b.NameFile,f.Name as 'FolderName',  
h.Username, d.FirstName,  
ec.IdClient as 'IdClienteTask', ec.Name as 'ClientTask',
UserNameDoc = d.FirstName + ' ' + d.LastName  
FROM dbo.Document a  
inner join [File] b on b.IdFile=a.IdFile  
left JOIN Client c on c.IdClient=a.IdClient  
inner join Employees d on d.IdEmployee=a.IdEmployee  
left join Task e on e.IdTask=a.IdTask  
left join Client ec on ec.IdClient=e.IdClient  
inner join Folder f on f.IdFolder=a.IdFolder  
inner join TablaMaestra g on g.IdTabla=a.IdStatusDocument  
inner join Users h on h.IdUser=a.IdUser  
where a.State='1'  
ORDER BY a.NameDocument ASC
  
IF @TIPO='FileIdMax'  
select MAX(IdFile) as 'Id_Max' from [File];  
  
  
IF @TIPO='MRepeatEvent'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'RepeatEvent' and a.State='1'
ORDER BY a.Description ASC
  
  
   
IF @TIPO='MFiscalYear'  
SELECT  a.Groups,a.IdTabla,a.Description,a.[Order],a.State  
FROM dbo.TablaMaestra a  
WHERE a.Groups= 'FiscalYear' and a.State='1'   
ORDER BY [Order] desc  
  
  
IF @TIPO='M_ClientAccount'  
SELECT IdClientAccount, NameClient = T1.Name , NameBank = T2.Description ,T0.AccountNumber, Status = T3.[Description]  FROM [dbo].[ClientAccount] T0  
INNER JOIN [dbo].[Client] T1 ON T0.IdClient = T1.IdClient  
INNER JOIN TablaMaestra T2 on T0.IdBank=T2.[IdTabla] AND T2.Groups = 'Bank'  
INNER JOIN TablaMaestra T3 on T0.State=T3.[Order] AND T3.Groups = 'StatusTable'  
WHERE T0.State = '1' 
order by NameBank asc
  
IF @TIPO='MBank'  
SELECT a.[IdTabla], a.[Description] FROM dbo.TablaMaestra a  
WHERE Groups = 'Bank' AND State = 1 
order by  a.Description asc
  
IF @TIPO='M_CboClientAccount'  
SELECT IdTabla = IdClientAccount,Description = T2.Description + ' - ' + T0.AccountNumber FROM [dbo].[ClientAccount] T0  
INNER JOIN [dbo].[Client] T1 ON T0.IdClient = T1.IdClient  
INNER JOIN TablaMaestra T2 on T0.IdBank=T2.[IdTabla] AND T2.Groups = 'Bank'  
INNER JOIN TablaMaestra T3 on T0.State=T3.[Order] AND T3.Groups = 'StatusTable'  
WHERE T0.State = '1'  
ORDER BY T2.Description ASC
  
IF @TIPO='M_Traking'  
select T0.IdTracking,TrackingName = T0.Name, T0.StartDateTime, T0.DueDateTime, T0.DurationTime, 
T0.TimeWork,StatusTracking = T2.Description, Task = T1.Name, NameClient = T3.Name, FiscalYear = T4.Description     
from Tracking T0  
INNER JOIN Task T1 ON T0.IdTask = T1.IdTask  
INNER JOIN TablaMaestra T2 ON T0.IdStatusTracking = T2.IdTabla  
INNER JOIN Client T3 ON T3.IdClient = T1.IdClient
INNER JOIN TablaMaestra T4 ON T4.Groups = 'FiscalYear' and T4.IdTabla = T1.FiscalYear
--WHERE T2.Groups = 'StatusTracking' AND T2.Description <> 'Completed'
ORDER BY T0.Name ASC
