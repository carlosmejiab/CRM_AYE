USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Add_ParticipantsTask]    Script Date: 25/11/2021 01:02:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE [dbo].[usp_AyE_Add_ParticipantsTask] 1,5369,15
--EXECUTE [dbo].[usp_AyE_Add_ParticipantsTask] 1,4316,1

CREATE PROCEDURE [dbo].[usp_AyE_Add_ParticipantsTask] 
@State char(1),
@IdTask int, 
@IdEmployee int
AS

Declare @IdTaskMax int,
		@errno int,
		@errmsg varchar(250),
		@err int

select @IdTaskMax = IdParentTask from Task where IdTask = @IdTask

begin try

if @IdTaskMax = 0
begin
	INSERT INTO TaskPacticipants (IdTask, IdEmployee,[State])
	select @IdTask,@IdEmployee,@State
end
else
begin
	INSERT INTO TaskPacticipants (IdTask, IdEmployee,[State])
	select IdTask= @IdTaskMax,IdEmployee = @IdEmployee, State = @State
	union all
	select IdTask,IdEmployee = @IdEmployee,State = @State from Task where IdParentTask = @IdTaskMax
end


EXEC SendMailTask @IdTaskMax,@IdEmployee,@State,@IdTask

end try
begin catch
	print @errno
	print @errmsg
	if @@trancount > 0
		rollback transaction
end catch
