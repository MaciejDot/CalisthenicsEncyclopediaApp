CREATE PROCEDURE [Workout].[sp_Fatigue_GetAll]
AS
	SELECT 
		[FatigueId] [Id], 
		[Name]
	FROM
		[Workout].[Fatigue] f
	WHERE
		f.Id = (
			SELECT TOP 1
				[Id]
			FROM
				[Workout].[Fatigue] f2
			WHERE
				f2.FatigueId = f.FatigueId
			ORDER BY
				f2.Created DESC
		)
		AND f.IsActive = 1
RETURN 0