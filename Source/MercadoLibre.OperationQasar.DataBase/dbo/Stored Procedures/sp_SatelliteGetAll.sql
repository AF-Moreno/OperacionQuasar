-- =============================================
-- Author:		Andres Moreno
-- Create date: 01-13-2021
-- Description:	Stored Procedure to get all satellites
-- =============================================
CREATE PROCEDURE [dbo].[sp_SatelliteGetAll]
AS
BEGIN
    SELECT  
        [Id]
        ,[Name]
        ,[PositionX]
        ,[PositionY]
        ,[Enable]
    FROM [dbo].[Satellite]
END