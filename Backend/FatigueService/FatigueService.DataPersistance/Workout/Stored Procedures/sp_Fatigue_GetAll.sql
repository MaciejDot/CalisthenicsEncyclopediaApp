CREATE PROCEDURE [Workout].[sp_Fatigue_GetAll]
AS
BEGIN
SELECT [Id], [Name]
FROM [Workout].[Fatigue]
END