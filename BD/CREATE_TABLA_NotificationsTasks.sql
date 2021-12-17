CREATE TABLE NotificationsTasks (
IdNotificationsTasks int IDENTITY(1,1) NOT NULL,
IdTask int,
StatusSendMail int,
SendDate datetime,
UserSend int
)
 

insert into TablaMaestra (Groups,Description,[Order],State)
values ('StatusSendMail','Pendiente',1,'1'),
	   ('StatusSendMail','Enviado',2,'1'),
	   ('StatusSendMail','Error',3,'1'),
	   ('StatusSendMail','No Enviado',4,'1')


DECLARE @FechaEnvio Datetime
SET @FechaEnvio = GETDATE()

INSERT INTO NotificationsTasks (IdTask,StatusSendMail,SendDate,UserSend)
SELECT IdTask,4,@FechaEnvio,IdEmployee FROM Task

--IdTask int,
--StatusSendMail char(1),  1 'Pendiente', 2 'Enviado', 3 'Error'
--SendDate datetime, Fecha Que se envio el correo
--UserSend int: Usuario al que se envio el correo