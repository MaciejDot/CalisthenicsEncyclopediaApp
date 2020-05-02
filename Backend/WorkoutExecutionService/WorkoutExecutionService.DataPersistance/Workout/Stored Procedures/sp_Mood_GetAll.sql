CREATE PROCEDURE [Workout].[sp_Mood_GetAll]
AS
	SELECT 
		[MoodId] [Id], 
		[Name]
	FROM
		[Workout].[Mood] m
	WHERE
		m.Id = (
			SELECT TOP 1
				[Id]
			FROM
				[Workout].[Mood] m2
			WHERE
				m2.MoodId = m.MoodId
			ORDER BY
				m2.Created DESC
		)
		AND m.IsActive = 1
RETURN 0