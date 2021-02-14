-- =============================================
-- Author:		Andres Moreno
-- Create date: 01-13-2021
-- Description:	Stored Procedure to get all satellites
-- =============================================
CREATE PROCEDURE [dbo].[sp_StartApplication]
AS
BEGIN
    IF NOT EXISTS (SELECT TOP 1 [Id] from [dbo].[Satellite]) 
	BEGIN
		INSERT INTO [dbo].[Satellite]
		(
			[Name]
            ,[PositionX]
            ,[PositionY]
            ,[Enable]
            ,[CreatedON]
		)
		VALUES
        ('Kenobi', -500, -200, 1, GETUTCDATE()),
        ('Skywalker', 100, -100, 1, GETUTCDATE()),
        ('Sato', 500, 100, 1, GETUTCDATE())
	END

    IF NOT EXISTS (SELECT TOP 1 [Id] from [dbo].[User]) 
	BEGIN
		INSERT INTO [dbo].[User]
		(
			[Name]
            ,[Email]
            ,[Password]
            ,[Enable]
            ,[CreatedOn]
		)
		VALUES
        ('Admin', 'meli.admin@meli.com', '44570a8647cf93f4860e7a841f56f254aec97b69292a93aa7efff2dc3543bf06', 1, GETUTCDATE())
	END
END