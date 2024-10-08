USE [AyE_Services]
GO

CREATE PROCEDURE [dbo].[usp_AyE_Add_Task_Participants]
@State char(1),
@IdEvent int, 
@IdEmployee int
AS


declare @RepeatNumber int
declare @j int
declare @cantidad int

Select @RepeatNumber = RepeatNumber from Event where IdEvent = @IdEvent

Insert EventPacticipants (IdEvent,IdEmployee,State)
select IdEvent,@IdEmployee,@State FROM Event where RepeatNumber = @RepeatNumber

select @cantidad = count(*) FROM Event T0
INNER JOIN EventPacticipants T1 ON T0.IdEvent = T1.IdEvent
where RepeatNumber = @RepeatNumber AND T1.IdEmployee = @IdEmployee


select T0.IdEvent 
into #Event
FROM Event T0
INNER JOIN EventPacticipants T1 ON T0.IdEvent = T1.IdEvent
where RepeatNumber = @RepeatNumber AND T1.IdEmployee = @IdEmployee


set @j=1

while @j <= @cantidad
begin
	
	select @IdEvent = IdEvent from #Event

	EXECUTE [dbo].[usp_AyE_SendEmail] @IdEvent, @IdEmployee

	delete #Event where IdEvent = @IdEvent

	set @j = @j + 1
	
end


DROP TABLE #Event
