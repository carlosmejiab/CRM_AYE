USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[usp_AyE_Update_Task_Participants]    Script Date: 25/11/2021 01:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE [dbo].[usp_AyE_Update_Task_Participants] 1,4355,3
CREATE PROCEDURE [dbo].[usp_AyE_Update_Task_Participants]
@State char(1),
@IdTask int, 
@IdEmployee int
AS

Declare @IdTaskMax int,
		@errno int,
		@errmsg varchar(250),
		@err int

begin try
IF (EXISTS(select * from [dbo].[TaskPacticipants] where  IdTask=@IdTask and  IdEmployee=@IdEmployee) and (@State = '0'))	
update TaskPacticipants  set State = @State 
where  IdTask=@IdTask and  IdEmployee=@IdEmployee 

IF (EXISTS(select * from [dbo].[TaskPacticipants] where  IdTask=@IdTask and  IdEmployee=@IdEmployee)and (@State = '1'))
update TaskPacticipants  set State = @State 
where  IdTask=@IdTask and  IdEmployee=@IdEmployee 	
Else 
begin
	if (@State = '1')
	INSERT INTO TaskPacticipants Values(@IdTask,@IdEmployee,@State)
end


EXECUTE UpdateSendMailTask @State, @IdTask, @IdEmployee

end try
begin catch
	print @errno
	print @errmsg
	if @@trancount > 0
		rollback transaction
end catch