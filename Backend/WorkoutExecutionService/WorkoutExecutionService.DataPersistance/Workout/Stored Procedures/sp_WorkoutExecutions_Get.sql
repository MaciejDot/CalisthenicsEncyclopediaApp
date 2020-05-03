CREATE PROCEDURE [Workout].[sp_WorkoutExecutions_Get]
		@username NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		wev.[ExternalId],
		wev.[Name],
		wev.[Description],
		wev.[Created],
		wev.[IsPublic],
		ee.[Id],
		ee.[Series],
		ee.[Break],
		ee.[AdditionalKgs],
		ee.[ExerciseId],
		e.[Name] [ExerciseName],
		ee.[Order],
		ee.[Description],
		ee.Repetitions [Reps]
	FROM 
		[Workout].[WorkoutExecutionVersion] wev 
		JOIN [Security].[Users] u 
			ON wev.[UserId] = u.[Id]
			AND u.[Name] = @username
		LEFT JOIN [Workout].[ExerciseExecution] ee
			ON ee.[WorkoutExecutionVersionId] = wev.[Id]
		LEFT JOIN [Workout].[Exercise] e
			ON e.[ExerciseId] = ee.[ExerciseId]
	WHERE
		wev.IsActive = 1
		AND wev.[Id] 
			IN(
				SELECT TOP(1) 
					[Id] 
				FROM 
					[Workout].[WorkoutExecutionVersion] wev2
				WHERE
					wev2.[ExternalId] = wev.[ExternalId]
				ORDER BY
					[Created] DESC
			)
	ORDER BY
		u.[Id] ASC , 
		wev.[Id] ASC , 
		ee.[Order] ASC
END
