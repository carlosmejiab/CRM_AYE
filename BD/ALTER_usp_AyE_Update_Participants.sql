USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Update_Participants]    Script Date: 25/11/2021 00:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_AyE_Update_Participants]
@State char(1),
@IdEvent int, 
@IdEmployee int
AS

IF EXISTS(select * from [dbo].[EventPacticipants] where  IdEvent=@IdEvent and  IdEmployee=@IdEmployee)	
update EventPacticipants  set State = @State 
where  IdEvent=@IdEvent and  IdEmployee=@IdEmployee 
Else 
INSERT INTO EventPacticipants Values(@IdEvent,@IdEmployee,@State)


declare @RepeatNumber int
declare @j int
declare @cantidad int

select T0.IdEvent 
into #Event
FROM Event T0
INNER JOIN EventPacticipants T1 ON T0.IdEvent = T1.IdEvent
where RepeatNumber = 11 AND T1.IdEmployee = 16

set @j=1

while @j <= @cantidad
begin
	
	select @IdEvent = IdEvent from #Event

	EXECUTE [dbo].[usp_AyE_SendEmail] @IdEvent, @IdEmployee

	delete #Event where IdEvent = @IdEvent

	set @j = @j + 1
	
end


DROP TABLE #Event
