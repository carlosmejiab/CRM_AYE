--SELECT IdTask,IdEmployee,State FROM TaskPacticipants

--TRUNCATE TABLE TaskPacticipants
use AyE_Services
go
 
INSERT INTO TaskPacticipants (IdTask,IdEmployee,State)
SELECT IdTask,IdEmployee,State FROM Task