CREATE PROCEDURE [Workout].[sp_exercise_getAll]
AS
BEGIN
	SELECT 
		[Id], 
		[Name] 
	FROM
		[Workout].[Exercise]
END
