-- =============================================
-- Author:		Andres Moreno
-- Create date: 01-13-2021
-- Description:	Stored Procedure to get user by email
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserGetByEmail]
(
    @Email VARCHAR(30)
)
AS
BEGIN
    SELECT TOP(1)
        [Id],
        [Name],
        [Email],
        [Password],
        [Enable],
        [CreatedOn],
        [LastModifiedOn],
        [LastModifiedBy],
        [DeletedOn],
        [DeletedBy] 
    FROM [dbo].[User]
    WHERE [Email] = @Email
END