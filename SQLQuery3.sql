USE [bd_pitsor]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[SP_ProveeCurvas]
		@Pozo = NULL

SELECT	@return_value as 'Return Value'

GO
