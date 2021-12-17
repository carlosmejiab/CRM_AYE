USE [AyE_Services]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUserAuthorized]    Script Date: 25/11/2021 00:57:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ObtenerUserAuthorized 5395,1
CREATE PROCEDURE [dbo].[ObtenerUserAuthorized]
@IdTask int,
@IdEmployee int
AS

select IdTaskPacticipants,	IdTask,	IdEmployee,	[State] 
from TaskPacticipants where IdTask = @IdTask AND IdEmployee = @IdEmployee


