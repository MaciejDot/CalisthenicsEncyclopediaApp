CREATE PROCEDURE [Workout].[sp_Mood_GetAll]
AS
	SELECT [Id], [Name]
	FROM [Workout].[Mood]
RETURN 0
